using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace UFIDA.U9.Cust.Pub.WS.Base.Services
{
    /// <summary>
    /// Redirect module that allows specifying a set of .svc urls
    /// by stripping the svc extension off and accessing without it.
    /// 
    /// To use add any non-svc path segments (ie. service.svc should be service)
    /// to the ServiceMap below.
    /// 
    /// Note that any path that uses one of these service map entries needs to 
    /// end with a trailing backslash.
    /// </summary>
    public class ServiceRedirector : IHttpModule
    {

        static List<string> ServiceMap = new List<string>
        {
              "testservice"
        };

        public void Dispose()
        {

        }

        public void Init(HttpApplication app)
        {
            app.BeginRequest += delegate
            {
                HttpContext ctx = HttpContext.Current;
                string path = ctx.Request.AppRelativeCurrentExecutionFilePath.ToLower();

                foreach (string mapPath in ServiceMap)
                {
                    if (path.Contains("/" + mapPath + "/") || path.EndsWith("/" + mapPath))
                    {
                        string newPath = path.Replace("/" + mapPath + "/", "/" + mapPath + ".svc/");
                        ctx.RewritePath(newPath, null, ctx.Request.QueryString.ToString(), false);
                        return;
                    }
                }
            };
        }
    }
}
