using System;
using System.Globalization;
using UFIDA.U9.Cust.Pub.WS.Base.Utils;
using UFIDA.U9.Cust.Pub.WS.Json;
using UFIDA.U9.Cust.Pub.WS.Json.Converters;
using UFIDA.U9.Cust.Pub.WS.Json.Serialization;
using UFIDA.U9.Cust.Pub.WS.ProxyService.Json;
using UFSoft.UBF.Service.Base;

namespace UFIDA.U9.Cust.Pub.WS.ProxyService.Utils
{
    /// <summary>
    ///     Json 帮助类
    /// </summary>
    public static class ProxyJsonHelper
    {
        private const string DefaultDateTimeFormat = "yyyy-MM-dd HH:mm:ss";
        public const int DefaultInMaxWritingDepth = 4;
        public const int MaxInMaxWritingDepth = 8;
        public const int DefaultOutMaxWritingDepth = 4;
        public const int MaxOutMaxWritingDepth = 8;

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

        /// <summary>
        ///     Proxy对象转为Json字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="isAutoCreateMemberValue"></param>
        /// <param name="useDataContractTransData"></param>
        /// <param name="maxInExpandDepth"></param>
        /// <returns></returns>
        internal static string ProxyObjectToJsonString(object obj, bool isAutoCreateMemberValue = false,
            bool useDataContractTransData = true, int maxInExpandDepth = DefaultInMaxWritingDepth)
        {
            if (obj == null) return string.Empty;
            IContractResolver resolver = new ProxyBaseContractResolver(useDataContractTransData);
            JsonSerializerSettings settings =
                GetJsonSerializerSettings(resolver);
            settings.IsAutoCreateMemberValue = isAutoCreateMemberValue;
            settings.MaxWritingDepth = maxInExpandDepth > 0 ? maxInExpandDepth : DefaultInMaxWritingDepth;
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            return JsonConvert.SerializeObject(obj, Formatting.None, settings);
        }

        /// <summary>
        ///     Proxy对象执行结果转为Json字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="useDataContractTransData"></param>
        /// <param name="maxExpandDepth"></param>
        /// <returns></returns>
        internal static string ProxyResultToJsonString(object obj, bool useDataContractTransData = true,
            int maxExpandDepth = DefaultInMaxWritingDepth)
        {
            if (obj == null) return string.Empty;
            IContractResolver resolver = new ProxyBaseContractResolver(useDataContractTransData);
            JsonSerializerSettings settings = GetJsonSerializerSettings(resolver);
            settings.MaxWritingDepth = maxExpandDepth > 0 ? maxExpandDepth : DefaultInMaxWritingDepth;
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            return JsonConvert.SerializeObject(obj, Formatting.None, settings);
        }

        /// <summary>
        ///     Json字符串转为Proxy对象
        /// </summary>
        /// <param name="jsonString"></param>
        /// <param name="useDataContractTransData"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        internal static object ProxyObjectFromJsonString(string jsonString, Type type,
            bool useDataContractTransData = true)
        {
            if (string.IsNullOrEmpty(jsonString)) return null;
            IContractResolver resolver = new ProxyBaseContractResolver(useDataContractTransData);
            JsonSerializerSettings settings = GetJsonSerializerSettings(resolver);
            return JsonConvert.DeserializeObject(jsonString, type, settings) as ProxyBase;
        }
    }
}