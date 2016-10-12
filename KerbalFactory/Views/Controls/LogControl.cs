using System;
using System.Windows.Forms;

namespace KerbalFactory.Views
{
    public partial class LogControl : UserControl
    {
        public LogControl() : base()
        {
            this.InitializeComponent();
        }

        public void LogMessage(string msg)
        {
            this.LogTextBox.AppendText(msg + Environment.NewLine);
        }
    }
}
