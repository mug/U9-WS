using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Xml;
using UFSoft.UBF.Util.Log;

namespace UFIDA.U9.Cust.Pub.WS.Base.Behavior.Endpoint
{
    public class Log4NetEndpointBehavior : IDispatchMessageInspector, IEndpointBehavior
    {
        private static readonly ILogger Logger = LoggerManager.GetLogger(typeof (Log4NetEndpointBehavior));

        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            StringBuilder sb = new StringBuilder();
            string guid = Guid.NewGuid().ToString();
            sb.AppendFormat("请求标识:{0}，调用前日志", guid).AppendLine();
            try
            {
                Uri requestUri = request.Headers.To;
                sb.AppendFormat("请求地址:{0}", requestUri).AppendLine();
                HttpRequestMessageProperty httpReq =
                    (HttpRequestMessageProperty) request.Properties[HttpRequestMessageProperty.Name];
                sb.AppendFormat("请求方式:{0}", httpReq.Method).AppendLine();
                sb.AppendLine("请求Headers:");
                foreach (string header in httpReq.Headers.AllKeys)
                {
                    if (string.IsNullOrEmpty(header)) continue;
                    if (header.ToLower() == "cookie") continue;
                    sb.AppendFormat("{0}:{1}", header, httpReq.Headers[header]).AppendLine();
                }
                MessageHeaders incomingMessageHeaders = OperationContext.Current.IncomingMessageHeaders;
                string currentActionName = incomingMessageHeaders.Action;
                if (string.IsNullOrEmpty(currentActionName))
                    currentActionName =
                        incomingMessageHeaders.To.Segments[incomingMessageHeaders.To.Segments.Length - 1];
                SynchronizedKeyedCollection<string, DispatchOperation> operations =
                    OperationContext.Current.EndpointDispatcher.DispatchRuntime.Operations;
                DispatchOperation operation = operations.FirstOrDefault(d => d.Name == currentActionName);
                if (operation != null)
                {
                    string actionName =
                        OperationContext.Current.IncomingMessageProperties["HttpOperationName"] as string;
                    Type hostType = OperationContext.Current.Host.Description.ServiceType;
                    sb.AppendFormat("请求类:{0}", hostType.FullName).AppendLine();
                    sb.AppendFormat("请求方法:{0}", actionName).AppendLine();
                }
                sb.AppendLine("请求内容:");
                sb.AppendLine(this.MessageToString(ref request));
                Logger.Error(sb.ToString());
            }
            catch (Exception ex)
            {
                Logger.Error("日志记录异常:{0}", ex);
            }
            return guid;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            try
            {
                string guid = correlationState as string;
                StringBuilder sb = new StringBuilder();
                if (!string.IsNullOrWhiteSpace(guid))
                    sb.AppendFormat("请求标识:{0}，调用后日志", guid).AppendLine();
                string replyString = this.MessageToString(ref reply);
                HttpResponseMessageProperty httpResp =
                    (HttpResponseMessageProperty) reply.Properties[HttpResponseMessageProperty.Name];
                sb.AppendFormat("返回状态:{0} / {1}", (int) httpResp.StatusCode, httpResp.StatusCode).AppendLine();
                sb.AppendLine("返回内容:");
                sb.AppendLine(replyString);
                Logger.Error(sb.ToString());
            }
            catch (Exception ex)
            {
                Logger.Error("日志记录异常:{0}", ex);
            }
        }

        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            endpointDispatcher.DispatchRuntime.MessageInspectors.Add(this);
        }

        public void Validate(ServiceEndpoint endpoint)
        {
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

        private string MessageToString(ref Message message)
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
                    return this.ReadRawBody(ref message);
            }
            message.WriteMessage(writer);
            writer.Flush();
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

        private string ReadRawBody(ref Message message)
        {
            XmlDictionaryReader bodyReader = message.GetReaderAtBodyContents();
            bodyReader.ReadStartElement("Binary");
            byte[] bodyBytes = bodyReader.ReadContentAsBase64();
            //MemoryStream ms1 = new MemoryStream(bodyBytes);
            //StreamReader sr = new StreamReader(ms1);
            //JsonSerializer serializer = JsonHelper.GetJsonSerializer();
            //var obj = serializer.Deserialize(sr, typeof(ReturnMessage<object>));
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