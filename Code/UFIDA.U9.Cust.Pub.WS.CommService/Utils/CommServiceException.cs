using System;
using System.Runtime.Serialization;

namespace UFIDA.U9.Cust.Pub.WS.CommService.Utils
{
    internal class CommServiceException : Exception
    {
        public CommServiceException()
        {
        }

        public CommServiceException(string msg) : base(msg)
        {
        }

        public CommServiceException(string msg, Exception inner) : base(msg, inner)
        {
        }

        protected CommServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}