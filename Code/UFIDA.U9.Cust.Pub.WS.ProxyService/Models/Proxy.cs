using System.Runtime.Serialization;

namespace UFIDA.U9.Cust.Pub.WS.ProxyService.Models
{
    /// <summary>
    ///     代理对象
    /// </summary>
    [DataContract]
    public class Proxy
    {
       
        /// <summary>
        ///     代理类型
        /// </summary>
        [DataMember]
        public ProxyType ProxyType { get; set; }

        /// <summary>
        ///     Json字符串
        /// </summary>
        [DataMember]
        public string ProxyJsonString { get; set; }
    }
}