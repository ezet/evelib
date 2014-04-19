using eZet.EveLib.Core.Util;

namespace eZet.EveLib.Test.Mocks {
    public class MockSerializer : ISerializer {
        public T Deserialize<T>(string data) {
            return default(T);
        }
    }
}