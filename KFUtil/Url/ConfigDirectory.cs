namespace KFUtil
{
    public class ConfigDirectory
    {
        private string _directory;

        private string _urlRoot;

        private UrlDir.DirectoryType _type;

        public string Directory
        {
            get
            {
                return _directory;
            }
            set
            {
                this._directory = value;
            }
        }

        public string UrlRoot
        {
            get
            {
                return _urlRoot;
            }
            set
            {
                this._urlRoot = value;
            }
        }

        public UrlDir.DirectoryType Type
        {
            get
            {
                return _type;
            }
            set
            {
                this._type = value;
            }
        }

        public ConfigDirectory()
        {
            this._urlRoot = string.Empty;
            this._directory = ".";
            this._type = UrlDir.DirectoryType.Parts;
        }

        public ConfigDirectory(string urlRoot, string directory, UrlDir.DirectoryType type)
        {
            this._urlRoot = urlRoot;
            this._directory = directory;
            this._type = type;
        }
    }
}
