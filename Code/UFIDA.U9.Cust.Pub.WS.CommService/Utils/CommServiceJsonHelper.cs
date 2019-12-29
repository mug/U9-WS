using System.Globalization;
using System.IO;
using System.Text;
using UFIDA.U9.Cust.Pub.WS.Base.Utils;
using UFIDA.U9.Cust.Pub.WS.CommService.Json;
using UFIDA.U9.Cust.Pub.WS.CommService.Json.Converters;
using UFIDA.U9.Cust.Pub.WS.CommService.Json.Serialization;

namespace UFIDA.U9.Cust.Pub.WS.CommService.Utils
{
    /// <summary>
    ///     Json 帮助类
    /// </summary>
    public static class CommServiceJsonHelper
    {
        private const string DefaultDateTimeFormat = "yyyy-MM-ddTHH:mm:ssZ";

        /// <summary>
        /// 获取默认Json序列化配置
        /// </summary>
        /// <returns></returns>
        public static JsonSerializerSettings GetDefaultJsonSerializerSettings()
        {
            return GetJsonSerializerSettings(new CamelCasePropertyNamesContractResolver());
        }

        /// <summary>
        /// 获取Json序列化配置
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
        ///     获取默认JsonSerializer
        /// </summary>
        /// <returns></returns>
        public static JsonSerializer GetDefaultJsonSerializer()
        {
            return GetJsonSerializer(new CamelCasePropertyNamesContractResolver());
        }

        /// <summary>
        /// 获取JsonSerializer
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

        /// <summary>
        ///     对象转为Json
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJsonString(object obj)
        {
            if (obj == null) return string.Empty;
            var settings = GetDefaultJsonSerializerSettings();
            return JsonConvert.SerializeObject(obj, Formatting.None, settings);
        }

        /// <summary>
        ///     获取JsonBody
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="isBOM"></param>
        /// <returns></returns>
        public static byte[] GetJsonBody(object obj, bool isBOM = true)
        {
            byte[] body;
            var serializer = GetDefaultJsonSerializer();
            using (MemoryStream ms = new MemoryStream())
            {
                using (StreamWriter sw = new StreamWriter(ms, new UTF8Encoding(isBOM)))
                {
                    using (JsonWriter writer = new JsonTextWriter(sw))
                    {
                        //writer.Formatting = Newtonsoft.Json.Formatting.Indented;
                        serializer.Serialize(writer, obj);
                        sw.Flush();
                        body = ms.ToArray();
                    }
                }
            }
            return body;
        }
    }
}