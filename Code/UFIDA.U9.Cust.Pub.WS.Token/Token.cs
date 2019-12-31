using System;
using System.Runtime.Serialization;
using UFIDA.U9.Cust.Pub.WS.Context;

namespace UFIDA.U9.Cust.Pub.WS.Token
{
    /// <summary>
    ///     Token
    /// </summary>
    [DataContract]
    public class Token : ContextInfo
    {
        [DataMember]
        public string TokenStr { get; set; }

        /// <summary>
        ///     创建时间
        /// </summary>
        [DataMember]
        public DateTime CreateTime { get; set; }

        /// <summary>
        ///     最后更新时间
        /// </summary>
        [DataMember]
        public DateTime LastUpdateTime { get; set; }
    }
}