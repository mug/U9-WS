using System.ServiceModel.Activation;
using UFIDA.U9.Cust.Pub.WS.Base.Models;
using UFIDA.U9.Cust.Pub.WS.DebugService.Debug;
using UFIDA.U9.Cust.Pub.WS.DebugService.Interfaces;
using UFIDA.U9.Cust.Pub.WS.DebugService.Models;

namespace UFIDA.U9.Cust.Pub.WS.DebugService.Services
{
    /// <summary>
    ///     调试服务
    /// </summary>
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class DebugService : IDebugService
    {
        #region Debug

        /// <summary>
        ///     是否开启SQL调试
        /// </summary>
        /// <returns></returns>
        public ReturnMessage<bool> IsSetupSQLDebug()
        {
            ReturnMessage<bool> ret = new ReturnMessage<bool>();
            ret.IsSuccess = true;
            ret.Result = SQLDebug.IsSetupDebug();
            return ret;
        }

        /// <summary>
        ///     开启SQL调试
        /// </summary>
        /// <returns></returns>
        public ReturnMessage<bool> SetupSQLDebug(SQLDebugConfig debugConfig)
        {
            ReturnMessage<bool> ret = new ReturnMessage<bool>();
            ret.IsSuccess = true;
            ret.Result = SQLDebug.SetupDebug(debugConfig);
            return ret;
        }

        /// <summary>
        ///     停止SQL调试
        /// </summary>
        /// <returns></returns>
        public ReturnMessage<bool> StopSQLDebug()
        {
            ReturnMessage<bool> ret = new ReturnMessage<bool>();
            ret.IsSuccess = true;
            ret.Result = SQLDebug.StopDebug();
            return ret;
        }

        #endregion
    }
}