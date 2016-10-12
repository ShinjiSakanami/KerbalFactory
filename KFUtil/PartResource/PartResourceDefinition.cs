using System;

namespace KFUtil
{
    public class PartResourceDefinition
    {
        public enum TransferMode
        {
            NONE,
            DIRECT,
            PUMP
        }

        public enum FlowMode
        {
            NO_FLOW,
            ALL_VESSEL,
            STAGE_PRIORITY_FLOW,
            STACK_PRIORITY_SEARCH,
            ALL_VESSEL_BALANCE,
            STAGE_PRIORITY_FLOW_BALANCE,
            STAGE_STACK_FLOW,
            STAGE_STACK_FLOW_BALANCE,
            NULL
        }

        private string _name;

        private int _id;

        private double _density;

        private double _volume;

        private string _abbreviation;

        private double _unitCost;

        private double _specificHeatCapacity;

        private Color _color;

        private PartResourceDefinition.FlowMode _resourceFlowMode;

        private PartResourceDefinition.TransferMode _resourceTransferMode;

        private bool _isTweakable;

        private bool _isVisible;

        private ConfigNode _config;

        private UrlConfig _urlConfig;

        private string _configFileFullName;

        private string _resourceUrl;

        public string Name
        {
            get
            {
                return this._name;
            }
        }

        public int Id
        {
            get
            {
                return this._id;
            }
        }

        public double Density
        {
            get
            {
                return this._density;
            }
            set
            {
                this._density = value;
            }
        }

        public double Volume
        {
            get
            {
                return this._volume;
            }
            set
            {
                this._volume = value;
            }
        }

        public string Abbreviation
        {
            get
            {
                return this._abbreviation;
            }
            set
            {
                this._abbreviation = value;
            }
        }

        public double UnitCost
        {
            get
            {
                return this._unitCost;
            }
            set
            {
                this._unitCost = value;
            }
        }

        public double SpecificHeatCapacity
        {
            get
            {
                return this._specificHeatCapacity;
            }
            set
            {
                this._specificHeatCapacity = value;
            }
        }

        public Color Color
        {
            get
            {
                return this._color;
            }
            set
            {
                this._color = value;
            }
        }

        public PartResourceDefinition.FlowMode ResourceFlowMode
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

        public PartResourceDefinition.TransferMode ResourceTransferMode
        {
            get
            {
                return this._resourceTransferMode;
            }
            set
            {
                this._resourceTransferMode = value;
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

        public ConfigNode Config
        {
            get
            {
                return this._config;
            }
        }

        public UrlConfig UrlConfig
        {
            get
            {
                return this._urlConfig;
            }
        }

        public string ConfigFileFullName
        {
            get
            {
                return this._configFileFullName;
            }
        }

        public string ResourceUrl
        {
            get
            {
                return this._resourceUrl;
            }
        }

        public PartResourceDefinition()
        {
            this.Init();
        }

        public PartResourceDefinition(string name)
        {
            this.Init();
            this._name = name;
            this._id = name.GetHashCode();
        }

        private void Init()
        {
            this._name = string.Empty;
            this._id = -1;
            this._density = 1.0;
            this._volume = 5.0;
            this._abbreviation = string.Empty;
            this._color = Color.White;
            this._isVisible = true;
        }

        public void Load(UrlConfig urlConfig, ConfigNode node)
        {
            this._resourceUrl = urlConfig.Url;
            this._urlConfig = urlConfig;
            this._configFileFullName = urlConfig.Parent.FullPath;
            this.Load(node);
        }

        public void Load(ConfigNode node)
        {
            this._config = node;
            this._name = node.GetValue("name");
            this._id = this._name.GetHashCode();
            if (node.HasValue("abbreviation"))
            {
                this._abbreviation = node.GetValue("abbreviation");
            }
            if (node.HasValue("density"))
            {
                this._density = ConfigNode.ParseDouble(node.GetValue("density"));
            }
            if (node.HasValue("volume"))
            {
                this._volume = ConfigNode.ParseDouble(node.GetValue("volume"));
            }
            if (node.HasValue("unitCost"))
            {
                this._unitCost = ConfigNode.ParseDouble(node.GetValue("unitCost"));
            }
            if (node.HasValue("hsp"))
            {
                this._specificHeatCapacity = ConfigNode.ParseDouble(node.GetValue("hsp"));
            }
            if (node.HasValue("isTweakable"))
            {
                this._isTweakable = ConfigNode.ParseBool(node.GetValue("isTweakable"));
            }
            if (node.HasValue("isVisible"))
            {
                this._isVisible = ConfigNode.ParseBool(node.GetValue("isVisible"));
            }
            if (node.HasValue("flowMode"))
            {
                this._resourceFlowMode = (PartResourceDefinition.FlowMode)((int)Enum.Parse(typeof(PartResourceDefinition.FlowMode), node.GetValue("flowMode")));
            }
            if (node.HasValue("transfer"))
            {
                this._resourceTransferMode = (PartResourceDefinition.TransferMode)((int)Enum.Parse(typeof(PartResourceDefinition.TransferMode), node.GetValue("transfer")));
            }
            if (node.HasValue("color"))
            {
                this._color = ConfigNode.ParseColor(node.GetValue("color"));
            }
        }

        public void Save(ConfigNode node)
        {
            node.AddValue("name", this._name);
            node.AddValue("abbreviation", this._abbreviation);
            node.AddValue("density", this._density);
            node.AddValue("volume", this._volume);
            node.AddValue("unitCost", this._unitCost);
            node.AddValue("hsp", this._specificHeatCapacity);
            node.AddValue("flowMode", this._resourceFlowMode);
            node.AddValue("transfer", this._resourceTransferMode);
            node.AddValue("isTweakable", this._isTweakable);
            if (this._isVisible != true)
            {
                node.AddValue("isVisible", this._isVisible);
            }
            if (!this._color.Equals(Color.White))
            {
                node.AddValue("color", ConfigNode.WriteColor(this._color));
            }
        }

        public override string ToString()
        {
            return this._name;
        }
    }
}
