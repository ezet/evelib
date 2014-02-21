using System;
using eZet.Eve.EoLib.Entity;

namespace eZet.Eve.EoLib.Exceptions {
    public class IllegalCharacterIdException : Exception {

        public ApiKey Key { get; private set; }

        public long CharacterId { get; private set; }

        public IllegalCharacterIdException(string message, ApiKey key, long characterId ) : base(message) {
            Key = key;
            CharacterId = characterId;
        }


    }
}
