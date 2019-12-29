using System.ServiceModel.Channels;
using System.Xml;

namespace UFIDA.U9.Cust.Pub.WS.Base.Behavior.WebHttp
{
    public class RawBodyWriter : BodyWriter
    {
        private readonly byte[] _content;

        public RawBodyWriter(byte[] content)
            : base(true)
        {
            _content = content;
        }

        protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
        {
            writer.WriteStartElement("Binary");
            writer.WriteBase64(_content, 0, _content.Length);
            writer.WriteEndElement();
        }
    }
}