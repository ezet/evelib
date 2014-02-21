using eZet.Eve.EveApi.Dto.EveApi;
using eZet.Eve.EveApi.Util;

namespace eZet.Eve.EveApi.Test {
    public class MockSerializer : IXmlSerializer {
        public XmlResponse<T> Deserialize<T>(string data) where T : XmlResult {
            return new XmlResponse<T>();
        }
    }
}
