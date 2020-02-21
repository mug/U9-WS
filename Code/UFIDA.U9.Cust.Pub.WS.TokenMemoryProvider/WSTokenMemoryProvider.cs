﻿using System;
using System.Collections;
using System.Collections.Specialized;
using UFIDA.U9.Cust.Pub.WS.Context;
using UFIDA.U9.Cust.Pub.WS.Token.Configuration;
using UFIDA.U9.Cust.Pub.WS.U9Context.Auth;
using UFSoft.UBF.Util.Log;

namespace UFIDA.U9.Cust.Pub.WS.Token.MemoryProvider
{
    /// <summary>
    ///     服务Token内存提供者
    /// </summary>
    public class WSTokenMemoryProvider : TokenProvider
    {
        /// <summary>
        ///     通过超时清除
        /// </summary>
        private void CleanByTimeOut()
        {
            if (_tokenStorage.Count == 0) return;
            ArrayList arrayList = new ArrayList(_tokenStorage.Count);
            foreach (object tokenStr in _tokenStorage.Keys)
            {
                Token token = _tokenStorage[tokenStr] as Token;
                if (token == null) continue;
                if (IsExpired(token))
                {
                    arrayList.Add(tokenStr);
                }
            }
            foreach (object tokenStr in arrayList)
            {
                _tokenStorage.Remove(tokenStr);
            }
        }

        /// <summary>
        ///     通过Size清除
        /// </summary>
        private void CleanBySize()
        {
            if (_tokenStorage.Count == 0) return;
            if (this.MaxSizePerUser <= 0 || _tokenStorage.Count <= this.MaxSizePerUser) return;
            ArrayList arrayList = new ArrayList(_tokenStorage.Count);
            foreach (string tokenStr in _tokenStorage.Keys)
            {
                arrayList.Add(_tokenStorage[tokenStr]);
            }
            arrayList.Sort(new TokenLastUpdateTimeComparer());
            int sizeCount = _tokenStorage.Count - this.MaxSizePerUser;
            for (int i = 0; i < sizeCount; i++)
            {
                Token token = arrayList[i] as Token;
                if (token == null) continue;
                _tokenStorage.Remove(token.TokenStr);
            }
        }

        #region 属性

        private const int DefaultTimeoutSecond = 30*60;
        private static ILogger _logger = LoggerManager.GetLogger(typeof (WSTokenMemoryProvider));
        private readonly Hashtable _tokenStorage = Hashtable.Synchronized(new Hashtable());
        private bool _isSameCredentialsOneToken;
        private int _maxSizePerUser = int.MaxValue;
        private int _clearInvalidTokenSeconds;
        private TimeSpan _timeout = TimeSpan.FromSeconds(DefaultTimeoutSecond);
        private int _tokenSize = -1;
        private const int DefaultTokenSize = 200;

        /// <summary>
        ///     超时时间
        /// </summary>
        private TimeSpan Timeout
        {
            get { return this._timeout; }
        }

        private int MaxSizePerUser
        {
            get { return this._maxSizePerUser; }
        }

        /// <summary>
        ///     Token串长度
        /// </summary>
        private int TokenSize
        {
            get { return _tokenSize; }
        }

        /// <summary>
        ///     相同证书同一个Token
        /// </summary>
        private bool IsSameCredentialsOneToken
        {
            get { return _isSameCredentialsOneToken; }
        }

        /// <summary>
        ///     是否内存缓存
        /// </summary>
        public override bool IsMemoryCache
        {
            get { return true; }
        }

        /// <summary>
        ///     清理失效Token秒数
        /// </summary>
        public int ClearInvalidTokenSeconds
        {
            get { return _clearInvalidTokenSeconds; }
        }

        #endregion

        #region 重写虚方法

        /// <summary>
        ///     加载配置
        /// </summary>
        /// <param name="name"></param>
        /// <param name="config"></param>
        public override void Initialize(string name, NameValueCollection config)
        {
            base.Initialize(name, config);
            int timeoutSecond = config["timeout"] == null ? DefaultTimeoutSecond : Convert.ToInt32(config["timeout"]);
            _timeout = TimeSpan.FromSeconds(timeoutSecond);
            this._maxSizePerUser = config["maxSizePerUser"] == null ? -1 : Convert.ToInt32(config["maxSizePerUser"]);
            _tokenSize = config["tokenSize"] == null ? DefaultTokenSize : Convert.ToInt32(config["tokenSize"]);
            _isSameCredentialsOneToken = config["IsSameCredentialsOneToken"] != null &&
                                         Convert.ToBoolean(config["IsSameCredentialsOneToken"]);
            this._clearInvalidTokenSeconds = config["clearInvalidTokenSeconds"] == null
                ? -1
                : Convert.ToInt32(config["clearInvalidTokenSeconds"]);
        }

        /// <summary>
        ///     创建Token
        /// </summary>
        /// <param name="creds"></param>
        /// <returns></returns>
        public override Token Create(Credentials creds)
        {
            if (creds == null)
                throw new ArgumentException("身份认证信息不能为空");
            ContextInfo contextInfo = creds.GetContextInfo();
            string tokenStr = TokenHelper.BuildSecureTokenStr(this.TokenSize);
            Token token = TokenHelper.CreateToken(tokenStr, contextInfo);
            if (token != null)
                _tokenStorage.Add(token.TokenStr, token);
            return token;
        }

        /// <summary>
        ///     获取Token
        /// </summary>
        /// <param name="tokenStr"></param>
        /// <returns></returns>
        public override Token Get(string tokenStr)
        {
            object obj = _tokenStorage[tokenStr];
            if (obj == null) return null;
            return obj as Token;
        }

        /// <summary>
        ///     Token是否到期
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public override bool IsExpired(Token token)
        {
            if (token == null) return true;
            DateTime now = DateTime.Now;
            DateTime d = token.LastUpdateTime;
            return now - d > this.Timeout;
        }

        /// <summary>
        ///     更新有效期
        /// </summary>
        /// <param name="token"></param>
        public override void UpdateExpire(Token token)
        {
            token.LastUpdateTime = DateTime.Now;
        }

        /// <summary>
        ///     清理
        /// </summary>
        public override void Clean()
        {
            //通过超时清除
            CleanByTimeOut();
            //通过Size清除
            CleanBySize();
        }

        #endregion

        #region 其它

        #endregion
    }
}