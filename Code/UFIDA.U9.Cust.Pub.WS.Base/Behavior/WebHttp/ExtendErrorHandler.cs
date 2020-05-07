using System;
using System.Collections.Generic;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text.RegularExpressions;
using UFIDA.U9.Cust.Pub.WS.Base.Interfaces;
using UFIDA.U9.Cust.Pub.WS.Base.Utils;
using UFSoft.UBF.Business;
using UFSoft.UBF.Util.Log;

namespace UFIDA.U9.Cust.Pub.WS.Base.Behavior.WebHttp
{
    public class ExtendErrorHandler : IErrorHandler
    {
        private static readonly ILogger Logger = LoggerManager.GetLogger("ExtendErrorHandler");
        private readonly ServiceEndpoint _endpoint;
        private EndpointDispatcher _endpointDispatcher;

        /// <summary>
        ///     构造器
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="endpointDispatcher"></param>
        public ExtendErrorHandler(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            _endpoint = endpoint;
            _endpointDispatcher = endpointDispatcher;
        }

        public bool HandleError(Exception error)
        {
            Logger.Error("HandleError: {0}", error);
            return true;
        }

        public void ProvideFault(
            Exception error, MessageVersion version, ref Message fault)
        {
            OperationDescription operationDescription = GetCurrentOperationDescription();
            if (operationDescription == null) return;
            Type returnType = operationDescription.SyncMethod.ReturnType;
            IReturnMessage ret = Activator.CreateInstance(returnType) as IReturnMessage;
            if (ret == null) return;
            ret.IsSuccess = false;
            ret.ErrMsg = GetExceptionErrorMsg(error);
            string strResponeMessageIncludeStackInfo =
                ConfigurationHelper.GetAppSettingValue(ServiceConstant.ResponeMessageIncludeStackInfoName);
            bool responeMessageIncludeStackInfo = !string.IsNullOrEmpty(strResponeMessageIncludeStackInfo) &&
                                                  strResponeMessageIncludeStackInfo.ToLower() == "true";
            ret.StackString = responeMessageIncludeStackInfo
                ? StackTraceHelper.GetExceptionStackTraceString(error)
                : string.Empty;
            byte[] body = JsonHelper.GetReturnJsonBody(ret);
            fault = Message.CreateMessage(version, "",
                new RawBodyWriter(body));
            fault.Properties.Add(WebBodyFormatMessageProperty.Name,
                new WebBodyFormatMessageProperty(WebContentFormat.Raw));
            HttpResponseMessageProperty respProp = new HttpResponseMessageProperty();
            respProp.Headers[HttpResponseHeader.ContentType] = "application/json;charset=utf-8";
            if (error is WSException)
            {
                WSException wsEx = error as WSException;
                if (wsEx.ExceptionCode == 40001)
                {
                    respProp.StatusCode = HttpStatusCode.Unauthorized;
                    respProp.StatusDescription = "Unauthorized";
                }
                else if (wsEx.ExceptionCode == 40003)
                {
                    respProp.StatusCode = HttpStatusCode.Forbidden;
                    respProp.StatusDescription = "Forbidden";
                }
                else
                {
                    // return custom error code, 200.
                    respProp.StatusCode = HttpStatusCode.BadRequest;
                    //responseMessageProperty.StatusCode = HttpStatusCode.BadRequest;
                    respProp.StatusDescription = "Bad request";
                }
            }
            else
            {
                // return custom error code, 400.
                respProp.StatusCode = HttpStatusCode.BadRequest;
                //responseMessageProperty.StatusCode = HttpStatusCode.BadRequest;
                respProp.StatusDescription = "Bad request";
            }
            fault.Properties.Add(HttpResponseMessageProperty.Name, respProp);
            //The fault to be returned
            //fault = Message.CreateMessage(version, "", ret,
            //    new DataContractJsonSerializer(ret.GetType()));
            //// tell WCF to use JSON encoding rather than default XML
            //WebBodyFormatMessageProperty wbf = new WebBodyFormatMessageProperty(WebContentFormat.Json);
            //// Add the formatter to the fault
            //fault.Properties.Add(WebBodyFormatMessageProperty.Name, wbf);
            ////Modify response
            //HttpResponseMessageProperty responseMessageProperty = new HttpResponseMessageProperty();
            //if (error is SecurityException &&
            //    (error.Message == "Session expired" || error.Message == "Authentication ticket expired"))
            //{
            //    responseMessageProperty.StatusCode = HttpStatusCode.Unauthorized;
            //    responseMessageProperty.StatusDescription = "Unauthorized";
            //}
            //else
            //{
            //    // return custom error code, 400.
            //    responseMessageProperty.StatusCode = HttpStatusCode.OK;
            //    //responseMessageProperty.StatusCode = HttpStatusCode.BadRequest;
            //    responseMessageProperty.StatusDescription = "Bad request";
            //}
            ////Mark the jsonerror and json content
            //responseMessageProperty.Headers[HttpResponseHeader.ContentType] = "application/json";
            ////Add to fault
            //fault.Properties.Add(HttpResponseMessageProperty.Name, responseMessageProperty);
        }

        /// <summary>
        ///     获取错误信息
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        private string GetExceptionErrorMsg(Exception ex)
        {
            List<string> errList = new List<string>();
            BusinessException bex = ex as BusinessException;
            if (bex != null && bex.InnerExceptions != null && bex.InnerExceptions.Count > 0)
            {
                foreach (Exception iex in bex.InnerExceptions)
                {
                    errList.Add(iex.Message);
                }
            }
            else
            {
                errList.Add(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
            string errMsg = string.Join(";", errList.ToArray());
            //移除<a href></a>
            string hrefPattern =
                @"(?is)<a(?:(?!href=).)*href=(['""]?)(?<url>[^""\s>]*)\1[^>]*>(?<text>(?:(?!</?a\b).)*)</a>";
            return Regex.Replace(errMsg, hrefPattern, string.Empty);
        }

        /// <summary>
        ///     获取当前的动作描述
        /// </summary>
        /// <returns></returns>
        private OperationDescription GetCurrentOperationDescription()
        {
            MessageHeaders incomingMessageHeaders = OperationContext.Current.IncomingMessageHeaders;
            string currentActionName = OperationContext.Current.IncomingMessageHeaders.Action;
            if (string.IsNullOrEmpty(currentActionName))
                currentActionName = incomingMessageHeaders.To.Segments[incomingMessageHeaders.To.Segments.Length - 1];
            //SynchronizedKeyedCollection<string, DispatchOperation> operations =
            //    OperationContext.Current.EndpointDispatcher.DispatchRuntime.Operations;
            //DispatchOperation operation = operations.FirstOrDefault(d => d.Action == currentActionName);
            foreach (OperationDescription operationDescription in _endpoint.Contract.Operations)
            {
                if (operationDescription.Name == currentActionName) return operationDescription;
            }
            //MessageHeaders incomingMessageHeaders = OperationContext.Current.IncomingMessageHeaders;
            //string currentEndpoint = OperationContext.Current.
            //    EndpointDispatcher.EndpointAddress.Uri.AbsoluteUri;
            //string currentActionName = OperationContext.Current.IncomingMessageHeaders.Action;
            //var action = OperationContext.Current.IncomingMessageHeaders.Action;
            //var operations = OperationContext.Current.EndpointDispatcher.DispatchRuntime.Operations;
            //var operation = operations.Where(d => d.Action == action).FirstOrDefault();
            //if (_endpoint.Contract.Operations.Count == 0) return;
            //OperationDescription operationDescription = _endpoint.Contract.Operations[0];
            return null;
        }
    }
}