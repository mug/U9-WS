using System;

namespace UFIDA.U9.Cust.Pub.WS.Token
{
    /// <summary>
    ///     Token
    /// </summary>
    public class Token
    {
        public string TokenStr { get; set; }

        /// <summary>
        ///     企业ID
        /// </summary>
        public string EnterpriseID { get; set; }

        /// <summary>
        ///     企业名称
        /// </summary>
        public string EnterpriseName { get; set; }

        public string OrgID { get; set; }
        public string OrgCode { get; set; }
        public string OrgName { get; set; }
        public string UserID { get; set; }
        public string UserCode { get; set; }
        public string UserName { get; set; }

        /// <summary>
        ///     创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        ///     最后更新时间
        /// </summary>
        public DateTime LastUpdateTime { get; set; }
    }
}