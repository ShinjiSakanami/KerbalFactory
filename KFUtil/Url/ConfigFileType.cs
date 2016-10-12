using System.Collections;
using System.Collections.Generic;

namespace KFUtil
{
    public class ConfigFileType : IEnumerable
    {
        private UrlFile.FileType _type;

        private List<string> _extensions;

        public UrlFile.FileType Type
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

        public List<string> Extensions
        {
            get
            {
                return _extensions;
            }
        }

        public int Count
        {
            get
            {
                return this._extensions.Count;
            }
        }

        public ConfigFileType()
        {
            this._type = UrlFile.FileType.Unknown;
            this._extensions = new List<string>();
        }

        public ConfigFileType(UrlFile.FileType fileType)
        {
            this._type = fileType;
            this._extensions = new List<string>();
        }

        public ConfigFileType(UrlFile.FileType fileType, string[] extensions)
        {
            this._type = fileType;
            this._extensions = new List<string>(extensions);
        }

        public IEnumerator GetEnumerator()
        {
            return this._extensions.GetEnumerator();
        }
    }
}
