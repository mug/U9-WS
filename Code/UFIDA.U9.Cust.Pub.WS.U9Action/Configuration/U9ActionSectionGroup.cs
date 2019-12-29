using System;
using System.Configuration;
using UFIDA.U9.Cust.Pub.WS.Base.Utils;

namespace UFIDA.U9.Cust.Pub.WS.U9Action.Configuration
{
    /// <summary>
    ///     U9动作节点配置组
    /// </summary>
    public class U9ActionSectionGroup : ConfigurationSection
    {
        private const string U9ActionConfigurationName = "U9Actions";
        private ConfigurationPropertyCollection _properties;

        [ConfigurationProperty("", DefaultValue = null, Options = ConfigurationPropertyOptions.IsDefaultCollection)]
        public U9ActionSectionCollection Actions
        {
            get { return (U9ActionSectionCollection) base[""]; }
        }

        protected override ConfigurationPropertyCollection Properties
        {
            get
            {
                if (_properties != null) return _properties;
                _properties = new ConfigurationPropertyCollection
                {
                    new ConfigurationProperty("", typeof (U9ActionSectionCollection), null, null, null,
                        ConfigurationPropertyOptions.IsDefaultCollection)
                };
                return _properties;
            }
        }

        /// <summary>
        ///     获取配置
        /// </summary>
        /// <returns></returns>
        public static U9ActionSectionGroup GetConfig()
        {
            System.Configuration.Configuration config = ConfigurationHelper.GetConfiguration();
            if (config == null)
            {
                throw new Exception("config is not find");
            }
            return (U9ActionSectionGroup) config.Sections[U9ActionConfigurationName];
        }
    }
}