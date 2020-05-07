using System;
using System.Runtime.Serialization;
using UFIDA.U9.Cust.Pub.WS.Base.Utils;

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

    /// <summary>
    ///     Token异常代码枚举
    /// </summary>
    public enum TokenExceptionCodeEnum
    {
        Unauthorized = 40001,
        Forbidden = 40003
    }

    [Serializable]
    public class UnauthorizedTokenException : WSException
    {
        public UnauthorizedTokenException() : base((int) TokenExceptionCodeEnum.Unauthorized)
        {
        }

        public UnauthorizedTokenException(string msg) : base((int) TokenExceptionCodeEnum.Unauthorized, msg)
        {
        }

        public UnauthorizedTokenException(string msg, Exception inner)
            : base((int) TokenExceptionCodeEnum.Unauthorized, msg, inner)
        {
        }

        public UnauthorizedTokenException(SerializationInfo info, StreamingContext context)
            : base((int) TokenExceptionCodeEnum.Unauthorized, info, context)
        {
        }
    }

    [Serializable]
    public class ForbiddenTokenException : WSException
    {
        public ForbiddenTokenException() : base((int) TokenExceptionCodeEnum.Forbidden)
        {
        }

        public ForbiddenTokenException(string msg) : base((int) TokenExceptionCodeEnum.Forbidden, msg)
        {
        }

        public ForbiddenTokenException(string msg, Exception inner)
            : base((int) TokenExceptionCodeEnum.Forbidden, msg, inner)
        {
        }

        public ForbiddenTokenException(SerializationInfo info, StreamingContext context)
            : base((int) TokenExceptionCodeEnum.Forbidden, info, context)
        {
        }
    }
}