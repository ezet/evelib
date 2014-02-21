using System.IO;
using System.Xml;
using System.Xml.Serialization;
using eZet.Eve.EoLib.Dto.EveApi;

namespace eZet.Eve.EoLib.Util {
    public class XmlSerializerWrapper : IXmlSerializer {
        public XmlResponse<T> Deserialize<T>(string data) where T : XmlResult {
            var serializer = new XmlSerializer(typeof(XmlResponse<T>));
            XmlResponse<T> xmlResponse;
            using (var reader = XmlReader.Create(new StringReader(data))) {
                xmlResponse = (XmlResponse<T>)serializer.Deserialize(reader);
            }
            return xmlResponse;
        }
    }
}
