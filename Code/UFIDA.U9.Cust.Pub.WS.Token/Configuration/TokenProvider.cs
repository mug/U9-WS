using System.Configuration.Provider;
using UFIDA.U9.Cust.Pub.WS.U9Context.Auth;

namespace UFIDA.U9.Cust.Pub.WS.Token.Configuration
{
    /// <summary>
    ///     Token提供者
    /// </summary>
    public abstract class TokenProvider : ProviderBase
    {
        /// <summary>
        /// 是否内存缓存
        /// </summary>
        public abstract bool IsMemoryCache
        {
            get;
        }
        /// <summary>
        ///     创建Token
        /// </summary>
        /// <param name="creds"></param>
        /// <returns></returns>
        public abstract Token Create(Credentials creds);

        /// <summary>
        ///     获取Token
        /// </summary>
        /// <param name="tokenStr"></param>
        /// <returns></returns>
        public abstract Token Get(string tokenStr);

        /// <summary>
        ///     是否有效
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public abstract bool IsExpired(Token token);

        /// <summary>
        ///     更新有效期
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public abstract void UpdateExpire(Token token);

        /// <summary>
        ///     清除
        /// </summary>
        public abstract void Clean();
    }
}