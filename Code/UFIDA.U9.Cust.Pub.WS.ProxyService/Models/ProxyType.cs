using System.Runtime.Serialization;

namespace UFIDA.U9.Cust.Pub.WS.ProxyService.Models
{
    /// <summary>
    ///     代理类型对象
    /// </summary>
    [DataContract]
    public class ProxyType
    {
        /// <summary>
        ///     类型名称
        /// </summary>
        [DataMember]
        public string FullName { get; set; }

        /// <summary>
        ///     Assembly名称
        /// </summary>
        [DataMember]
        public string AssemblyName { get; set; }

        /// <summary>
        ///     入最大展开深度
        /// </summary>
        [DataMember]
        public int InMaxExpandDepth { get; set; }

        /// <summary>
        ///     出最大展开深度
        /// </summary>
        [DataMember]
        public int OutMaxExpandDepth { get; set; }
    }
}