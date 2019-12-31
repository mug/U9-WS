using System;
using System.Configuration;

namespace UFIDA.U9.Cust.Pub.WS.U9Context.Configuration
{
    [ConfigurationCollection(typeof (U9ContextSection), AddItemName = "U9Context")]
    public class U9ContextSectionCollection : ConfigurationElementCollection
    {
        public U9ContextSectionCollection()
        {
            AddElementName = "U9Context";
        }

        protected override string ElementName
        {
            get { return "U9Context"; }
        }

        public U9ContextSection this[int index]
        {
            get { return (U9ContextSection) BaseGet(index); }
        }

        public new U9ContextSection this[string key]
        {
            get { return (U9ContextSection) BaseGet(key); }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new U9ContextSection();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException();
            }
            return ((U9ContextSection) element).EnterpriseID;
        }

        public void Add(U9ContextSection e)
        {
            BaseAdd(e);
        }

        public void Remove(U9ContextSection e)
        {
            if (e != null)
            {
                BaseRemove(e.EnterpriseID);
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