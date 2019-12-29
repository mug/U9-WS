using System.Runtime.Serialization;

namespace UFIDA.U9.Cust.Pub.WS.Token.Models
{
    [DataContract]
    public class Credentials
    {
        /// <summary>
        ///     企业ID
        /// </summary>
        [DataMember]
        public string EnterpriseID { get; set; }

        /// <summary>
        /// 组织编码
        /// </summary>
        [DataMember]
        public string OrgCode { get; set; }

        /// <summary>
        ///     用户编码
        /// </summary>
        [DataMember]
        public string UserCode { get; set; }

        /// <summary>
        ///     密码
        /// </summary>
        [DataMember]
        public string Password { get; set; }
    }
}