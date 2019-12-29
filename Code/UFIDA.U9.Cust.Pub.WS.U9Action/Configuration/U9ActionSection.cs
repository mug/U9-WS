using System;
using System.Configuration;
using System.Runtime.Serialization.Configuration;
using UFSoft.UBF;

namespace UFIDA.U9.Cust.Pub.WS.U9Action.Configuration
{
    public sealed class U9ActionSection : ConfigurationElement
    {
        private ConfigurationPropertyCollection _properties;

        [ConfigurationProperty("name", DefaultValue = "", Options = ConfigurationPropertyOptions.None)]
        public string Name
        {
            get
            {
                string result;
                if (this["name"] != null)
                {
                    result = this["name"] as string;
                }
                else
                {
                    result = "";
                }
                return result;
            }
        }

        [ConfigurationProperty("type", DefaultValue = null, Options = ConfigurationPropertyOptions.None)]
        public string Type
        {
            get { return (string) this["type"]; }
        }

        /// <summary>
        ///     类型
        /// </summary>
        public Type LoadType
        {
            get { return TypeManager.TypeLoader.LoadType(Type); }
        }

        [ConfigurationProperty("", DefaultValue = null, Options = ConfigurationPropertyOptions.IsDefaultCollection)]
        public ParameterElementCollection Parameters
        {
            get { return (ParameterElementCollection) this[""]; }
        }

        protected override ConfigurationPropertyCollection Properties
        {
            get
            {
                if (_properties == null)
                {
                    _properties = new ConfigurationPropertyCollection();
                    _properties.Add(new ConfigurationProperty("type", typeof (string), null, null, null,
                        ConfigurationPropertyOptions.None));
                    _properties.Add(new ConfigurationProperty("name", typeof (string), null, null, null,
                        ConfigurationPropertyOptions.None));
                    _properties.Add(new ConfigurationProperty("", typeof (ParameterElementCollection), null, null, null,
                        ConfigurationPropertyOptions.IsDefaultCollection));
                }
                return _properties;
            }
        }
    }
}