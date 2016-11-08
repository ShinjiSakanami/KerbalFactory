namespace KerbalFactory.Views
{
    partial class TableControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.LayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ToolsPanel = new System.Windows.Forms.Panel();
            this.SearchLabel = new System.Windows.Forms.Label();
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.CountLabel = new System.Windows.Forms.Label();
            this.ColumnsButton = new System.Windows.Forms.Button();
            this.FiltersButton = new System.Windows.Forms.Button();
            this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.FiltersTree = new KerbalFactory.Views.KFTreeView();
            this.SplitContainer2 = new System.Windows.Forms.SplitContainer();
            this.DataTable = new KerbalFactory.Views.KFDataGridView();
            this.ColumnsTree = new KerbalFactory.Views.KFTreeView();
            this.LayoutPanel.SuspendLayout();
            this.ToolsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).BeginInit();
            this.SplitContainer1.Panel1.SuspendLayout();
            this.SplitContainer1.Panel2.SuspendLayout();
            this.SplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer2)).BeginInit();
            this.SplitContainer2.Panel1.SuspendLayout();
            this.SplitContainer2.Panel2.SuspendLayout();
            this.SplitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable)).BeginInit();
            this.SuspendLayout();
            // 
            // LayoutPanel
            // 
            this.LayoutPanel.ColumnCount = 1;
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.LayoutPanel.Controls.Add(this.ToolsPanel, 0, 0);
            this.LayoutPanel.Controls.Add(this.SplitContainer1, 0, 1);
            this.LayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.LayoutPanel.Name = "LayoutPanel";
            this.LayoutPanel.RowCount = 2;
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.LayoutPanel.Size = new System.Drawing.Size(640, 480);
            this.LayoutPanel.TabIndex = 0;
            // 
            // ToolsPanel
            // 
            this.ToolsPanel.Controls.Add(this.SearchLabel);
            this.ToolsPanel.Controls.Add(this.SearchBox);
            this.ToolsPanel.Controls.Add(this.CountLabel);
            this.ToolsPanel.Controls.Add(this.ColumnsButton);
            this.ToolsPanel.Controls.Add(this.FiltersButton);
            this.ToolsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ToolsPanel.Location = new System.Drawing.Point(3, 3);
            this.ToolsPanel.Name = "ToolsPanel";
            this.ToolsPanel.Size = new System.Drawing.Size(634, 30);
            this.ToolsPanel.TabIndex = 0;
            // 
            // SearchLabel
            // 
            this.SearchLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchLabel.AutoSize = true;
            this.SearchLabel.Location = new System.Drawing.Point(366, 9);
            this.SearchLabel.Name = "SearchLabel";
            this.SearchLabel.Size = new System.Drawing.Size(41, 13);
            this.SearchLabel.TabIndex = 4;
            this.SearchLabel.Text = "Search";
            // 
            // SearchBox
            // 
            this.SearchBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchBox.Location = new System.Drawing.Point(413, 6);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(140, 20);
            this.SearchBox.TabIndex = 3;
            this.SearchBox.TextChanged += new System.EventHandler(this.SearchBox_TextChanged);
            // 
            // CountLabel
            // 
            this.CountLabel.AutoSize = true;
            this.CountLabel.Location = new System.Drawing.Point(81, 9);
            this.CountLabel.Name = "CountLabel";
            this.CountLabel.Size = new System.Drawing.Size(24, 13);
            this.CountLabel.TabIndex = 2;
            this.CountLabel.Text = "0/0";
            // 
            // ColumnsButton
            // 
            this.ColumnsButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ColumnsButton.Location = new System.Drawing.Point(559, 0);
            this.ColumnsButton.Name = "ColumnsButton";
            this.ColumnsButton.Size = new System.Drawing.Size(75, 30);
            this.ColumnsButton.TabIndex = 1;
            this.ColumnsButton.Text = "Columns";
            this.ColumnsButton.UseVisualStyleBackColor = true;
            this.ColumnsButton.Click += new System.EventHandler(this.ColumnsButton_Click);
            // 
            // FiltersButton
            // 
            this.FiltersButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.FiltersButton.Location = new System.Drawing.Point(0, 0);
            this.FiltersButton.Name = "FiltersButton";
            this.FiltersButton.Size = new System.Drawing.Size(75, 30);
            this.FiltersButton.TabIndex = 0;
            this.FiltersButton.Text = "Filters";
            this.FiltersButton.UseVisualStyleBackColor = true;
            this.FiltersButton.Click += new System.EventHandler(this.FiltersButton_Click);
            // 
            // SplitContainer1
            // 
            this.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.SplitContainer1.Location = new System.Drawing.Point(3, 39);
            this.SplitContainer1.Name = "SplitContainer1";
            // 
            // SplitContainer1.Panel1
            // 
            this.SplitContainer1.Panel1.Controls.Add(this.FiltersTree);
            this.SplitContainer1.Panel1MinSize = 150;
            // 
            // SplitContainer1.Panel2
            // 
            this.SplitContainer1.Panel2.Controls.Add(this.SplitContainer2);
            this.SplitContainer1.Panel2MinSize = 250;
            this.SplitContainer1.Size = new System.Drawing.Size(634, 438);
            this.SplitContainer1.SplitterDistance = 150;
            this.SplitContainer1.TabIndex = 1;
            // 
            // FiltersTree
            // 
            this.FiltersTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FiltersTree.Location = new System.Drawing.Point(0, 0);
            this.FiltersTree.Name = "FiltersTree";
            this.FiltersTree.Size = new System.Drawing.Size(150, 438);
            this.FiltersTree.TabIndex = 0;
            this.FiltersTree.TriStateStyleProperty = KerbalFactory.Views.KFTreeView.TriStateStyles.Installer;
            this.FiltersTree.AfterChildsCheck += new KerbalFactory.Views.AfterChildsCheck(this.FiltersTree_AfterChildsCheck);
            // 
            // SplitContainer2
            // 
            this.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.SplitContainer2.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer2.Name = "SplitContainer2";
            // 
            // SplitContainer2.Panel1
            // 
            this.SplitContainer2.Panel1.Controls.Add(this.DataTable);
            this.SplitContainer2.Panel1MinSize = 100;
            // 
            // SplitContainer2.Panel2
            // 
            this.SplitContainer2.Panel2.Controls.Add(this.ColumnsTree);
            this.SplitContainer2.Panel2MinSize = 150;
            this.SplitContainer2.Size = new System.Drawing.Size(480, 438);
            this.SplitContainer2.SplitterDistance = 326;
            this.SplitContainer2.TabIndex = 0;
            // 
            // DataTable
            // 
            this.DataTable.AllowUserToAddRows = false;
            this.DataTable.AllowUserToDeleteRows = false;
            this.DataTable.AllowUserToOrderColumns = true;
            this.DataTable.AllowUserToResizeRows = false;
            this.DataTable.BackgroundColor = System.Drawing.SystemColors.Window;
            this.DataTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.DataTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataTable.Location = new System.Drawing.Point(0, 0);
            this.DataTable.MultiSelect = false;
            this.DataTable.Name = "DataTable";
            this.DataTable.ReadOnly = true;
            this.DataTable.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DataTable.RowHeadersVisible = false;
            this.DataTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataTable.Size = new System.Drawing.Size(326, 438);
            this.DataTable.TabIndex = 4;
            // 
            // ColumnsTree
            // 
            this.ColumnsTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ColumnsTree.Location = new System.Drawing.Point(0, 0);
            this.ColumnsTree.Name = "ColumnsTree";
            this.ColumnsTree.Size = new System.Drawing.Size(150, 438);
            this.ColumnsTree.TabIndex = 0;
            this.ColumnsTree.TriStateStyleProperty = KerbalFactory.Views.KFTreeView.TriStateStyles.Installer;
            this.ColumnsTree.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.ColumnsTree_AfterCheck);
            // 
            // TableControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LayoutPanel);
            this.Name = "TableControl";
            this.Size = new System.Drawing.Size(640, 480);
            this.LayoutPanel.ResumeLayout(false);
            this.ToolsPanel.ResumeLayout(false);
            this.ToolsPanel.PerformLayout();
            this.SplitContainer1.Panel1.ResumeLayout(false);
            this.SplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).EndInit();
            this.SplitContainer1.ResumeLayout(false);
            this.SplitContainer2.Panel1.ResumeLayout(false);
            this.SplitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer2)).EndInit();
            this.SplitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel LayoutPanel;
        private System.Windows.Forms.Panel ToolsPanel;
        private System.Windows.Forms.Button FiltersButton;
        private System.Windows.Forms.SplitContainer SplitContainer1;
        private KFTreeView FiltersTree;
        private System.Windows.Forms.SplitContainer SplitContainer2;
        private KFTreeView ColumnsTree;
        private KFDataGridView DataTable;
        private System.Windows.Forms.Button ColumnsButton;
        private System.Windows.Forms.Label CountLabel;
        private System.Windows.Forms.TextBox SearchBox;
        private System.Windows.Forms.Label SearchLabel;
    }
}
