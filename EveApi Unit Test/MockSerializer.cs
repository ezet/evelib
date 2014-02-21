using eZet.Eve.EolNet.Dto.EveApi;
using eZet.Eve.EolNet.Util;

namespace eZet.Eve.EolNet.Test {
    public class MockSerializer : IXmlSerializer {
        public XmlResponse<T> Deserialize<T>(string data) where T : XmlResult {
            return new XmlResponse<T>();
        }
    }
}
