using eZet.EveLib.Core.Util;

namespace eZet.EveLib.Test.Mocks {
    public class TestSerializer : ISerializer {
        public T Deserialize<T>(string data) {
            return default(T);
        }
    }
}