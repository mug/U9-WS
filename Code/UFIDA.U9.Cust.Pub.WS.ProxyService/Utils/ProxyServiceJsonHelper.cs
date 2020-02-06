using System.Globalization;
using UFIDA.U9.Cust.Pub.WS.Base.Utils;
using UFIDA.U9.Cust.Pub.WS.Json;
using UFIDA.U9.Cust.Pub.WS.Json.Converters;
using UFIDA.U9.Cust.Pub.WS.Json.Serialization;

namespace UFIDA.U9.Cust.Pub.WS.ProxyService.Utils
{
    /// <summary>
    ///     Json 帮助类
    /// </summary>
    public static class ProxyServiceJsonHelper
    {
        private const string DefaultDateTimeFormat = "yyyy-MM-dd HH:mm:ss";

        /// <summary>
        ///     获取Json序列化配置
        /// </summary>
        /// <returns></returns>
        public static JsonSerializerSettings GetJsonSerializerSettings(IContractResolver resolver)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.ContractResolver = resolver;
            settings.MissingMemberHandling = MissingMemberHandling.Ignore;
            string dateTimeFormat = ConfigurationHelper.GetAppSettingValue(ServiceConstant.DateTimeFormatName);
            settings.Converters.Add(new IsoDateTimeConverter
            {
                DateTimeFormat = string.IsNullOrEmpty(dateTimeFormat) ? DefaultDateTimeFormat : dateTimeFormat,
                DateTimeStyles = DateTimeStyles.AdjustToUniversal
            });
            return settings;
        }

        /// <summary>
        ///     获取JsonSerializer
        /// </summary>
        /// <param name="resolver"></param>
        /// <returns></returns>
        public static JsonSerializer GetJsonSerializer(IContractResolver resolver)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.ContractResolver = resolver;
            serializer.MissingMemberHandling = MissingMemberHandling.Ignore;
            string dateTimeFormat = ConfigurationHelper.GetAppSettingValue(ServiceConstant.DateTimeFormatName);
            serializer.Converters.Add(new IsoDateTimeConverter
            {
                DateTimeFormat = string.IsNullOrEmpty(dateTimeFormat) ? DefaultDateTimeFormat : dateTimeFormat,
                DateTimeStyles = DateTimeStyles.AdjustToUniversal
            });
            return serializer;
        }
    }
}