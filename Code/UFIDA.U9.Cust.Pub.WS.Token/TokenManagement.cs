using System;
using System.Timers;
using UFIDA.U9.Cust.Pub.WS.Token.Configuration;
using UFIDA.U9.Cust.Pub.WS.Token.Models;
using UFSoft.UBF.Util.Log;

namespace UFIDA.U9.Cust.Pub.WS.Token
{
    /// <summary>
    ///     Token管理
    /// </summary>
    public class TokenManagement
    {
        private static TokenManagement _instance;
        private static readonly object Lock = new object();
        private static readonly object InitLock = new object();
        private static readonly object CleanLock = new object();
        public static int DefaultClearInvalidTokenSeconds = 5*60;
        private static readonly ILogger Logger = LoggerManager.GetLogger(typeof (TokenManagement));
        private bool _isInited;
        private TokenProvider _provider;
        private TokenProviderCollection _providers;

        private TokenManagement()
        {
        }

        public static TokenManagement Instance
        {
            get
            {
                if (_instance != null)
                {
                    if (!_instance._isInited)
                    {
                        _instance.Initinal();
                    }
                    return _instance;
                }
                lock (Lock)
                {
                    if (_instance == null)
                    {
                        _instance = new TokenManagement();
                        _instance.Initinal();
                    }
                    else if (!_instance._isInited)
                    {
                        _instance.Initinal();
                    }
                    return _instance;
                }
            }
        }

        /// <summary>
        ///     初始化
        /// </summary>
        private void Initinal()
        {
            lock (InitLock)
            {
                if (_isInited) return;
                Logger.Debug("TokenManagement开启");
                if (_providers != null && _providers.Count != 0) return;
                TokenConfiguration config = TokenConfiguration.GetConfig();
                if (config == null || !config.Enabled) return;
                config.ValidateDefaultProvider();
                _providers = config.ProvidersInternal;
                _providers.SetReadOnly();
                _provider = _providers[config.DefaultProvider];
                if (_provider.IsMemoryCache)
                {
                    Timer tokenTimer = new Timer();
                    tokenTimer.Elapsed += TokenTimer_Elapsed;
                    // 设置引发时间的时间间隔 此处设置为5分钟
                    tokenTimer.Interval = (config.ClearInvalidTokenSeconds > 0
                        ? config.ClearInvalidTokenSeconds
                        : DefaultClearInvalidTokenSeconds) *1000;
                    tokenTimer.Enabled = true;
                }
                _isInited = true;
            }
        }

        private void TokenTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                lock (CleanLock)
                {
                    if (_provider != null)
                        _provider.Clean();
                }
            }
            catch (Exception ex)
            {
                Logger.Debug("TokenManagement 清除超时Token异常: {0}", ex);
            }
        }

        /// <summary>
        ///     加载Token
        /// </summary>
        /// <param name="creds"></param>
        /// <returns></returns>
        public Token Create(Credentials creds)
        {
            return _provider == null ? null : _provider.Create(creds);
        }

        /// <summary>
        ///     获取Token
        /// </summary>
        /// <param name="tokenStr"></param>
        public Token Get(string tokenStr)
        {
            return _provider == null ? null : _provider.Get(tokenStr);
        }

        /// <summary>
        ///     Token是否到期
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public bool IsExpired(Token token)
        {
            return _provider == null || _provider.IsExpired(token);
        }

        /// <summary>
        ///     更新有效期
        /// </summary>
        /// <param name="token"></param>
        public void UpdateExpire(Token token)
        {
            if (_provider == null) return;
            _provider.UpdateExpire(token);
        }
    }
}