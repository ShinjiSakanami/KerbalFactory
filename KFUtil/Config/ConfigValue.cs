namespace KFUtil
{
    public class ConfigValue
    {
        private string _name;

        private string _value;

        private string _comment;

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

        public string Value
        {
            get
            {
                return _value;
            }
            set
            {
                this._value = value;
            }
        }

        public string Comment
        {
            get
            {
                return _comment;
            }
            set
            {
                this._comment = value;
            }
        }

        public ConfigValue(string name, string value)
        {
            this._name = name;
            this._value = value;
        }

        public ConfigValue(string name, string value, string comment)
        {
            this._name = name;
            this._value = value;
            this._comment = comment;
        }

        public override string ToString()
        {
            return this._name + " = " + this._value;
        }
    }
}
