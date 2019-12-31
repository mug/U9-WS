using System.Configuration;
using System.Runtime.Serialization.Configuration;

namespace UFIDA.U9.Cust.Pub.WS.U9Context.Configuration
{
    public sealed class U9ContextSection : ConfigurationElement
    {
        private ConfigurationPropertyCollection _properties;

        [ConfigurationProperty("enterpriseID", DefaultValue = "", Options = ConfigurationPropertyOptions.None)]
        public string EnterpriseID
        {
            get { return this["enterpriseID"] != null ? this["enterpriseID"] as string : ""; }
        }

        [ConfigurationProperty("enterpriseName", DefaultValue = "", Options = ConfigurationPropertyOptions.None)]
        public string EnterpriseName
        {
            get { return this["enterpriseName"] != null ? this["enterpriseName"] as string : ""; }
        }

        [ConfigurationProperty("orgID", DefaultValue = "", Options = ConfigurationPropertyOptions.None)]
        public string OrgID
        {
            get { return this["orgID"] != null ? this["orgID"] as string : ""; }
        }

        [ConfigurationProperty("orgCode", DefaultValue = "", Options = ConfigurationPropertyOptions.None)]
        public string OrgCode
        {
            get { return this["orgCode"] != null ? this["orgCode"] as string : ""; }
        }

        [ConfigurationProperty("orgName", DefaultValue = "", Options = ConfigurationPropertyOptions.None)]
        public string OrgName
        {
            get { return this["orgName"] != null ? this["orgName"] as string : ""; }
        }


        [ConfigurationProperty("userID", DefaultValue = "", Options = ConfigurationPropertyOptions.None)]
        public string UserID
        {
            get { return this["userID"] != null ? this["userID"] as string : ""; }
        }

        [ConfigurationProperty("userCode", DefaultValue = "", Options = ConfigurationPropertyOptions.None)]
        public string UserCode
        {
            get { return this["userCode"] != null ? this["userCode"] as string : ""; }
        }

        [ConfigurationProperty("userName", DefaultValue = "", Options = ConfigurationPropertyOptions.None)]
        public string UserName
        {
            get { return this["userName"] != null ? this["userName"] as string : ""; }
        }

        [ConfigurationProperty("culture", DefaultValue = "", Options = ConfigurationPropertyOptions.None)]
        public string Culture
        {
            get { return this["culture"] != null ? this["culture"] as string : ""; }
        }

        [ConfigurationProperty("supportCultureNameList", DefaultValue = "", Options = ConfigurationPropertyOptions.None)]
        public string SupportCultureNameList
        {
            get { return this["supportCultureNameList"] != null ? this["supportCultureNameList"] as string : ""; }
        }

        protected override ConfigurationPropertyCollection Properties
        {
            get
            {
                if (_properties != null) return _properties;
                _properties = new ConfigurationPropertyCollection();
                _properties.Add(new ConfigurationProperty("enterpriseID", typeof (string), null, null, null,
                    ConfigurationPropertyOptions.None));
                _properties.Add(new ConfigurationProperty("enterpriseName", typeof (string), null, null, null,
                    ConfigurationPropertyOptions.None));
                _properties.Add(new ConfigurationProperty("orgID", typeof (string), null, null, null,
                    ConfigurationPropertyOptions.None));
                _properties.Add(new ConfigurationProperty("orgCode", typeof (string), null, null, null,
                    ConfigurationPropertyOptions.None));
                _properties.Add(new ConfigurationProperty("orgName", typeof (string), null, null, null,
                    ConfigurationPropertyOptions.None));
                _properties.Add(new ConfigurationProperty("userID", typeof (string), null, null, null,
                    ConfigurationPropertyOptions.None));
                _properties.Add(new ConfigurationProperty("userCode", typeof (string), null, null, null,
                    ConfigurationPropertyOptions.None));
                _properties.Add(new ConfigurationProperty("userName", typeof (string), null, null, null,
                    ConfigurationPropertyOptions.None));
                _properties.Add(new ConfigurationProperty("culture", typeof (string), null, null, null,
                    ConfigurationPropertyOptions.None));
                _properties.Add(new ConfigurationProperty("supportCultureNameList", typeof (string), null, null,
                    null,
                    ConfigurationPropertyOptions.None));
                _properties.Add(new ConfigurationProperty("", typeof (ParameterElementCollection), null, null, null,
                    ConfigurationPropertyOptions.IsDefaultCollection));
                return _properties;
            }
        }
    }
}