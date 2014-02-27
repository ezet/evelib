using eZet.Eve.EveLib.Util;
using eZet.Eve.EveLib.Model.EveApi;
using eZet.Eve.EveLib.Util.EveApi;

namespace eZet.Eve.EveLib.Test.Mocks {
    public class TestSerializer : IXmlSerializer {
        public XmlResponse<T> Deserialize<T>(string data) where T : new() {
            return new XmlResponse<T>();
        }
    }
}
