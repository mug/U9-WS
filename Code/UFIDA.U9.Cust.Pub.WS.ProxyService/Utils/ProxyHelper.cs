using System;
using UFIDA.U9.Cust.Pub.WS.ProxyService.Models;
using UFSoft.UBF;
using UFSoft.UBF.Service.Base;

namespace UFIDA.U9.Cust.Pub.WS.ProxyService.Utils
{
    public static class ProxyHelper
    {

        /// <summary>
        ///     获取请求代理对象
        /// </summary>
        /// <param name="proxyType"></param>
        /// <returns></returns>
        public static ProxyBase GetProxyBaseObject(ProxyType proxyType)
        {
            Type loadType = GetType(proxyType);
            if (loadType == null)
                throw new ProxyServiceException(string.Format("proxyType {0},{1} is not exist", proxyType.FullName,
                    proxyType.AssemblyName));
            return Activator.CreateInstance(loadType) as ProxyBase;
        }

        /// <summary>
        ///     获取请求代理对象
        /// </summary>
        /// <param name="proxyType"></param>
        /// <returns></returns>
        public static Type GetType(ProxyType proxyType)
        {
            if (proxyType == null)
                throw new ProxyServiceException("proxyType is null");
            if (string.IsNullOrEmpty(proxyType.FullName))
                throw new ProxyServiceException("proxyType.FullName is empty");
            if (string.IsNullOrEmpty(proxyType.AssemblyName))
                throw new ProxyServiceException("proxyType.AssemblyName is empty");
            return TypeManager.TypeLoader.LoadType(proxyType.FullName, proxyType.AssemblyName);
        }
    }
}