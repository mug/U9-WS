using System;
using System.Configuration;
using UFIDA.U9.Cust.Pub.WS.Base.Utils;

namespace UFIDA.U9.Cust.Pub.WS.U9Context.Configuration
{
    /// <summary>
    ///     U9上下文节点配置组
    /// </summary>
    public class U9ContextSectionGroup : ConfigurationSection
    {
        private const string U9ActionConfigurationName = "U9Contexts";
        private ConfigurationPropertyCollection _properties;

        [ConfigurationProperty("defaultEnterpriseID", DefaultValue = "", Options = ConfigurationPropertyOptions.None)]
        public string DefaultEnterpriseID
        {
            get { return base["defaultEnterpriseID"] != null ? base["defaultEnterpriseID"] as string : ""; }
            set { base["defaultEnterpriseID"] = value; }
        }

        [ConfigurationProperty("multiEnterprise", DefaultValue = false, Options = ConfigurationPropertyOptions.None)]
        public bool MultiEnterprise
        {
            get { return (bool) base["multiEnterprise"]; }
            set { base["multiEnterprise"] = value; }
        }

        [ConfigurationProperty("", DefaultValue = null, Options = ConfigurationPropertyOptions.IsDefaultCollection)]
        public U9ContextSectionCollection U9Contexts
        {
            get { return (U9ContextSectionCollection) base[""]; }
        }

        protected override ConfigurationPropertyCollection Properties
        {
            get
            {
                if (_properties != null) return _properties;
                _properties = new ConfigurationPropertyCollection
                {
                    new ConfigurationProperty("defaultEnterpriseID", typeof (string), null, null, null,
                        ConfigurationPropertyOptions.None),
                    new ConfigurationProperty("multiEnterprise", typeof (bool), null, null, null,
                        ConfigurationPropertyOptions.None),
                    new ConfigurationProperty("", typeof (U9ContextSectionCollection), null, null, null,
                        ConfigurationPropertyOptions.IsDefaultCollection)
                };
                return _properties;
            }
        }

        /// <summary>
        ///     获取配置
        /// </summary>
        /// <returns></returns>
        public static U9ContextSectionGroup GetConfig()
        {
            System.Configuration.Configuration config = ConfigurationHelper.GetConfiguration();
            if (config == null)
            {
                throw new Exception("config is not find");
            }
            return (U9ContextSectionGroup) config.Sections[U9ActionConfigurationName];
        }
    }
}