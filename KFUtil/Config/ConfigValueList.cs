using System.Collections;
using System.Collections.Generic;

namespace KFUtil
{
    public class ConfigValueList : IEnumerable, IEnumerable<ConfigValue>
    {
        private List<ConfigValue> _values;

        public ConfigValue this[int index]
        {
            get
            {
                return this._values[index];
            }
        }

        public int Count
        {
            get
            {
                return this._values.Count;
            }
        }

        public ConfigValueList()
        {
            this._values = new List<ConfigValue>();
        }

        public void Add(ConfigValue v)
        {
            this._values.Add(v);
        }

        public string GetValue(string name, int index)
        {
            int num = 0;
            int count = this._values.Count;
            for (int i = 0; i < count; i++)
            {
                ConfigValue value = this._values[i];
                if (value.Name == name)
                {
                    if (num == index)
                    {
                        return value.Value;
                    }
                    num++;
                }
            }
            return null;
        }

        public string GetValue(string name)
        {
            return this.GetValue(name, 0);
        }

        public string[] GetValues()
        {
            List<string> list = new List<string>();
            int count = this._values.Count;
            for (int i = 0; i < count; i++)
            {
                ConfigValue value = this._values[i];
                list.Add(value.Value);
            }
            return list.ToArray();
        }

        public string[] GetValues(string name)
        {
            List<string> list = new List<string>();
            int count = this._values.Count;
            for (int i = 0; i < count; i++)
            {
                ConfigValue value = this._values[i];
                if (value.Name == name)
                {
                    list.Add(value.Value);
                }
            }
            return list.ToArray();
        }

        public string[] GetValuesStartWith(string name)
        {
            List<string> list = new List<string>();
            int count = this._values.Count;
            for (int i = 0; i < count; i++)
            {
                ConfigValue value = this._values[i];
                if (value.Name.StartsWith(name))
                {
                    list.Add(value.Value);
                }
            }
            return list.ToArray();
        }

        public bool SetValue(string name, string newValue, string newComment, int index, bool createIfNotFound = false)
        {
            int num = 0;
            int count = this._values.Count;
            for (int i = 0; i < count; i++)
            {
                ConfigValue value = this._values[i];
                if (value.Name == name)
                {
                    if (num == index)
                    {
                        value.Value = newValue;
                        if (!string.IsNullOrEmpty(newComment))
                        {
                            value.Comment = newComment;
                        }
                        return true;
                    }
                    num++;
                }
            }
            if (createIfNotFound)
            {
                this._values.Add(new ConfigValue(name, newValue, newComment));
                return true;
            }
            return false;
        }

        public bool SetValue(string name, string newValue, string newComment, bool createIfNotFound = false)
        {
            return this.SetValue(name, newValue, newComment, 0, createIfNotFound);
        }

        public bool SetValue(string name, string newValue, int index, bool createIfNotFound = false)
        {
            return this.SetValue(name, newValue, null, index, createIfNotFound);
        }

        public bool SetValue(string name, string newValue, bool createIfNotFound = false)
        {
            return this.SetValue(name, newValue, null, 0, createIfNotFound);
        }

        public void Remove(ConfigValue value)
        {
            int count = this._values.Count;
            for (int i = count - 1; i >= 0; i--)
            {
                if (this._values[i] == value)
                {
                    this._values.RemoveAt(i);
                    return;
                }
            }
        }

        public void RemoveValue(string name)
        {
            int count = this._values.Count;
            for (int i = count - 1; i >= 0; i--)
            {
                if (this._values[i].Name == name)
                {
                    this._values.RemoveAt(i);
                    return;
                }
            }
        }

        public void RemoveValues(string name)
        {
            int count = this._values.Count;
            for (int i = count - 1; i >= 0; i--)
            {
                if (this._values[i].Name == name)
                {
                    this._values.RemoveAt(i);
                }
            }
        }

        public void RemoveValuesStartWith(string name)
        {
            int count = this._values.Count;
            for (int i = count - 1; i >= 0; i--)
            {
                if (this._values[i].Name.StartsWith(name))
                {
                    this._values.RemoveAt(i);
                }
            }
        }

        public void SortByName()
        {
            this._values.Sort((ConfigValue a, ConfigValue b) => a.Name.CompareTo(b.Name));
        }

        public bool Contains(string name)
        {
            int count = this._values.Count;
            for (int i = 0; i < count; i++)
            {
                ConfigValue value = this._values[i];
                if (value.Name == name)
                {
                    return true;
                }
            }
            return false;
        }

        public string[] DistinctNames()
        {
            List<string> list = new List<string>();
            int count = this._values.Count;
            for (int i = 0; i < count; i++)
            {
                ConfigValue value = this._values[i];
                if (!list.Contains(value.Name))
                {
                    list.Add(value.Name);
                }
            }
            return list.ToArray();
        }

        public int CountByName(string name)
        {
            int num = 0;
            int count = this._values.Count;
            for (int i = 0; i < count; i++)
            {
                ConfigValue value = this._values[i];
                if (value.Name == name)
                {
                    num++;
                }
            }
            return num;
        }

        public void Clear()
        {
            this._values.Clear();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this._values.GetEnumerator();
        }

        IEnumerator<ConfigValue> IEnumerable<ConfigValue>.GetEnumerator()
        {
            return this._values.GetEnumerator();
        }
    }
}
