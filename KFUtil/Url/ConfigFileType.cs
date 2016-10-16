using System.Collections;
using System.Collections.Generic;

namespace KFUtil
{
    public class ConfigFileType : IEnumerable
    {
        public UrlFile.FileType type;

        private List<string> _extensions;

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
            this.type = UrlFile.FileType.Unknown;
            this._extensions = new List<string>();
        }

        public ConfigFileType(UrlFile.FileType fileType)
        {
            this.type = fileType;
            this._extensions = new List<string>();
        }

        public ConfigFileType(UrlFile.FileType fileType, string[] extensions)
        {
            this.type = fileType;
            this._extensions = new List<string>(extensions);
        }

        public IEnumerator GetEnumerator()
        {
            return this._extensions.GetEnumerator();
        }
    }
}
