using eZet.Eve.EveLib.Entity.EveApi;

namespace eZet.Eve.EveLib.Exception.EveApi {
    public class IllegalCharacterIdException : System.Exception {
        public IllegalCharacterIdException(string message, ApiKey key, long characterId) : base(message) {
            Key = key;
            CharacterId = characterId;
        }

        public ApiKey Key { get; private set; }

        public long CharacterId { get; private set; }
    }
}