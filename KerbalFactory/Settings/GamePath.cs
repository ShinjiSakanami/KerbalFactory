namespace KerbalFactory
{
    public class GamePath
    {
        private string _fullPath;

        private string _name;

        private string _version;

        public string FullPath
        {
            get
            {
                return this._fullPath;
            }
            set
            {
                this._fullPath = value;
            }
        }

        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }

        public string Version
        {
            get
            {
                return this._version;
            }
            set
            {
                this._version = value;
            }
        }

        public GamePath(string name, string fullPath, string version)
        {
            this._name = name;
            this._fullPath = fullPath;
            this._version = version;
        }
    }
}
