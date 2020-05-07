using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using UFSoft.UBF;

namespace UFIDA.U9.Cust.Pub.WS.Base.Utils
{
    /// <summary>
    ///     堆栈帮助类
    /// </summary>
    public class StackTraceHelper
    {
        /// <summary>
        ///     获取异常堆栈
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="isReverse"></param>
        /// <returns></returns>
        public static string GetExceptionStackTraceString(Exception ex, bool isReverse = true)
        {
            List<string> errList = new List<string>();
            GetExceptionStackTraceString(ex, ref errList);
            if (isReverse) errList.Reverse();
            return string.Join("", errList.ToArray());
        }

        private static void GetExceptionStackTraceString(Exception ex, ref List<string> errList)
        {
            if (ex == null) return;
            //移除 < a href ></ a >
            string hrefPattern =
                @"(?is)<a(?:(?!href=).)*href=(['""]?)(?<url>[^""\s>]*)\1[^>]*>(?<text>(?:(?!</?a\b).)*)</a>";
            string stackTraceString = Regex.Replace(ex.StackTrace, hrefPattern, string.Empty);
            errList.Add(stackTraceString);
            errList.Add(string.Format("- {0} : {1} \r\n", ex.GetType().FullName, ex.Message));
            ExceptionBase exceptionBase = ex as ExceptionBase;
            if (exceptionBase != null && exceptionBase.InnerExceptions != null &&
                exceptionBase.InnerExceptions.Count > 0)
            {
                foreach (Exception iex in exceptionBase.InnerExceptions)
                {
                    GetExceptionStackTraceString(iex, ref errList);
                }
            }
            else
            {
                GetExceptionStackTraceString(ex.InnerException, ref errList);
            }
        }

        /// <summary>
        ///     获取堆栈
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentStackTraceString(int startIndex = 0)
        {
            return GetStackTraceString(new StackTrace(true), startIndex);
        }

        public static string GetStackTraceString(StackTrace stackTrace, int startIndex = 0)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = startIndex; i < stackTrace.FrameCount; i++)
            {
                StackFrame stackFrame = stackTrace.GetFrame(i);
                sb.AppendLine(GetMethodCallLog(stackFrame));
            }
            return sb.ToString();
        }

        private static bool IsMethodToIncluded(StackFrame stackFrame, Type type)
        {
            MethodBase method = stackFrame.GetMethod();
            if (method.DeclaringType == null) return false;
            return method.DeclaringType != type;
        }

        public static string GetMethodCallLog(StackFrame stackFrame)
        {
            StringBuilder sb = new StringBuilder();
            MethodBase method = stackFrame.GetMethod();
            sb.Append("  在 ");
            string assemblyFullName = method.DeclaringType?.Assembly.FullName;
            if (!string.IsNullOrEmpty(assemblyFullName))
            {
                sb.Append(assemblyFullName.Split(',')[0]);
                sb.Append("!");
            }
            sb.Append(method.DeclaringType);
            sb.Append(".");
            sb.Append(stackFrame.GetMethod().Name);
            var methodParameters = method.GetParameters();
            sb.Append("(");
            for (int i = 0; i < methodParameters.Length; i++)
            {
                if (i > 0)
                    sb.Append(", ");
                var methodParameter = methodParameters[i];
                sb.Append(methodParameter.ParameterType.Name);
                sb.Append(" ");
                sb.Append(methodParameter.Name);
            }
            sb.Append(")");
            var sourceFileName = stackFrame.GetFileName();
            if (!string.IsNullOrEmpty(sourceFileName))
            {
                sb.Append(" 位置 ");
                sb.Append(sourceFileName);
                sb.Append(": 行号 ");
                sb.Append(stackFrame.GetFileLineNumber().ToString());
            }
            else
            {
                int nativeOffset = stackFrame.GetNativeOffset();
                if (nativeOffset > 0)
                {
                    sb.Append(" +0x");
                    sb.Append(nativeOffset.ToString("x2"));
                }
            }
            return sb.ToString();
        }
    }
}