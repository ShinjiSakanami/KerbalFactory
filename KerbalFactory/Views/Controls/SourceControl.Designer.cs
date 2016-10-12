namespace KerbalFactory.Views
{
    partial class SourceControl
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
            this.FilePathBox = new System.Windows.Forms.TextBox();
            this.FolderButton = new System.Windows.Forms.Button();
            this.SourceBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // FilePathBox
            // 
            this.FilePathBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FilePathBox.Location = new System.Drawing.Point(0, 6);
            this.FilePathBox.Name = "FilePathBox";
            this.FilePathBox.ReadOnly = true;
            this.FilePathBox.Size = new System.Drawing.Size(499, 20);
            this.FilePathBox.TabIndex = 0;
            // 
            // FolderButton
            // 
            this.FolderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FolderButton.Location = new System.Drawing.Point(505, 0);
            this.FolderButton.Name = "FolderButton";
            this.FolderButton.Size = new System.Drawing.Size(95, 30);
            this.FolderButton.TabIndex = 1;
            this.FolderButton.Text = "Open Folder";
            this.FolderButton.UseVisualStyleBackColor = true;
            // 
            // SourceBox
            // 
            this.SourceBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SourceBox.Location = new System.Drawing.Point(0, 32);
            this.SourceBox.Multiline = true;
            this.SourceBox.Name = "SourceBox";
            this.SourceBox.ReadOnly = true;
            this.SourceBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.SourceBox.Size = new System.Drawing.Size(600, 318);
            this.SourceBox.TabIndex = 2;
            // 
            // SourceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SourceBox);
            this.Controls.Add(this.FolderButton);
            this.Controls.Add(this.FilePathBox);
            this.Name = "SourceControl";
            this.Size = new System.Drawing.Size(600, 350);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FilePathBox;
        private System.Windows.Forms.Button FolderButton;
        private System.Windows.Forms.TextBox SourceBox;
    }
}
