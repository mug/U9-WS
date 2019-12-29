using System;
using UFIDA.UBF.SystemManage;
using UFSoft.UBF.Util.Context;

namespace UFIDA.U9.Cust.Pub.WS.Base.Context
{
    /// <summary>
    ///     上下文对象
    /// </summary>
    public class ContextObject : IDisposable
    {
        public ContextObject(Enterprise enterprise)
        {
            using (new SystemWritablePolicy())
            {
                PlatformContext.Current.EnterpriseID = enterprise.Code;
                PlatformContext.Current.EnterpriseName = enterprise.Name;
            }
            //初始化上下文
            ContextHelper.InitContext(this);
        }

        public ContextObject(ContextInfo contextInfo)
        {
            //初始化上下文
            ContextHelper.InitContext(this);
            //设置上下文
            ContextHelper.SetContext(contextInfo);
        }

        public void Dispose()
        {
            //清空上下文
            ContextHelper.ClearContext(this);
        }
    }
}