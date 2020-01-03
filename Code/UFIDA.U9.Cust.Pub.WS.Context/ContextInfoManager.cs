using System.Collections.Generic;
using UFIDA.U9.Cust.Pub.WS.Context;
using UFIDA.U9.Cust.Pub.WS.U9Context.Configuration;
using UFSoft.UBF.Util.Log;

namespace UFIDA.U9.Cust.Pub.WS.U9Context
{

    /// <summary>
    ///     U9上下文信息管理
    /// </summary>
    public sealed class ContextInfoManager
    {
        private static ContextInfoManager _instance;
        private static readonly object Lock = new object();
        private static readonly object InitLock = new object();
        private static readonly ILogger Logger = LoggerManager.GetLogger(typeof (ContextInfoManager));
        private Dictionary<string, ContextInfo> _contextInfoDict;
        private bool _isInited;

        private ContextInfoManager()
        {
        }

        public static ContextInfoManager Instance
        {
            get
            {
                if (_instance != null)
                {
                    if (!_instance._isInited)
                    {
                        _instance.Init();
                    }
                    return _instance;
                }
                lock (Lock)
                {
                    if (_instance == null)
                    {
                        _instance = new ContextInfoManager();
                        _instance.Init();
                    }
                    else if (!_instance._isInited)
                    {
                        _instance.Init();
                    }
                    return _instance;
                }
            }
        }

        /// <summary>
        ///     默认上下文
        /// </summary>
        public ContextInfo DefaultContext { get; private set; }

        /// <summary>
        ///     是否多企业
        /// </summary>
        public bool MultiEnterprise { get; private set; }

        /// <summary>
        ///     获取上下文
        /// </summary>
        /// <param name="enterpriseID"></param>
        /// <returns></returns>
        public ContextInfo GetContext(string enterpriseID)
        {
            return _contextInfoDict.ContainsKey(enterpriseID) ? _contextInfoDict[enterpriseID] : null;
        }

        /// <summary>
        /// 获取上下文
        /// </summary>
        /// <returns></returns>
        public ContextInfo GetContext()
        {
            return DefaultContext;
        }

        /// <summary>
        ///     初始化
        /// </summary>
        public void Init()
        {
            lock (InitLock)
            {
                if (_isInited) return;
                Logger.Debug("ContextInfoManager初始化");
                if (_contextInfoDict != null) return;
                _contextInfoDict = new Dictionary<string, ContextInfo>();
                U9ContextSectionGroup u9ActionSectionGroup = U9ContextSectionGroup.GetConfig();
                if (u9ActionSectionGroup == null) return;
                MultiEnterprise = u9ActionSectionGroup.MultiEnterprise;
                foreach (U9ContextSection u9ContextSection in u9ActionSectionGroup.U9Contexts)
                {
                    if (_contextInfoDict.ContainsKey(u9ContextSection.EnterpriseID))
                        throw new U9ContextException(string.Format("enterpriseID:{0} is repeat",
                            u9ContextSection.EnterpriseID));
                    ContextInfo contextInfo = ContextInfo.Create(u9ContextSection.EnterpriseID, u9ContextSection.EnterpriseName,
                        u9ContextSection.OrgID, u9ContextSection.OrgCode, u9ContextSection.OrgName, u9ContextSection.UserID,
                        u9ContextSection.UserCode, u9ContextSection.UserName, u9ContextSection.Culture, u9ContextSection.SupportCultureNameList);
                    _contextInfoDict.Add(contextInfo.EnterpriseID, contextInfo);
                }
                if (!MultiEnterprise)
                {
                    string defaultEnterpriseID = u9ActionSectionGroup.DefaultEnterpriseID;
                    if (string.IsNullOrEmpty(defaultEnterpriseID))
                        throw new U9ContextException("defaultEnterpriseID is empty");
                    if (!_contextInfoDict.ContainsKey(defaultEnterpriseID))
                        throw new U9ContextException(string.Format("defaultEnterpriseID:{0} is not exist",
                            defaultEnterpriseID));
                    DefaultContext = _contextInfoDict[defaultEnterpriseID];
                }
                _isInited = true;
            }
        }
    }
}