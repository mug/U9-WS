using System;
using System.Security.Cryptography;
using System.Text;

namespace UFIDA.U9.Cust.Pub.WS.U9Context
{
    public class ContextHelper
    {
        /// <summary>
        ///     加密
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string EncryptPassword(string password)
        {
            MD5 md5 = MD5.Create();
            byte[] bytes = new UnicodeEncoding().GetBytes(password);
            return Convert.ToBase64String(md5.ComputeHash(bytes));
        }
    }
}