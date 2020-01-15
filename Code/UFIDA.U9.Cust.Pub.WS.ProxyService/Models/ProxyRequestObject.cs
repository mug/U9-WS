using System.Runtime.Serialization;

namespace UFIDA.U9.Cust.Pub.WS.CommService.Models
{
    /// <summary>
    ///     代理对象
    /// </summary>
    [DataContract]
    public class RequestProxyObject
    {
        /// <summary>
        ///     代理类型
        /// </summary>
        [DataMember]
        public RequestProxyType RequestProxyType { get; set; }

        /// <summary>
        ///     Json字符串
        /// </summary>
        [DataMember]
        public string ProxyObjectJsonString { get; set; }
    }
}