using System.ServiceModel.Channels;

namespace UFIDA.U9.Cust.Pub.WS.Base.Behavior.WebHttp
{
    public class NewtonsoftJsonContentTypeMapper : WebContentTypeMapper
    {
        public override WebContentFormat GetMessageFormatForContentType(string contentType)
        {
            return WebContentFormat.Raw;
        }
    }
}