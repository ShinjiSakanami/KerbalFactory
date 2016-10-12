namespace KerbalFactory.Views
{
    partial class AboutForm
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
            this.ReadmeLink = new System.Windows.Forms.LinkLabel();
            this.ForumLink = new System.Windows.Forms.LinkLabel();
            this.LicenseLink = new System.Windows.Forms.LinkLabel();
            this.SourceLink = new System.Windows.Forms.LinkLabel();
            this.AuthorLink = new System.Windows.Forms.LinkLabel();
            this.AuthorLabel = new System.Windows.Forms.Label();
            this.VersionLabel = new System.Windows.Forms.Label();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ReadmeLink
            // 
            this.ReadmeLink.Location = new System.Drawing.Point(102, 117);
            this.ReadmeLink.Name = "ReadmeLink";
            this.ReadmeLink.Size = new System.Drawing.Size(90, 23);
            this.ReadmeLink.TabIndex = 7;
            this.ReadmeLink.TabStop = true;
            this.ReadmeLink.Text = "Readme";
            this.ReadmeLink.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ReadmeLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ReadmeLink_LinkClicked);
            // 
            // ForumLink
            // 
            this.ForumLink.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ForumLink.Location = new System.Drawing.Point(282, 117);
            this.ForumLink.Name = "ForumLink";
            this.ForumLink.Size = new System.Drawing.Size(90, 23);
            this.ForumLink.TabIndex = 6;
            this.ForumLink.TabStop = true;
            this.ForumLink.Text = "Forum Thread";
            this.ForumLink.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ForumLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ForumLink_LinkClicked);
            // 
            // LicenseLink
            // 
            this.LicenseLink.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LicenseLink.Location = new System.Drawing.Point(192, 117);
            this.LicenseLink.Name = "LicenseLink";
            this.LicenseLink.Size = new System.Drawing.Size(90, 23);
            this.LicenseLink.TabIndex = 5;
            this.LicenseLink.TabStop = true;
            this.LicenseLink.Text = "License";
            this.LicenseLink.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LicenseLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LicenseLink_LinkClicked);
            // 
            // SourceLink
            // 
            this.SourceLink.Location = new System.Drawing.Point(12, 117);
            this.SourceLink.Name = "SourceLink";
            this.SourceLink.Size = new System.Drawing.Size(90, 23);
            this.SourceLink.TabIndex = 4;
            this.SourceLink.TabStop = true;
            this.SourceLink.Text = "Source";
            this.SourceLink.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SourceLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.SourceLink_LinkClicked);
            // 
            // AuthorLink
            // 
            this.AuthorLink.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AuthorLink.Location = new System.Drawing.Point(180, 70);
            this.AuthorLink.Name = "AuthorLink";
            this.AuthorLink.Size = new System.Drawing.Size(180, 23);
            this.AuthorLink.TabIndex = 3;
            this.AuthorLink.TabStop = true;
            this.AuthorLink.Text = "www.shinsaka.com";
            this.AuthorLink.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.AuthorLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.AuthorLink_LinkClicked);
            // 
            // AuthorLabel
            // 
            this.AuthorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AuthorLabel.Location = new System.Drawing.Point(24, 70);
            this.AuthorLabel.Name = "AuthorLabel";
            this.AuthorLabel.Size = new System.Drawing.Size(180, 23);
            this.AuthorLabel.TabIndex = 2;
            this.AuthorLabel.Text = "By Shinji Sakanami";
            this.AuthorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // VersionLabel
            // 
            this.VersionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VersionLabel.Location = new System.Drawing.Point(12, 32);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(360, 23);
            this.VersionLabel.TabIndex = 1;
            this.VersionLabel.Text = "Version";
            this.VersionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TitleLabel
            // 
            this.TitleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.Location = new System.Drawing.Point(12, 9);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(360, 23);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "KerbalFactory";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 161);
            this.Controls.Add(this.ReadmeLink);
            this.Controls.Add(this.ForumLink);
            this.Controls.Add(this.LicenseLink);
            this.Controls.Add(this.SourceLink);
            this.Controls.Add(this.AuthorLink);
            this.Controls.Add(this.AuthorLabel);
            this.Controls.Add(this.VersionLabel);
            this.Controls.Add(this.TitleLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this.Load += new System.EventHandler(this.AboutForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label VersionLabel;
        private System.Windows.Forms.Label AuthorLabel;
        private System.Windows.Forms.LinkLabel AuthorLink;
        private System.Windows.Forms.LinkLabel SourceLink;
        private System.Windows.Forms.LinkLabel LicenseLink;
        private System.Windows.Forms.LinkLabel ForumLink;
        private System.Windows.Forms.LinkLabel ReadmeLink;
    }
}