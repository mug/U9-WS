using System.Configuration;
using System.Threading;
using System.Web.Configuration;
using UFIDA.U9.Cust.Pub.WS.Base.Utils;

namespace UFIDA.U9.Cust.Pub.WS.Token.Configuration
{
    /// <summary>
    ///     Token配置
    /// </summary>
    public class TokenConfiguration : ConfigurationSection
    {
        private const string TokenConfigSectionName = "TokenConfiguration";
        private static TokenConfiguration _tokenConfig;
        private TokenProviderCollection _providers;

        [ConfigurationProperty("enabled", DefaultValue = true)]
        public bool Enabled
        {
            get { return (bool) base["enabled"]; }
            set { base["enabled"] = value; }
        }

        [ConfigurationProperty("defaultProvider", DefaultValue = "")]
        public string DefaultProvider
        {
            get { return (string) base["defaultProvider"]; }
            set { base["defaultProvider"] = value; }
        }

        [ConfigurationProperty("clearInvalidTokenSeconds", DefaultValue = -1)]
        public int ClearInvalidTokenSeconds
        {
            get { return (int)base["clearInvalidTokenSeconds"]; }
            set { base["clearInvalidTokenSeconds"] = value; }
        }

        [ConfigurationProperty("providers")]
        public ProviderSettingsCollection Providers
        {
            get { return (ProviderSettingsCollection) base["providers"]; }
        }

        internal TokenProviderCollection ProvidersInternal
        {
            get
            {
                if (this._providers != null && this._providers.Count != 0) return this._providers;
                bool flag = false;
                try
                {
                    Monitor.Enter(this, ref flag);
                    if (this._providers == null || this._providers.Count == 0)
                    {
                        this._providers = new TokenProviderCollection();
                        ProvidersHelper.InstantiateProviders(this.Providers, this._providers, typeof (TokenProvider));
                    }
                }
                finally
                {
                    if (flag)
                    {
                        Monitor.Exit(this);
                    }
                }
                return this._providers;
            }
        }

        internal void ValidateDefaultProvider()
        {
            if (!string.IsNullOrEmpty(this.DefaultProvider) && this.Providers[this.DefaultProvider] == null)
            {
                string message = "";
                throw new ConfigurationErrorsException(message,
                    ElementInformation.Properties[this.DefaultProvider].Source,
                    ElementInformation.Properties[this.DefaultProvider].LineNumber);
            }
        }

        public static TokenConfiguration GetConfig()
        {
            if (_tokenConfig != null) return _tokenConfig;
            System.Configuration.Configuration config = ConfigurationHelper.GetConfiguration();
            if (config == null)
            {
                throw new TokenException("config is not find");
            }
            _tokenConfig = (TokenConfiguration)config.GetSection(TokenConfigSectionName);
            if (_tokenConfig == null)
            {
                throw new TokenException("Token Config Exception.");
            }
            return _tokenConfig;
        }
    }
}