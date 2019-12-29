using System;
using System.Configuration;

namespace UFIDA.U9.Cust.Pub.WS.U9Action.Configuration
{
    [ConfigurationCollection(typeof (U9ActionSection), AddItemName = "U9Action")]
    public class U9ActionSectionCollection : ConfigurationElementCollection
    {
        public U9ActionSectionCollection()
        {
            AddElementName = "U9Action";
        }

        protected override string ElementName
        {
            get { return "U9Action"; }
        }

        public U9ActionSection this[int index]
        {
            get { return (U9ActionSection) BaseGet(index); }
        }

        public new U9ActionSection this[string key]
        {
            get { return (U9ActionSection) BaseGet(key); }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new U9ActionSection();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException();
            }
            return ((U9ActionSection) element).Type;
        }

        public void Add(U9ActionSection e)
        {
            BaseAdd(e);
        }

        public void Remove(U9ActionSection e)
        {
            if (e != null)
            {
                BaseRemove(e.Type);
            }
        }

        public void Remove(string key)
        {
            BaseRemove(key);
        }

        public void Clear()
        {
            BaseClear();
        }
    }
}