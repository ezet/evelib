using eZet.Eve.EoLib.Model.EveApi;
using eZet.Eve.EoLib.Util;
using eZet.Eve.EoLib.Util.EveApi;

namespace eZet.Eve.EoLib.Test.Mocks {
    public class TestSerializer : IXmlSerializer {
        public XmlResponse<T> Deserialize<T>(string data) where T : new() {
            return new XmlResponse<T>();
        }
    }
}
