namespace KerbalFactory.Views
{
    partial class MainForm
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

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectKSPPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openKSPDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.partEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resourceEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moduleEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.PartsTabPage = new System.Windows.Forms.TabPage();
            this.PartsTable = new KerbalFactory.Views.TableControl();
            this.ResourcesTabPage = new System.Windows.Forms.TabPage();
            this.ResourcesTable = new KerbalFactory.Views.TableControl();
            this.LogTabPage = new System.Windows.Forms.TabPage();
            this.LogControl = new KerbalFactory.Views.LogControl();
            this.MenuStrip.SuspendLayout();
            this.TabControl.SuspendLayout();
            this.PartsTabPage.SuspendLayout();
            this.ResourcesTabPage.SuspendLayout();
            this.LogTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // StatusStrip
            // 
            this.StatusStrip.Location = new System.Drawing.Point(0, 539);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(784, 22);
            this.StatusStrip.TabIndex = 0;
            this.StatusStrip.Text = "statusStrip1";
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(784, 24);
            this.MenuStrip.TabIndex = 1;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectKSPPathToolStripMenuItem,
            this.refreshDataToolStripMenuItem,
            this.openKSPDirectoryToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // selectKSPPathToolStripMenuItem
            // 
            this.selectKSPPathToolStripMenuItem.Name = "selectKSPPathToolStripMenuItem";
            this.selectKSPPathToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.selectKSPPathToolStripMenuItem.Text = "Select KSP Path";
            this.selectKSPPathToolStripMenuItem.Click += new System.EventHandler(this.selectKSPPathToolStripMenuItem_Click);
            // 
            // refreshDataToolStripMenuItem
            // 
            this.refreshDataToolStripMenuItem.Name = "refreshDataToolStripMenuItem";
            this.refreshDataToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.refreshDataToolStripMenuItem.Text = "Refresh Data";
            this.refreshDataToolStripMenuItem.Click += new System.EventHandler(this.refreshDataToolStripMenuItem_Click);
            // 
            // openKSPDirectoryToolStripMenuItem
            // 
            this.openKSPDirectoryToolStripMenuItem.Name = "openKSPDirectoryToolStripMenuItem";
            this.openKSPDirectoryToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.openKSPDirectoryToolStripMenuItem.Text = "Open KSP Directory";
            this.openKSPDirectoryToolStripMenuItem.Click += new System.EventHandler(this.openKSPDirectoryToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(174, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.partEditorToolStripMenuItem,
            this.resourceEditorToolStripMenuItem,
            this.moduleEditorToolStripMenuItem,
            this.toolStripSeparator2,
            this.settingsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // partEditorToolStripMenuItem
            // 
            this.partEditorToolStripMenuItem.Name = "partEditorToolStripMenuItem";
            this.partEditorToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.partEditorToolStripMenuItem.Text = "Part Editor";
            // 
            // resourceEditorToolStripMenuItem
            // 
            this.resourceEditorToolStripMenuItem.Name = "resourceEditorToolStripMenuItem";
            this.resourceEditorToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.resourceEditorToolStripMenuItem.Text = "Resource Editor";
            // 
            // moduleEditorToolStripMenuItem
            // 
            this.moduleEditorToolStripMenuItem.Name = "moduleEditorToolStripMenuItem";
            this.moduleEditorToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.moduleEditorToolStripMenuItem.Text = "Module Editor";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(153, 6);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.PartsTabPage);
            this.TabControl.Controls.Add(this.ResourcesTabPage);
            this.TabControl.Controls.Add(this.LogTabPage);
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.Location = new System.Drawing.Point(0, 24);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(784, 515);
            this.TabControl.TabIndex = 2;
            // 
            // PartsTabPage
            // 
            this.PartsTabPage.Controls.Add(this.PartsTable);
            this.PartsTabPage.Location = new System.Drawing.Point(4, 22);
            this.PartsTabPage.Name = "PartsTabPage";
            this.PartsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.PartsTabPage.Size = new System.Drawing.Size(776, 489);
            this.PartsTabPage.TabIndex = 0;
            this.PartsTabPage.Text = "Parts";
            // 
            // PartsTable
            // 
            this.PartsTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PartsTable.Location = new System.Drawing.Point(3, 3);
            this.PartsTable.Name = "PartsTable";
            this.PartsTable.Size = new System.Drawing.Size(770, 483);
            this.PartsTable.TabIndex = 0;
            // 
            // ResourcesTabPage
            // 
            this.ResourcesTabPage.Controls.Add(this.ResourcesTable);
            this.ResourcesTabPage.Location = new System.Drawing.Point(4, 22);
            this.ResourcesTabPage.Name = "ResourcesTabPage";
            this.ResourcesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ResourcesTabPage.Size = new System.Drawing.Size(776, 489);
            this.ResourcesTabPage.TabIndex = 1;
            this.ResourcesTabPage.Text = "Resources";
            // 
            // ResourcesTable
            // 
            this.ResourcesTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResourcesTable.Location = new System.Drawing.Point(3, 3);
            this.ResourcesTable.Name = "ResourcesTable";
            this.ResourcesTable.Size = new System.Drawing.Size(770, 483);
            this.ResourcesTable.TabIndex = 0;
            // 
            // LogTabPage
            // 
            this.LogTabPage.Controls.Add(this.LogControl);
            this.LogTabPage.Location = new System.Drawing.Point(4, 22);
            this.LogTabPage.Name = "LogTabPage";
            this.LogTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.LogTabPage.Size = new System.Drawing.Size(776, 489);
            this.LogTabPage.TabIndex = 2;
            this.LogTabPage.Text = "Log";
            // 
            // LogControl
            // 
            this.LogControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogControl.Location = new System.Drawing.Point(3, 3);
            this.LogControl.Name = "LogControl";
            this.LogControl.Size = new System.Drawing.Size(770, 483);
            this.LogControl.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.TabControl);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.MenuStrip);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.Text = "KerbalFactory";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.TabControl.ResumeLayout(false);
            this.PartsTabPage.ResumeLayout(false);
            this.ResourcesTabPage.ResumeLayout(false);
            this.LogTabPage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectKSPPathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openKSPDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem partEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resourceEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moduleEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage PartsTabPage;
        private System.Windows.Forms.TabPage ResourcesTabPage;
        private System.Windows.Forms.TabPage LogTabPage;
        private LogControl LogControl;
        private TableControl PartsTable;
        private TableControl ResourcesTable;
        private System.Windows.Forms.ToolStripMenuItem refreshDataToolStripMenuItem;
    }
}

