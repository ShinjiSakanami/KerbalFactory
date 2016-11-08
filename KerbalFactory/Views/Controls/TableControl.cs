using System;
using System.Windows.Forms;

namespace KerbalFactory.Views
{
    public partial class TableControl : BaseControl
    {
        private bool _ignoreCheck;

        public TableControl() : base()
        {
            this.InitializeComponent();
            this.InitializeControl();
        }

        private void InitializeControl()
        {
            this.SplitContainer2.Panel2Collapsed = true;
            this.SplitContainer1.Panel1Collapsed = true;
        }

        public void Clear()
        {
            this.DataTable.Rows.Clear();
            this.DataTable.Columns.Clear();
            this.ColumnsTree.Nodes.Clear();
            this.FiltersTree.Nodes.Clear();
        }

        public void UpdateCountLabel()
        {
            int count = this.DataTable.Rows.Count;
            int countVisible = 0;
            foreach (DataGridViewRow row in this.DataTable.Rows)
            {
                if (row.Visible)
                {
                    countVisible++;
                }
            }
            this.CountLabel.Text = countVisible + "/" + count;
        }

        public DataGridViewColumn AddColumn(string text, string category, int size, bool visible = true)
        {
            this._ignoreCheck = true;
            string name = this.GetId(text);
            if (!this.DataTable.Columns.Contains(name))
            {
                this.DataTable.Columns.Add(name, text);
            }
            DataGridViewColumn column = this.DataTable.Columns[name];
            column.Width = size;
            column.Visible = visible;
            string categoryName = category.GetHashCode().ToString();
            if (!this.ColumnsTree.Nodes.ContainsKey(categoryName))
            {
                this.ColumnsTree.Nodes.Add(categoryName, category);
            }
            TreeNode node = this.ColumnsTree.Nodes[categoryName];
            if (!node.Nodes.ContainsKey(name))
            {
                node.Nodes.Add(name, text);
            }
            TreeNode node2 = node.Nodes[name];
            node2.Checked = visible;
            node2.Tag = column;
            this._ignoreCheck = false;
            return column;
        }

        public void AddFilter(string text, string[] values)
        {
            this._ignoreCheck = true;
            string name = text.GetHashCode().ToString();
            if (!this.FiltersTree.Nodes.ContainsKey(name))
            {
                this.FiltersTree.Nodes.Add(name, text);
            }
            TreeNode node = this.FiltersTree.Nodes[name];
            Array.Sort(values);
            int count = values.Length;
            
            for (int i = 0; i < count; i++)
            {
                string value = values[i];
                string key = value.GetHashCode().ToString();
                if (!node.Nodes.ContainsKey(key))
                {
                    node.Nodes.Add(key, value);
                }
                TreeNode node2 = node.Nodes[key];
                node2.Checked = true;
            }
            this._ignoreCheck = false;
        }

        public int AddRow(object[] values)
        {
            int row = this.DataTable.Rows.Add();
            int num = values.Length;
            for (int i = 0; i < num; i++)
            {
                this.AddValue(row, i, values[i]);
            }
            return row;
        }

        public void SetRows(DataGridViewRow[] rows)
        {
            this.DataTable.Rows.Clear();
            this.DataTable.Rows.AddRange(rows);
        }

        private void AddValue(int rowIndex, int cellIndex, object value)
        {
            if (this.DataTable.Rows.Count > rowIndex)
            {
                DataGridViewRow row = this.DataTable.Rows[rowIndex];
                if (row.Cells.Count > cellIndex)
                {
                    DataGridViewCell cell = row.Cells[cellIndex];
                    cell.Value = value;
                }
            }
        }

        private void FilterTable()
        {
            foreach (DataGridViewRow row in this.DataTable.Rows)
            {
                bool visible = true;
                foreach (TreeNode filter in this.FiltersTree.Nodes)
                {
                    if (!this.TestFilter(filter, row))
                    {
                        visible = false;
                        break;
                    }
                }
                if (visible)
                {
                    if (!this.TestSearch(row))
                    {
                        visible = false;
                    }
                }
                row.Visible = visible;
            }
            this.UpdateCountLabel();
        }

        private bool TestFilter(TreeNode filter, DataGridViewRow row)
        {
            if (filter.Text == "Resources")
            {
                return this.TestFilterResource(filter, row);
            }
            if (this.DataTable.Columns.Contains(filter.Name))
            {
                DataGridViewColumn column = this.DataTable.Columns[filter.Name];
                DataGridViewCell cell = row.Cells[column.Index];
                if (cell.Value != null)
                {
                    string value = cell.Value.ToString().GetHashCode().ToString();
                    if (filter.Nodes.ContainsKey(value))
                    {
                        TreeNode node = filter.Nodes[value];
                        return node.Checked;
                    }
                }
            }
            return true;
        }

        private bool TestFilterResource(TreeNode filter, DataGridViewRow row)
        {
            if (filter.Checked == true)
            {
                return true;
            }
            foreach (TreeNode node in filter.Nodes)
            {
                string name = node.Text + " (u)";
                name = this.GetId(name);
                if (this.DataTable.Columns.Contains(name))
                {
                    DataGridViewColumn column = this.DataTable.Columns[name];
                    DataGridViewCell cell = row.Cells[column.Index];
                    if (cell.Value != null)
                    {
                        string text = cell.Value.ToString();
                        double value = double.Parse(text);
                        if (value > 0 && node.Checked)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private bool TestSearch(DataGridViewRow row)
        {
            string search = this.SearchBox.Text;
            foreach (DataGridViewCell cell in row.Cells)
            {
                if (cell.Value != null)
                {
                    if (cell.Value.ToString().Contains(search))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private string GetId(string text)
        {
            return text.GetHashCode().ToString();
        }

        private void ColumnsButton_Click(object sender, EventArgs e)
        {
            this.SplitContainer2.Panel2Collapsed = !this.SplitContainer2.Panel2Collapsed;
        }

        private void FiltersButton_Click(object sender, EventArgs e)
        {
            this.SplitContainer1.Panel1Collapsed = !this.SplitContainer1.Panel1Collapsed;
        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            this.FilterTable();
        }

        private void ColumnsTree_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (!this._ignoreCheck)
            {
                DataGridViewColumn column = (DataGridViewColumn)e.Node.Tag;
                if (column != null)
                {
                    column.Visible = e.Node.Checked;
                }
            }
        }

        private void FiltersTree_AfterChildsCheck(object sender, TreeViewEventArgs e)
        {
            if (!this._ignoreCheck)
            {
                this.FilterTable();
            }
        }
    }
}
