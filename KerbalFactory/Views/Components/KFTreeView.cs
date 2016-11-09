using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace KerbalFactory.Views
{
    public delegate void AfterChildsCheck(object sender, TreeViewEventArgs e);

    // Source : http://www.codeproject.com/Articles/202435/Tri-State-Tree-View
    public class KFTreeView : TreeView
    {
        public enum CheckedState
        {
            UnInitialised = -1,
            UnChecked,
            Checked,
            Mixed
        };

        public enum TriStateStyles
        {
            Standard = 0,
            Installer
        };

        private int IgnoreClickAction = 0;

        private TriStateStyles TriStateStyle = TriStateStyles.Standard;

        public event AfterChildsCheck AfterChildsCheck;

        [Category("Tri-State Tree View")]
        [DisplayName("Style")]
        [Description("Style of the Tri-State Tree View")]
        public TriStateStyles TriStateStyleProperty
        {
            get
            {
                return this.TriStateStyle;
            }
            set
            {
                this.TriStateStyle = value;
            }
        }

        public KFTreeView() : base()
        {
            this.StateImageList = new ImageList();
            for (int i = 0; i < 3; i++)
            {
                Bitmap bmp = new Bitmap(16, 16);
                Graphics chkGraphics = Graphics.FromImage(bmp);
                switch (i)
                {
                    case 0:
                        CheckBoxRenderer.DrawCheckBox(chkGraphics, new Point(0, 1), CheckBoxState.UncheckedNormal);
                        break;
                    case 1:
                        CheckBoxRenderer.DrawCheckBox(chkGraphics, new Point(0, 1), CheckBoxState.CheckedNormal);
                        break;
                    case 2:
                        CheckBoxRenderer.DrawCheckBox(chkGraphics, new Point(0, 1), CheckBoxState.MixedNormal);
                        break;
                }
                this.StateImageList.Images.Add(bmp);
            }
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            this.CheckBoxes = false;
            this.IgnoreClickAction++;
            this.UpdateChildState(this.Nodes, (int)CheckedState.UnChecked, false, true);
            this.IgnoreClickAction--;
        }

        protected override void OnAfterCheck(TreeViewEventArgs e)
        {
            base.OnAfterCheck(e);
            if (this.IgnoreClickAction > 0)
            {
                return;
            }
            this.IgnoreClickAction++;
            TreeNode tn = e.Node;
            tn.StateImageIndex = tn.Checked ? (int)CheckedState.Checked : (int)CheckedState.UnChecked;
            this.UpdateChildState(e.Node.Nodes, e.Node.StateImageIndex, e.Node.Checked, false);
            this.UpdateParentState(e.Node.Parent);
            this.OnAfterChildsCheck(e);
            this.IgnoreClickAction--;
        }

        protected override void OnAfterExpand(TreeViewEventArgs e)
        {
            base.OnAfterExpand(e);
            this.IgnoreClickAction++;
            this.UpdateChildState(e.Node.Nodes, e.Node.StateImageIndex, e.Node.Checked, true);
            this.IgnoreClickAction--;
        }

        protected virtual void OnAfterChildsCheck(TreeViewEventArgs e)
        {
            if (AfterChildsCheck != null)
            {
                this.AfterChildsCheck(this, e);
            }
        }

        protected void UpdateChildState(TreeNodeCollection Nodes, int StateImageIndex, bool Checked, bool ChangeUninitialisedNodesOnly)
        {
            foreach (TreeNode tnChild in Nodes)
            {
                if (!ChangeUninitialisedNodesOnly || tnChild.StateImageIndex == -1)
                {
                    tnChild.StateImageIndex = StateImageIndex;
                    tnChild.Checked = Checked;
                    if (tnChild.Nodes.Count > 0)
                    {
                        this.UpdateChildState(tnChild.Nodes, StateImageIndex, Checked, ChangeUninitialisedNodesOnly);
                    }
                }
            }
        }

        protected void UpdateParentState(TreeNode tn)
        {
            if (tn == null)
            {
                return;
            }
            int OrigStateImageIndex = tn.StateImageIndex;
            int UnCheckedNodes = 0;
            int CheckedNodes = 0;
            int MixedNodes = 0;
            foreach (TreeNode tnChild in tn.Nodes)
            {
                if (tnChild.StateImageIndex == (int)CheckedState.Checked)
                {
                    CheckedNodes++;
                }
                else if (tnChild.StateImageIndex == (int)CheckedState.Mixed)
                {
                    MixedNodes++;
                    break;
                }
                else
                {
                    UnCheckedNodes++;
                }
            }
            if (this.TriStateStyle == TriStateStyles.Installer)
            {
                if (MixedNodes == 0)
                {
                    if (UnCheckedNodes == 0)
                    {
                        tn.Checked = true;
                    }
                    else
                    {
                        tn.Checked = false;
                    }
                }
            }
            if (MixedNodes > 0)
            {
                tn.StateImageIndex = (int)CheckedState.Mixed;
            }
            else if (CheckedNodes > 0 && UnCheckedNodes == 0)
            {
                if (tn.Checked)
                {
                    tn.StateImageIndex = (int)CheckedState.Checked;
                }
                else
                {
                    tn.StateImageIndex = (int)CheckedState.Mixed;
                }
            }
            else if (CheckedNodes > 0)
            {
                tn.StateImageIndex = (int)CheckedState.Mixed;
            }
            else
            {
                if (tn.Checked)
                {
                    tn.StateImageIndex = (int)CheckedState.Mixed;
                }
                else
                {
                    tn.StateImageIndex = (int)CheckedState.UnChecked;
                }
            }
            if (OrigStateImageIndex != tn.StateImageIndex && tn.Parent != null)
            {
                this.UpdateParentState(tn.Parent);
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Space)
            {
                this.SelectedNode.Checked = !this.SelectedNode.Checked;
            }
        }

        protected override void OnNodeMouseClick(TreeNodeMouseClickEventArgs e)
        {
            base.OnNodeMouseClick(e);
            TreeViewHitTestInfo info = this.HitTest(e.X, e.Y);
            if (info == null || info.Location != TreeViewHitTestLocations.StateImage)
            {
                return;
            }
            TreeNode tn = e.Node;
            tn.Checked = !tn.Checked;
        }
    }
}
