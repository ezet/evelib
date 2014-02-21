using eZet.Eve.EoLib.Dto.EveApi;
using eZet.Eve.EoLib.Util;

namespace eZet.Eve.EoLib.Test {
    public class MockSerializer : IXmlSerializer {
        public XmlResponse<T> Deserialize<T>(string data) where T : XmlResult {
            return new XmlResponse<T>();
        }
    }
}
