using System.Data;
using System.Runtime.Serialization;

namespace UFIDA.U9.Cust.Pub.WS.DebugService.Models
{
    [DataContract]
    public class SQLDebugConfig
    {
        [DataMember]
        public string EnterpriseID { get; set; }

        [DataMember]
        public string OrgCode { get; set; }

        [DataMember]
        public string UserCode { get; set; }

        [DataMember]
        public string SQLFilterString { get; set; }

        [DataMember]
        public int CommandType { get; set; }

        [DataMember]
        public bool IsContainSelect { get; set; }

        [DataMember]
        public bool IsContainInsert { get; set; }

        [DataMember]
        public bool IsContainUpdate { get; set; }

        [DataMember]
        public bool IsContainDelete { get; set; }

        /// <summary>
        /// 是否输出堆栈
        /// </summary>
        [DataMember]
        public bool IsOutputStack { get; set; }

    }
}