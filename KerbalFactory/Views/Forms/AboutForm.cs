using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace KerbalFactory.Views
{
    public partial class AboutForm : BaseForm
    {
        public AboutForm()
        {
            this.InitializeComponent();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            this.VersionLabel.Text = "Version " + KFSettings.AppVersion;
            this.AuthorLink.Links.Add(0, 0, "http://www.shinsaka.com");
            this.SourceLink.Links.Add(0,0, "https://github.com/ShinjiSakanami/KerbalFactory");
            this.LicenseLink.Links.Add(0, 0, "https://github.com/ShinjiSakanami/KerbalFactory/blob/master/LICENSE.md");
            this.ReadmeLink.Links.Add(0, 0, "https://github.com/ShinjiSakanami/KerbalFactory/blob/master/README.md");
            this.ForumLink.Links.Add(0, 0, "");
        }

        private void LicenseLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(e.Link.LinkData.ToString());
        }

        private void AuthorLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(e.Link.LinkData.ToString());
        }

        private void ReadmeLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(e.Link.LinkData.ToString());
        }

        private void SourceLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(e.Link.LinkData.ToString());
        }

        private void ForumLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(e.Link.LinkData.ToString());
        }
    }
}
