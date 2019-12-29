using System;

namespace UFIDA.U9.Cust.Pub.WS.DBLog
{
    /// <summary>
    /// WS数据库日志属性
    /// </summary>
    public class WSLogAttribute : Attribute
    {
        public WSLogAttribute(string methodDescription)
        {
            MethodDescription = methodDescription;
        }

        public string MethodDescription { get; set; }
    }
}