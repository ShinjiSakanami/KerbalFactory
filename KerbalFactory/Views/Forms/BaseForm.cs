using System.Windows.Forms;

namespace KerbalFactory.Views
{
    public class BaseForm : Form
    {
        public BaseForm() : base()
        {
        }

        public void InvokeIfRequired(MethodInvoker action)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(action);
            }
            else
            {
                action();
            }
        }
    }
}
