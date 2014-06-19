using eZet.EveLib.Core.Serializers;

namespace eZet.EveLib.Test.Mocks {
    public class NullSerializer : ISerializer {
        public T Deserialize<T>(string data) {
            return default(T);
        }
    }
}