using System;
using System.Runtime.Serialization;

namespace UFIDA.U9.Cust.Pub.WS.Token
{
    [Serializable]
    public class TokenException : Exception
    {
        public TokenException()
        {
        }

        public TokenException(string msg) : base(msg)
        {
        }

        public TokenException(string msg, Exception inner) : base(msg, inner)
        {
        }

        protected TokenException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}