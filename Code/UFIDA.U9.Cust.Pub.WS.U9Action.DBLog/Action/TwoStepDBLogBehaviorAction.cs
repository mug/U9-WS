using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;
using Newtonsoft.Json;
using UFIDA.U9.Cust.Pub.WS.Base.Models;
using UFIDA.U9.Cust.Pub.WS.Base.Utils;
using UFIDA.U9.Cust.Pub.WS.U9Action;
using UFIDA.U9.Cust.Pub.WS.U9Action.Action;
using UFSoft.UBF.Util.Context;
using UFSoft.UBF.Util.Log;

namespace UFIDA.U9.Cust.Pub.WS.DBLog.Action
{
    /// <summary>
    ///     U9数据库日志动作
    /// </summary>
    public class TwoStepDBLogBehaviorAction : IU9BehaviorAction
    {
        private const string HeaderLogIDName = "LogID";
        private static readonly ILogger Logger = LoggerManager.GetLogger(typeof (TwoStepDBLogBehaviorAction));

        public object BeforeDo(ref Message request, IClientChannel channel, InstanceContext instanceContext,
            U9ActionCorrelationState u9ActionCorrelationState)
        {
            if (WebOperationContext.Current == null)
            {
                throw new WebFaultException(HttpStatusCode.BadRequest);
            }
            WSLog wsLog = new WSLog();
            try
            {
                string actionName =
                    OperationContext.Current.IncomingMessageProperties["HttpOperationName"] as string;
                if (string.IsNullOrEmpty(actionName)) return null;
                Type hostType = OperationContext.Current.Host.Description.ServiceType;
                MethodInfo method = hostType.GetMethod(actionName);
                if (method == null) return null;
                //日志属性
                WSLogAttribute attribute =
                    method.GetCustomAttribute(typeof(WSLogAttribute)) as
                        WSLogAttribute;
                if (attribute == null) return null;
                string logID = WebOperationContext.Current.IncomingRequest.Headers[HeaderLogIDName];
                if (!string.IsNullOrWhiteSpace(logID))
                    wsLog.LogID = long.Parse(logID);
                Uri requestUri = request.Headers.To;
                wsLog.RequestUrl = requestUri.AbsoluteUri;
                wsLog.EnterpriseID = PlatformContext.Current.EnterpriseID;
                wsLog.ClassName = hostType.FullName;
                wsLog.MethodName = actionName;
                wsLog.MethodDescription = attribute.MethodDescription;
                wsLog.StartTime = DateTime.Now;
                ReturnMessage<object> returnMessage = new ReturnMessage<object>();
                wsLog.RequestContent = this.MessageToString(ref request, false, ref returnMessage);
                //发送调用前日志
                wsLog.DoBeforeCallLog();
            }
            catch (Exception ex)
            {
                Logger.Error("日志记录异常:{0}", ex);
            }
            return wsLog;
        }

        public void AfterDo(ref Message reply, object beforeReturnObj, U9ActionCorrelationState u9ActionCorrelationState)
        {
            if (beforeReturnObj == null) return;
            WSLog wsLog = beforeReturnObj as WSLog;
            try
            {
                if (wsLog == null)
                    throw new Exception("AfterDo WSLog is null exception");
                ReturnMessage<object> returnMessage = new ReturnMessage<object>();
                wsLog.EndTime = DateTime.Now;
                wsLog.ResponseContent = this.MessageToString(ref reply, true, ref returnMessage);
                wsLog.CallResult = returnMessage.IsSuccess ? CallResultEnum.Success : CallResultEnum.Failure;
                wsLog.ErrorMessage = returnMessage.ErrMsg;
                //发送调用完日志
                wsLog.DoAfterCallLog();
            }
            catch (Exception ex)
            {
                if (wsLog != null)
                    Logger.Error("日志记录异常,LogID:{0}", wsLog.LogID);
                Logger.Error("日志记录异常:{0}", ex);
            }
        }

        private WebContentFormat GetMessageContentFormat(Message message)
        {
            WebContentFormat format = WebContentFormat.Default;
            if (message.Properties.ContainsKey(WebBodyFormatMessageProperty.Name))
            {
                WebBodyFormatMessageProperty bodyFormat;
                bodyFormat = (WebBodyFormatMessageProperty) message.Properties[WebBodyFormatMessageProperty.Name];
                format = bodyFormat.Format;
            }
            return format;
        }

        private string MessageToString(ref Message message, bool isReturn, ref ReturnMessage<object> returnMessage)
        {
            WebContentFormat messageFormat = this.GetMessageContentFormat(message);
            MemoryStream ms = new MemoryStream();
            XmlDictionaryWriter writer = null;
            switch (messageFormat)
            {
                case WebContentFormat.Default:
                case WebContentFormat.Xml:
                    writer = XmlDictionaryWriter.CreateTextWriter(ms);
                    break;
                case WebContentFormat.Json:
                    writer = JsonReaderWriterFactory.CreateJsonWriter(ms);
                    break;
                case WebContentFormat.Raw:
                    // special case for raw, easier implemented separately
                    return this.ReadRawBody(ref message, isReturn, ref returnMessage);
            }
            message.WriteMessage(writer);
            writer.Flush();
            if (isReturn)
            {
                StreamReader sr = new StreamReader(ms);
                JsonSerializer serializer = JsonHelper.GetDefaultJsonSerializer();
                object obj = serializer.Deserialize(sr, typeof (ReturnMessage<object>));
                returnMessage = obj as ReturnMessage<object>;
            }
            string messageBody = Encoding.UTF8.GetString(ms.ToArray());
            if (string.IsNullOrEmpty(messageBody)) return messageBody;
            // Here would be a good place to change the message body, if so desired.
            // now that the message was read, it needs to be recreated.
            ms.Position = 0;
            // if the message body was modified, needs to reencode it, as show below
            // ms = new MemoryStream(Encoding.UTF8.GetBytes(messageBody));
            XmlDictionaryReader reader;
            reader = messageFormat == WebContentFormat.Json
                ? JsonReaderWriterFactory.CreateJsonReader(ms, XmlDictionaryReaderQuotas.Max)
                : XmlDictionaryReader.CreateTextReader(ms, XmlDictionaryReaderQuotas.Max);
            Message newMessage = Message.CreateMessage(reader, int.MaxValue, message.Version);
            newMessage.Properties.CopyProperties(message.Properties);
            message = newMessage;
            return messageBody;
        }

        private string ReadRawBody(ref Message message, bool isReturn, ref ReturnMessage<object> returnMessage)
        {
            XmlDictionaryReader bodyReader = message.GetReaderAtBodyContents();
            bodyReader.ReadStartElement("Binary");
            byte[] bodyBytes = bodyReader.ReadContentAsBase64();
            if (isReturn)
            {
                MemoryStream ms1 = new MemoryStream(bodyBytes);
                StreamReader sr = new StreamReader(ms1);
                JsonSerializer serializer = JsonHelper.GetDefaultJsonSerializer();
                object obj = serializer.Deserialize(sr, typeof (ReturnMessage<object>));
                returnMessage = obj as ReturnMessage<object>;
            }
            string messageBody = Encoding.UTF8.GetString(bodyBytes);
            // Now to recreate the message
            MemoryStream ms = new MemoryStream();
            XmlDictionaryWriter writer = XmlDictionaryWriter.CreateBinaryWriter(ms);
            writer.WriteStartElement("Binary");
            writer.WriteBase64(bodyBytes, 0, bodyBytes.Length);
            writer.WriteEndElement();
            writer.Flush();
            ms.Position = 0;
            XmlDictionaryReader reader = XmlDictionaryReader.CreateBinaryReader(ms, XmlDictionaryReaderQuotas.Max);
            Message newMessage = Message.CreateMessage(reader, int.MaxValue, message.Version);
            newMessage.Properties.CopyProperties(message.Properties);
            newMessage.Headers.CopyHeadersFrom(message);
            message = newMessage;
            return messageBody;
        }
    }
}