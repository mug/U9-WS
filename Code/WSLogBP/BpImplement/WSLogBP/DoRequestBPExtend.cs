using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Services.Protocols;
using System.Xml;
using UFIDA.U9.Base;
using UFIDA.U9.Cust.Pub.WSLogBE;
using UFSoft.UBF.AopFrame;

namespace UFIDA.U9.Cust.Pub.WSLogBP
{
    /// <summary>
    ///     DoRequestBP partial
    /// </summary>
    public partial class DoRequestBP
    {
        internal BaseStrategy Select()
        {
            return new DoRequestBPImpementStrategy();
        }
    }

    #region  implement strategy	

    /// <summary>
    ///     Impement Implement
    /// </summary>
    internal class DoRequestBPImpementStrategy : BaseStrategy
    {
        public override object Do(object obj)
        {
            DoRequestBP bpObj = (DoRequestBP) obj;
            if (bpObj.WSLogID <= 0)
                throw new BpParameterException("DoRequestBP", "WSLogID");
            WSLog wsLog = WSLog.Finder.FindByID(bpObj.WSLogID);
            if (wsLog == null)
            {
                throw new Exception(string.Format("未找到对应ID:{0}的WSLog实体", bpObj.WSLogID));
            }
            if (wsLog.CallResult == CallResultEnum.Success)
            {
                throw new Exception("已执行成功,不允许重复执行");
            }
            string url = AddLogIDInUrl(wsLog.RequestUrl, wsLog.ID);
            RequestResultDTO resultDTO = new RequestResultDTO();
            resultDTO.WSLogID = wsLog.ID;
            //调用服务
            CallWebService(url, wsLog.RequestContent, resultDTO);
            return resultDTO;
        }

        /// <summary>
        ///     Url中添加LogID
        /// </summary>
        /// <param name="url"></param>
        /// <param name="logID"></param>
        /// <returns></returns>
        private string AddLogIDInUrl(string url, long logID)
        {
            UriBuilder uriBuilder = new UriBuilder(url);
            NameValueCollection paramValues = HttpUtility.ParseQueryString(uriBuilder.Query);
            paramValues["LogID"] = logID.ToString();
            uriBuilder.Query = paramValues.ToString();
            return uriBuilder.ToString();
        }

        /// <summary>
        ///     调用服务
        /// </summary>
        /// <param name="url"></param>
        /// <param name="requestXml"></param>
        /// <param name="resultDTO"></param>
        private static void CallWebService(string url, string requestXml, RequestResultDTO resultDTO)
        {
            XmlDocument soapEnvelopeXml = CreateSoapEnvelope(requestXml);
            HttpWebRequest webRequest = CreateWebRequest(url);
            InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequest);
            try
            {
                WebResponse reponse = webRequest.GetResponse();
                using (Stream stream = reponse.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        resultDTO.CallResult = CallResultEnum.Success;
                        resultDTO.ResponseContent = reader.ReadToEnd();
                        resultDTO.ErrorMessage = string.Empty;
                    }
                }
            }
            catch (WebException ex)
            {
                using (Stream stream = ex.Response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        resultDTO.CallResult = CallResultEnum.Failure;
                        resultDTO.ResponseContent = reader.ReadToEnd();
                        try
                        {
                            XmlDocument doc = new XmlDocument();
                            doc.LoadXml(resultDTO.ResponseContent);
                            if (doc.DocumentElement != null)
                            {
                                XmlNode errorMessageNode = doc.DocumentElement.SelectSingleNode("//ErrorMessage");
                                if (errorMessageNode != null)
                                    resultDTO.ErrorMessage = errorMessageNode.InnerText;
                            }
                        }
                        catch (Exception ex2)
                        {
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                resultDTO.CallResult = CallResultEnum.Failure;
                resultDTO.ResponseContent = string.Empty;
                resultDTO.ErrorMessage = ex.Message;
                // Something more serious happened
                // like for example you don't have network access
                // we cannot talk about a server exception here as
                // the server probably was never reached
            }
        }

        /// <summary>
        ///     创建WebRequest
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private static HttpWebRequest CreateWebRequest(string url)
        {
            HttpWebRequest webRequest = (HttpWebRequest) WebRequest.Create(url);
            //webRequest.Headers.Add("SOAPAction", action);
            webRequest.Headers.Add("LogID", "1");
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            //webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }

        /// <summary>
        ///     创建SoapEnvelope
        /// </summary>
        /// <param name="requestXml"></param>
        /// <returns></returns>
        private static XmlDocument CreateSoapEnvelope(string requestXml)
        {
            XmlDocument soapEnvelopeDocument = new XmlDocument();
            soapEnvelopeDocument.LoadXml(requestXml);
            return soapEnvelopeDocument;
        }

        /// <summary>
        ///     插入请求内容
        /// </summary>
        /// <param name="soapEnvelopeXml"></param>
        /// <param name="webRequest"></param>
        private static void InsertSoapEnvelopeIntoWebRequest(XmlDocument soapEnvelopeXml, HttpWebRequest webRequest)
        {
            using (Stream stream = webRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }
        }
    }

    #endregion
}