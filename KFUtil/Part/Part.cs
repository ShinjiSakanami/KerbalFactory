using System;
using System.Collections.Generic;

namespace KFUtil
{
    public class Part
    {
        public enum PartCategory
        {
            none = -1,
            Propulsion,
            Control,
            Structural,
            Aero,
            Utility,
            Science,
            Pods,
            FuelTank,
            Engine,
            Communication,
            Electrical,
            Ground,
            Thermal,
            Payload,
            Coupling
        }

        public enum DragModel
        {
            DEFAULT,
            CONIC,
            CYLINDRICAL,
            SPHERICAL,
            CUBE,
            NONE
        }

        private string _name;

        private string _manufacturer;

        private string _author;

        private string _title;

        private string _description;

        private PartCategory _category;

        private string _techRequired;

        private int _entryCost;

        private double _cost;

        private string _bulkheadProfiles;

        private string _tags;

        private double _mass;

        private Part.DragModel _dragModelType;

        private double _maximumDrag;

        private double _minimumDrag;

        private double _angularDrag;

        private double _crashTolerance;

        private double _maxTemp;

        private double _skinMaxTemp;

        private string _partUrl;

        private ConfigNode _internalConfig;

        private ConfigNode _config;

        private string _configFileFullName;

        private UrlConfig _urlConfig;

        PartResourceList _resources;

        public string Name
        {
            get
            {
                return this._name;
            }
        }

        public string Manufacturer
        {
            get
            {
                return this._manufacturer;
            }
            set
            {
                this._manufacturer = value;
            }
        }

        public string Author
        {
            get
            {
                return this._author;
            }
            set
            {
                this._author = value;
            }
        }

        public string Title
        {
            get
            {
                return this._title;
            }
            set
            {
                this._title = value;
            }
        }

        public string Description
        {
            get
            {
                return this._description;
            }
            set
            {
                this._description = value;
            }
        }

        public PartCategory Category
        {
            get
            {
                return this._category;
            }
            set
            {
                this._category = value;
            }
        }

        public string TechRequired
        {
            get
            {
                return this._techRequired;
            }
            set
            {
                this._techRequired = value;
            }
        }

        public int EntryCost
        {
            get
            {
                return this._entryCost;
            }
            set
            {
                this._entryCost = value;
            }
        }

        public double Cost
        {
            get
            {
                return this._cost;
            }
            set
            {
                this._cost = value;
            }
        }

        public string Tags
        {
            get
            {
                return this._tags;
            }
            set
            {
                this._tags = value;
            }
        }

        public string BulkheadProfiles
        {
            get
            {
                return this._bulkheadProfiles;
            }
            set
            {
                this._bulkheadProfiles = value;
            }
        }

        public double Mass
        {
            get
            {
                return this._mass;
            }
            set
            {
                this._mass = value;
            }
        }

        public Part.DragModel DragModelType
        {
            get
            {
                return this._dragModelType;
            }
            set
            {
                this._dragModelType = value;
            }
        }

        public double MaximumDrag
        {
            get
            {
                return this._maximumDrag;
            }
            set
            {
                this._maximumDrag = value;
            }
        }

        public double MinimumDrag
        {
            get
            {
                return this._minimumDrag;
            }
            set
            {
                this._minimumDrag = value;
            }
        }

        public double AngularDrag
        {
            get
            {
                return this._angularDrag;
            }
            set
            {
                this._angularDrag = value;
            }
        }

        public double CrashTolerance
        {
            get
            {
                return this._crashTolerance;
            }
            set
            {
                this._crashTolerance = value;
            }
        }

        public double MaxTemp
        {
            get
            {
                return this._maxTemp;
            }
            set
            {
                this._maxTemp = value;
            }
        }

        public double SkinMaxTemp
        {
            get
            {
                return this._skinMaxTemp;
            }
            set
            {
                this._skinMaxTemp = value;
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

        public string PartUrl
        {
            get
            {
                return this._partUrl;
            }
        }

        public string ConfigFileFullName
        {
            get
            {
                return this._configFileFullName;
            }
        }

        public PartResourceList Resources
        {
            get
            {
                return this._resources;
            }
        }

        public Part()
        {
            this.Init();
        }

        private void Init()
        {
            this._name = "unknownPart";
            this._author = "Unknown";
            this._title = "Unknown Mystery Component";
            this._manufacturer = "Found lying by the side of the road";
            this._description = "Nothing is really known about this thing. Use it at your own risk.";
            this._internalConfig = new ConfigNode();
            this._techRequired = string.Empty;
            this._bulkheadProfiles = string.Empty;
            this._tags = "*";
            this._mass = 2.0;
            this._dragModelType = Part.DragModel.CUBE;
            this._maximumDrag = 0.1;
            this._minimumDrag = 0.1;
            this._angularDrag = 2.0;
            this._crashTolerance = 9.0;
            this._maxTemp = 2000;
            this._skinMaxTemp = -1;
            this._resources = new PartResourceList(this);
        }

        public void Load(UrlConfig urlConfig, ConfigNode node)
        {
            this._partUrl = urlConfig.Url;
            this._urlConfig = urlConfig;
            this._configFileFullName = urlConfig.Parent.FullPath;
            this.Load(node);
        }

        public void Load(ConfigNode node)
        {
            this._config = node;
            this._name = node.GetValue("name");
            if (node.HasValue("author"))
            {
                this._author = node.GetValue("author");
            }
            if (node.HasValue("title"))
            {
                this._title = node.GetValue("title");
            }
            if (node.HasValue("manufacturer"))
            {
                this._manufacturer = node.GetValue("manufacturer");
            }
            if (node.HasValue("TechRequired"))
            {
                this._techRequired = node.GetValue("TechRequired");
            }
            if (node.HasValue("description"))
            {
                this._description = node.GetValue("description");
            }
            if (node.HasValue("category"))
            {
                this._category = (Part.PartCategory)((int)Enum.Parse(typeof(Part.PartCategory), node.GetValue("category")));
            }
            if (node.HasValue("entryCost"))
            {
                this._entryCost = ConfigNode.ParseInt(node.GetValue("entryCost"));
            }
            if (node.HasValue("cost"))
            {
                this._cost = ConfigNode.ParseDouble(node.GetValue("cost"));
            }
            if (node.HasValue("mass"))
            {
                this._mass = ConfigNode.ParseDouble(node.GetValue("mass"));
            }
            if (node.HasValue("dragModelType"))
            {
                this._dragModelType = (Part.DragModel)((int)Enum.Parse(typeof(Part.DragModel), node.GetValue("dragModelType").ToUpper()));
            }
            if (node.HasValue("maximum_drag"))
            {
                this._maximumDrag = ConfigNode.ParseDouble(node.GetValue("maximum_drag"));
            }
            if (node.HasValue("minimum_drag"))
            {
                this._minimumDrag = ConfigNode.ParseDouble(node.GetValue("minimum_drag"));
            }
            if (node.HasValue("angularDrag"))
            {
                this._angularDrag = ConfigNode.ParseDouble(node.GetValue("angularDrag"));
            }
            if (node.HasValue("crashTolerance"))
            {
                this._crashTolerance = ConfigNode.ParseDouble(node.GetValue("crashTolerance"));
            }
            if (node.HasValue("maxTemp"))
            {
                this._maxTemp = ConfigNode.ParseDouble(node.GetValue("maxTemp"));
            }
            if (node.HasValue("skinMaxTemp"))
            {
                this._skinMaxTemp = ConfigNode.ParseDouble(node.GetValue("skinMaxTemp"));
            }
            ConfigNode[] resources = node.GetNodes("RESOURCE");
            int count = resources.Length;
            for (int i = 0; i < count; i++)
            {
                this._resources.Add(resources[i]);
            }
        }

        public void Save(ConfigNode node)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return this._name;
        }
    }
}
