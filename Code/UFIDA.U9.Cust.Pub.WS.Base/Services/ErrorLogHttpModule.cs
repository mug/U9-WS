using System;
using System.Configuration;
using System.Web;
using UFSoft.UBF.Util.Log;

namespace UFIDA.U9.Cust.Pub.WS.Base.Services
{
    /// <summary>
    ///     The HttpModule catches any unhandled exception by IIS and passes it to Log4NET.
    /// </summary>
    /// <remarks>
    ///     Logging can be disabled by setting 'LogUnhandledExceptions' in app.config or web.config to 'false'. Alternatively,
    ///     the HttpModule
    ///     can simply be removed. It is possible to install the module on IIS as a global managed module, so that all
    ///     unhandled exceptions
    ///     for all methods can be logged. Use the files in the \Install folder to see how.
    /// </remarks>
    public class ErrorLogHttpModule : IHttpModule
    {
        private static readonly ILogger _logger = LoggerManager.GetLogger("ErrorLogHttpModule");
        private bool logUnhandeldExceptions;

        public void Init(HttpApplication context)
        {
            bool success = bool.TryParse(ConfigurationManager.AppSettings["LogUnhandledExceptions"],
                out logUnhandeldExceptions);
            if (!success)
            {
                logUnhandeldExceptions = true;
            }
            context.Error += OnError;
        }

        public void Dispose()
        {
        }

        private void OnError(object sender, EventArgs e)
        {
            try
            {
                if (!logUnhandeldExceptions) return;
                string userIp;
                string url;
                string exception;
                HttpContext context = HttpContext.Current;
                if (context != null)
                {
                    userIp = context.Request.UserHostAddress;
                    url = context.Request.Url.ToString();
                    // get last exception, but check if it exists
                    Exception lastException = context.Server.GetLastError();
                    exception = lastException != null ? lastException.ToString() : "no error";
                }
                else
                {
                    userIp = "no httpcontext";
                    url = "no httpcontext";
                    exception = "no httpcontext";
                }
                _logger.Error("Unhandled exception occured,IP:[{0}] Url:[{1}]", userIp, url);
                _logger.Error("异常信息:{0}", exception);
            }
            catch (Exception ex)
            {
                _logger.Error("Exception occured in OnError: [{0}]", ex);
            }
        }
    }
}