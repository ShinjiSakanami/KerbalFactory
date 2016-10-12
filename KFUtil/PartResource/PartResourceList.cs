using System.Collections;
using System.Collections.Generic;

namespace KFUtil
{
    public class PartResourceList : IEnumerable, IEnumerable<PartResource>
    {
        private Dictionary<int, PartResource> _dict;

        private Part _part;

        public PartResource this[string name]
        {
            get
            {
                return this.Get(name);
            }
        }

        public PartResource this[int id]
        {
            get
            {
                return this.Get(id);
            }
        }

        public int Count
        {
            get
            {
                return this._dict.Count;
            }
        }

        public PartResourceList(Part p)
        {
            this._dict = new Dictionary<int, PartResource>();
            this._part = p;
        }

        public PartResource Add(ConfigNode node)
        {
            if (!node.HasValue("name"))
            {
                Debug.LogWarning("ConfigNode has no value 'name'");
                return null;
            }
            string name = node.GetValue("name");
            if (this.Contains(name))
            {
                Debug.LogWarning("Part already contains resource '" + name + "'");
                return null;
            }
            PartResourceDefinition def = GameDatabase.Instance.GetResourceDefinition(name);
            if (def == null)
            {
                Debug.LogWarning("Could not create PartResource of type '" + name + "'");
                return null;
            }
            PartResource res = new PartResource(this._part);
            res.SetInfo(def);
            res.Load(node);
            this._dict.Add(def.Id, res);
            return res;
        }

        public PartResource Add(PartResource res)
        {
            PartResource partResource = new PartResource(this._part);
            partResource.Copy(res);
            this._dict.Add(partResource.Info.Id, partResource);
            return partResource;
        }

        public PartResource Add(string name, double amount, double maxAmount, bool flowState, bool isTweakable, bool hideFlow, bool isVisible, PartResource.FlowMode flow)
        {
            if (this.Contains(name))
            {
                Debug.LogWarning("Part already contains resource '" + name + "'");
                return null;
            }
            PartResourceDefinition def = GameDatabase.Instance.GetResourceDefinition(name);
            if (def == null)
            {
                Debug.LogWarning("Could not create PartResource of type '" + name + "'");
                return null;
            }
            PartResource res = new PartResource(this._part);
            res.ResourceName = name;
            res.SetInfo(def);
            res.Amount = amount;
            res.MaxAmount = maxAmount;
            res.FlowState = flowState;
            res.IsTweakable = isTweakable;
            res.HideFlow = hideFlow;
            res.IsVisible = isVisible;
            res.ResourceFlowMode = flow;
            this._dict.Add(def.Id, res);
            return res;
        }

        public bool Contains(int id)
        {
            return this._dict.ContainsKey(id);
        }

        public bool Contains(string name)
        {
            return this._dict.ContainsKey(name.GetHashCode());
        }

        public PartResource Get(int id)
        {
            PartResource result;
            if (this._dict.TryGetValue(id, out result))
            {
                return result;
            }
            return null;
        }

        public PartResource Get(string name)
        {
            return this.Get(name.GetHashCode());
        }

        public bool Remove(PartResource res)
        {
            return this._dict.Remove(res.Info.Id);
        }

        public bool Remove(string name)
        {
            return this._dict.Remove(name.GetHashCode());
        }

        public bool Remove(int id)
        {
            return this._dict.Remove(id);
        }

        public void Clear()
        {
            this._dict.Clear();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this._dict.Values.GetEnumerator();
        }

        IEnumerator<PartResource> IEnumerable<PartResource>.GetEnumerator()
        {
            return this._dict.Values.GetEnumerator();
        }
    }
}
