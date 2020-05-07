using System;
using System.Runtime.Serialization;

namespace UFIDA.U9.Cust.Pub.WS.Base.Utils
{
    [Serializable]
    public class WSException : Exception
    {
        public WSException(int exceptionCode)
        {
            this.ExceptionCode = exceptionCode;
        }

        public WSException(int exceptionCode, string msg) : base(msg)
        {
            this.ExceptionCode = exceptionCode;
        }

        public WSException(int exceptionCode, string msg, Exception inner) : base(msg, inner)
        {
            this.ExceptionCode = exceptionCode;
        }

        protected WSException(int exceptionCode, SerializationInfo info, StreamingContext context) : base(info, context)
        {
            this.ExceptionCode = exceptionCode;
        }

        /// <summary>
        ///     异常代码
        /// </summary>
        public int ExceptionCode { get; set; }
    }
}