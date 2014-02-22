using System.IO;
using System.Xml;
using System.Xml.Serialization;
using eZet.Eve.EoLib.Dto.EveApi;
using XmlElement = eZet.Eve.EoLib.Dto.EveApi.XmlElement;

namespace eZet.Eve.EoLib.Util {
    public class XmlSerializerWrapper : IXmlSerializer {
        public XmlResponse<T> Deserialize<T>(string data) where T : XmlElement {
            var serializer = new XmlSerializer(typeof(XmlResponse<T>));
            XmlResponse<T> xmlResponse;
            using (var reader = XmlReader.Create(new StringReader(data))) {
                xmlResponse = (XmlResponse<T>)serializer.Deserialize(reader);
            }
            return xmlResponse;
        }
    }
}
