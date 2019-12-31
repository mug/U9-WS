using System;
using System.Runtime.Serialization;

namespace UFIDA.U9.Cust.Pub.WS.U9Context
{
    [Serializable]
    public class U9ContextException : Exception
    {
        public U9ContextException()
        {
        }

        public U9ContextException(string msg) : base(msg)
        {
        }

        public U9ContextException(string msg, Exception inner) : base(msg, inner)
        {
        }

        protected U9ContextException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}