using System.Runtime.Serialization;

namespace UFIDA.U9.Cust.Pub.WS.ProxyService.Models
{

    [DataContract]
    public class BPSVTypeQuery
    {
        [DataMember]
        public string QueryStr { get; set; }
    }

    /// <summary>
    /// BPSV类型
    /// </summary>
    [DataContract]
    public class BPSVType
    {
        /// <summary>
        /// 名称
        /// </summary>
        [DataMember]
        public string DisplayName { get; set; }

        /// <summary>
        /// 类全名
        /// </summary>
        [DataMember]
        public string FullName { get; set; }

        /// <summary>
        /// 程序集
        /// </summary>
        [DataMember]
        public string AssemblyName { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        [DataMember]
        public string Kind { get; set; }
    }
}