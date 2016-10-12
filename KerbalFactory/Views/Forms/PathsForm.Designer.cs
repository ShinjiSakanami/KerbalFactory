namespace KerbalFactory.Views
{
    partial class PathsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PathsTable = new KerbalFactory.Views.KFDataGridView();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VersionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PathColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SelectButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.RenameButton = new System.Windows.Forms.Button();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.RenameBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.PathsTable)).BeginInit();
            this.SuspendLayout();
            // 
            // PathsTable
            // 
            this.PathsTable.AllowUserToAddRows = false;
            this.PathsTable.AllowUserToDeleteRows = false;
            this.PathsTable.AllowUserToResizeRows = false;
            this.PathsTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PathsTable.BackgroundColor = System.Drawing.SystemColors.Window;
            this.PathsTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.PathsTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.PathsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PathsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameColumn,
            this.VersionColumn,
            this.PathColumn});
            this.PathsTable.Location = new System.Drawing.Point(12, 12);
            this.PathsTable.MultiSelect = false;
            this.PathsTable.Name = "PathsTable";
            this.PathsTable.ReadOnly = true;
            this.PathsTable.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.PathsTable.RowHeadersVisible = false;
            this.PathsTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.PathsTable.Size = new System.Drawing.Size(460, 208);
            this.PathsTable.TabIndex = 0;
            this.PathsTable.SelectionChanged += new System.EventHandler(this.PathsTable_SelectionChanged);
            this.PathsTable.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PathsTable_MouseUp);
            // 
            // NameColumn
            // 
            this.NameColumn.HeaderText = "Name";
            this.NameColumn.Name = "NameColumn";
            this.NameColumn.ReadOnly = true;
            this.NameColumn.Width = 120;
            // 
            // VersionColumn
            // 
            this.VersionColumn.HeaderText = "Version";
            this.VersionColumn.Name = "VersionColumn";
            this.VersionColumn.ReadOnly = true;
            this.VersionColumn.Width = 80;
            // 
            // PathColumn
            // 
            this.PathColumn.HeaderText = "Path";
            this.PathColumn.Name = "PathColumn";
            this.PathColumn.ReadOnly = true;
            this.PathColumn.Width = 250;
            // 
            // SelectButton
            // 
            this.SelectButton.Location = new System.Drawing.Point(397, 226);
            this.SelectButton.Name = "SelectButton";
            this.SelectButton.Size = new System.Drawing.Size(75, 23);
            this.SelectButton.TabIndex = 5;
            this.SelectButton.Text = "Select";
            this.SelectButton.UseVisualStyleBackColor = true;
            this.SelectButton.Click += new System.EventHandler(this.SelectButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(316, 226);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 23);
            this.AddButton.TabIndex = 4;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // RenameButton
            // 
            this.RenameButton.Location = new System.Drawing.Point(154, 226);
            this.RenameButton.Name = "RenameButton";
            this.RenameButton.Size = new System.Drawing.Size(75, 23);
            this.RenameButton.TabIndex = 2;
            this.RenameButton.Text = "Rename";
            this.RenameButton.UseVisualStyleBackColor = true;
            this.RenameButton.Click += new System.EventHandler(this.RenameButton_Click);
            // 
            // RemoveButton
            // 
            this.RemoveButton.Location = new System.Drawing.Point(235, 226);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(75, 23);
            this.RemoveButton.TabIndex = 3;
            this.RemoveButton.Text = "Remove";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // RenameBox
            // 
            this.RenameBox.Location = new System.Drawing.Point(12, 228);
            this.RenameBox.Name = "RenameBox";
            this.RenameBox.Size = new System.Drawing.Size(136, 20);
            this.RenameBox.TabIndex = 1;
            // 
            // PathsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.RenameBox);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.RenameButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.SelectButton);
            this.Controls.Add(this.PathsTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PathsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select KSP Path";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PathsForm_FormClosing);
            this.Load += new System.EventHandler(this.PathsControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PathsTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KFDataGridView PathsTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn VersionColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PathColumn;
        private System.Windows.Forms.Button SelectButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button RenameButton;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.TextBox RenameBox;
    }
}