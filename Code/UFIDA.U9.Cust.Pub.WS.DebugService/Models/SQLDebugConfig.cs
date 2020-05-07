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
        ///     是否输出SQL堆栈
        /// </summary>
        [DataMember]
        public bool IsOutputSQLStack { get; set; }

        /// <summary>
        ///     是否追踪BPSV事务
        /// </summary>
        [DataMember]
        public bool IsTraceBPSVTransaction { get; set; }

        /// <summary>
        ///     是否追踪自定义事务
        /// </summary>
        [DataMember]
        public bool IsTraceCustomizeTransaction { get; set; }

        /// <summary>
        ///     是否输出事务堆栈
        /// </summary>
        [DataMember]
        public bool IsOutputTransactionStack { get; set; }
    }
}