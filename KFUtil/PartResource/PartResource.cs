using System;

namespace KFUtil
{
    public class PartResource
    {
        public enum FlowMode
        {
            None = 0,
            Out,
            In,
            Both
        }

        private PartResourceDefinition _info;

        private Part _part;

        private string _resourceName;

        private double _amount;

        private double _maxAmount;

        private bool _flowState;

        private bool _isTweakable;

        private bool _hideFlow;

        private bool _isVisible;

        private PartResource.FlowMode _resourceFlowMode;

        public PartResourceDefinition Info
        {
            get
            {
                return this._info;
            }
        }

        public Part Part
        {
            get
            {
                return this._part;
            }
        }

        public string ResourceName
        {
            get
            {
                return this._resourceName;
            }
            set
            {
                this._resourceName = value;
            }
        }

        public double Amount
        {
            get
            {
                return this._amount;
            }
            set
            {
                this._amount = value;
            }
        }

        public double MaxAmount
        {
            get
            {
                return this._maxAmount;
            }
            set
            {
                this._maxAmount = value;
            }
        }

        public bool FlowState
        {
            get
            {
                return this._flowState;
            }
            set
            {
                this._flowState = value;
            }
        }

        public bool IsTweakable
        {
            get
            {
                return this._isTweakable;
            }
            set
            {
                this._isTweakable = value;
            }
        }

        public bool HideFlow
        {
            get
            {
                return this._hideFlow;
            }
            set
            {
                this._hideFlow = value;
            }
        }

        public bool IsVisible
        {
            get
            {
                return this._isVisible;
            }
            set
            {
                this._isVisible = value;
            }
        }

        public PartResource.FlowMode ResourceFlowMode
        {
            get
            {
                return this._resourceFlowMode;
            }
            set
            {
                this._resourceFlowMode = value;
            }
        }

        public PartResource(Part p)
        {
            this._part = p;
            this.Init();
        }

        private void Init()
        {
            this._flowState = true;
            this._isVisible = true;
            this._resourceFlowMode = PartResource.FlowMode.Both;
        }

        public void Load(ConfigNode node)
        {
            if (node.HasValue("amount"))
            {
                this._amount = ConfigNode.ParseDouble(node.GetValue("amount"));
            }
            if (node.HasValue("maxAmount"))
            {
                this._maxAmount = ConfigNode.ParseDouble(node.GetValue("maxAmount"));
            }
            if (node.HasValue("flowState"))
            {
                this._flowState = ConfigNode.ParseBool(node.GetValue("flowState"));
            }
            if (node.HasValue("isTweakable"))
            {
                this._isTweakable = ConfigNode.ParseBool(node.GetValue("isTweakable"));
            }
            else
            {
                this._isTweakable = GameDatabase.Instance.GetResourceDefinition(this._resourceName).IsTweakable;
            }
            if (node.HasValue("isVisible"))
            {
                this._isVisible = ConfigNode.ParseBool(node.GetValue("isVisible"));
            }
            else
            {
                this._isVisible = GameDatabase.Instance.GetResourceDefinition(this._resourceName).IsVisible;
            }
            if (node.HasValue("hideFlow"))
            {
                this._hideFlow = ConfigNode.ParseBool(node.GetValue("hideFlow"));
            }
            if (node.HasValue("flowMode"))
            {
                this._resourceFlowMode = (PartResource.FlowMode)((int)Enum.Parse(typeof(PartResource.FlowMode), node.GetValue("flowMode")));
            }
        }

        public void Save(ConfigNode node)
        {
            node.AddValue("name", this._info.Name);
            node.AddValue("amount", this._amount);
            node.AddValue("maxAmount", this._maxAmount);
            node.AddValue("flowState", this._flowState);
            node.AddValue("isTweakable", this._isTweakable);
            node.AddValue("hideFlow", this._hideFlow);
            node.AddValue("isVisible", this._isVisible);
            node.AddValue("flowMode", this._resourceFlowMode);
        }

        public void Copy(PartResource res)
        {
            this._info = res.Info;
            this._resourceName = res.ResourceName;
            this._amount = res.Amount;
            this._maxAmount = res.MaxAmount;
            this._flowState = res.FlowState;
            this._isTweakable = res.IsTweakable;
            this._isVisible = res.IsVisible;
            this._hideFlow = res.HideFlow;
            this._resourceFlowMode = res.ResourceFlowMode;
        }

        public void SetInfo(PartResourceDefinition info)
        {
            this._info = info;
            this._resourceName = info.Name;
        }

        public override string ToString()
        {
            return this._resourceName;
        }
    }
}
