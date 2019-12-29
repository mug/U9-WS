using System.Runtime.Serialization;

namespace UFIDA.U9.Cust.Pub.WS.CommService.Models
{
    /// <summary>
    /// 代理类型
    /// </summary>
    [DataContract]
    public class ProxyRequestType
    {
        /// <summary>
        ///     类型名称
        /// </summary>
        [DataMember]
        public string TypeName { get; set; }

        /// <summary>
        ///     Assembly名称
        /// </summary>
        [DataMember]
        public string AssemblyName { get; set; }

        /// <summary>
        /// 最大展开深度
        /// </summary>
       [DataMember]
        public int MaxExpandDepth { get; set; }
    }
}