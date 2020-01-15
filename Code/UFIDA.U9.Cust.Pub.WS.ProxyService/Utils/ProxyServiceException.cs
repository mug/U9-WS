using System;
using System.Runtime.Serialization;

namespace UFIDA.U9.Cust.Pub.WS.ProxyService.Utils
{
    internal class ProxyServiceException : Exception
    {
        public ProxyServiceException()
        {
        }

        public ProxyServiceException(string msg) : base(msg)
        {
        }

        public ProxyServiceException(string msg, Exception inner) : base(msg, inner)
        {
        }

        protected ProxyServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}