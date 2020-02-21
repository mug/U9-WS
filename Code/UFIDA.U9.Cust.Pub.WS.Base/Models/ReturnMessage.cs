using System.Runtime.Serialization;
using UFIDA.U9.Cust.Pub.WS.Base.Interfaces;

namespace UFIDA.U9.Cust.Pub.WS.Base.Models
{
    [DataContract]
    public class ReturnMessage<T> : IReturnMessage
    {
        /// <summary>
        ///     结果
        /// </summary>
        [DataMember]
        public T Result { get; set; }

        /// <summary>
        ///     是否成功
        /// </summary>
        [DataMember]
        public bool IsSuccess { get; set; } = true;

        /// <summary>
        ///     错误信息
        /// </summary>
        [DataMember]
        public string ErrMsg { get; set; } = string.Empty;

        /// <summary>
        /// 堆栈
        /// </summary>
        [DataMember]
        public string StackString { get; set; } = string.Empty;
    }
}