using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Web.Configuration;

namespace UFIDA.U9.Cust.Pub.WS.Base.Utils
{
    public static class ConfigurationHelper
    {
        /// <summary>
        ///     获取配置
        /// </summary>
        /// <returns></returns>
        public static Configuration GetConfiguration()
        {
            string virtualPath = "~/";
            if (OperationContext.Current != null)
            {
                VirtualPathExtension extension = OperationContext.Current.Host.Extensions.Find<VirtualPathExtension>();
                virtualPath = extension.VirtualPath;
            }
            return WebConfigurationManager.OpenWebConfiguration(virtualPath);
        }

        /// <summary>
        ///     获取参数配置值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetAppSettingValue(string key)
        {
            Configuration config = GetConfiguration();
            if (config.AppSettings.Settings[key] == null) return string.Empty;
            string strValue = config.AppSettings.Settings[key].Value;
            return string.IsNullOrWhiteSpace(strValue)
                ? string.Empty
                : strValue.Trim();
        }
    }
}