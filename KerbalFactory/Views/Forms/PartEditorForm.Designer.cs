namespace KerbalFactory.Views
{
    partial class PartEditorForm
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
            this.TabControl = new System.Windows.Forms.TabControl();
            this.PropertiesTabPage = new System.Windows.Forms.TabPage();
            this.ResourcesTabPage = new System.Windows.Forms.TabPage();
            this.ModulesTabPage = new System.Windows.Forms.TabPage();
            this.SourceTabPage = new System.Windows.Forms.TabPage();
            this.PartSource = new KerbalFactory.Views.SourceControl();
            this.TabControl.SuspendLayout();
            this.SourceTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.PropertiesTabPage);
            this.TabControl.Controls.Add(this.ResourcesTabPage);
            this.TabControl.Controls.Add(this.ModulesTabPage);
            this.TabControl.Controls.Add(this.SourceTabPage);
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.Location = new System.Drawing.Point(0, 0);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(704, 411);
            this.TabControl.TabIndex = 0;
            // 
            // PropertiesTabPage
            // 
            this.PropertiesTabPage.BackColor = System.Drawing.SystemColors.Control;
            this.PropertiesTabPage.Location = new System.Drawing.Point(4, 22);
            this.PropertiesTabPage.Name = "PropertiesTabPage";
            this.PropertiesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.PropertiesTabPage.Size = new System.Drawing.Size(696, 385);
            this.PropertiesTabPage.TabIndex = 0;
            this.PropertiesTabPage.Text = "Properties";
            // 
            // ResourcesTabPage
            // 
            this.ResourcesTabPage.BackColor = System.Drawing.SystemColors.Control;
            this.ResourcesTabPage.Location = new System.Drawing.Point(4, 22);
            this.ResourcesTabPage.Name = "ResourcesTabPage";
            this.ResourcesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ResourcesTabPage.Size = new System.Drawing.Size(696, 385);
            this.ResourcesTabPage.TabIndex = 1;
            this.ResourcesTabPage.Text = "Resources";
            // 
            // ModulesTabPage
            // 
            this.ModulesTabPage.BackColor = System.Drawing.SystemColors.Control;
            this.ModulesTabPage.Location = new System.Drawing.Point(4, 22);
            this.ModulesTabPage.Name = "ModulesTabPage";
            this.ModulesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ModulesTabPage.Size = new System.Drawing.Size(696, 385);
            this.ModulesTabPage.TabIndex = 2;
            this.ModulesTabPage.Text = "Modules";
            // 
            // SourceTabPage
            // 
            this.SourceTabPage.BackColor = System.Drawing.SystemColors.Control;
            this.SourceTabPage.Controls.Add(this.PartSource);
            this.SourceTabPage.Location = new System.Drawing.Point(4, 22);
            this.SourceTabPage.Name = "SourceTabPage";
            this.SourceTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.SourceTabPage.Size = new System.Drawing.Size(696, 385);
            this.SourceTabPage.TabIndex = 4;
            this.SourceTabPage.Text = "Source";
            // 
            // PartSource
            // 
            this.PartSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PartSource.Location = new System.Drawing.Point(3, 3);
            this.PartSource.Name = "PartSource";
            this.PartSource.Size = new System.Drawing.Size(690, 379);
            this.PartSource.TabIndex = 0;
            // 
            // PartEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 411);
            this.Controls.Add(this.TabControl);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PartEditorForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Part Editor";
            this.TabControl.ResumeLayout(false);
            this.SourceTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage PropertiesTabPage;
        private System.Windows.Forms.TabPage ResourcesTabPage;
        private System.Windows.Forms.TabPage ModulesTabPage;
        private System.Windows.Forms.TabPage SourceTabPage;
        private SourceControl PartSource;
    }
}