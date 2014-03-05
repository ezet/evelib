using eZet.Eve.EveLib.Util;

namespace eZet.Eve.EveLib.Test.Mocks {
    public class TestSerializer : ISerializer {
        public T Deserialize<T>(string data) {
            return default(T);
        }
    }
}