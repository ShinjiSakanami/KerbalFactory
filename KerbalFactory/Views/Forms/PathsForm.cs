using System;
using System.IO;
using System.Windows.Forms;

namespace KerbalFactory.Views
{
    public partial class PathsForm : BaseForm
    {
        public PathsForm()
        {
            this.InitializeComponent();
        }

        public void LoadPaths()
        {
            this.PathsTable.Rows.Clear();
            foreach (GamePath path in KFSettings.Instance.KnownPaths)
            {
                this.PathsTable.Rows.Add(new object[]
                {
                    path.Name,
                    path.Version,
                    path.FullPath
                });
            }
        }

        public void AddPath(string path)
        {
            string name = Path.GetFileName(path);
            KFSettings.Instance.AddPath(path, name);
            this.LoadPaths();
        }

        public void RemovePath(int index)
        {
            KFSettings.Instance.RemovePath(index);
            this.LoadPaths();
        }

        public void RenamePath(int index, string newName)
        {
            KFSettings.Instance.RenamePath(index, newName);
            this.LoadPaths();
        }

        private void PathsControl_Load(object sender, EventArgs e)
        {
            this.LoadPaths();
            this.RemoveButton.Enabled = false;
            this.RenameButton.Enabled = false;
            this.SelectButton.Enabled = false;
            this.RenameBox.Enabled = false;
            this.PathsTable.ClearSelection();
            this.PathsTable.CurrentCell = null;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "Select a KSP install folder";
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                this.AddPath(dialog.SelectedPath);
            }
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            if (this.PathsTable.SelectedRows.Count > 0)
            {
                KFSettings.Instance.CurrentPathIndex = this.PathsTable.SelectedRows[0].Index;
                this.Close();
            }
        }

        private void PathsTable_SelectionChanged(object sender, EventArgs e)
        {
            if (this.PathsTable.SelectedRows.Count > 0)
            {
                this.RemoveButton.Enabled = true;
                this.RenameButton.Enabled = true;
                this.SelectButton.Enabled = true;
                this.RenameBox.Enabled = true;
            }
            else
            {
                this.RemoveButton.Enabled = false;
                this.RenameButton.Enabled = false;
                this.SelectButton.Enabled = false;
                this.RenameBox.Enabled = false;
            }
        }

        private void PathsTable_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DataGridView.HitTestInfo hit = this.PathsTable.HitTest(e.X, e.Y);
                if (hit.Type == DataGridViewHitTestType.None)
                {
                    this.PathsTable.ClearSelection();
                    this.PathsTable.CurrentCell = null;
                }
            }
        }

        private void PathsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm.Instance.LoadGameDatabase();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (this.PathsTable.SelectedRows.Count > 0)
            {
                this.RemovePath(this.PathsTable.SelectedRows[0].Index);
            }
        }

        private void RenameButton_Click(object sender, EventArgs e)
        {
            if (this.PathsTable.SelectedRows.Count > 0)
            {
                if (this.RenameBox.Text.Length > 0)
                {
                    this.RenamePath(this.PathsTable.SelectedRows[0].Index, this.RenameBox.Text);
                    this.RenameBox.Text = string.Empty;
                }
            }
        }
    }
}
