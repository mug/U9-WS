using System;
using System.Configuration.Provider;

namespace UFIDA.U9.Cust.Pub.WS.Token.Configuration
{
    /// <summary>
    ///     Token提供者集合
    /// </summary>
    public class TokenProviderCollection : ProviderCollection
    {
        public new TokenProvider this[string name]
        {
            get { return (TokenProvider) base[name]; }
        }

        public override void Add(ProviderBase provider)
        {
            if (provider == null)
                throw new ArgumentNullException("provider");
            if (provider is TokenProvider)
            {
                this.Add((TokenProvider) provider);
            }
        }

        public void Add(TokenProvider provider)
        {
            if (provider == null)
                throw new ArgumentNullException("provider");
            base.Add(provider);
        }

        public void AddArray(TokenProvider[] providerArray)
        {
            if (providerArray == null)
                throw new ArgumentNullException("providerArray");
            foreach (TokenProvider tokenProvider in providerArray)
            {
                if (this[tokenProvider.Name] != null) continue;
                this.Add(tokenProvider);
            }
        }
    }
}