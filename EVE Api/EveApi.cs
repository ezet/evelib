using eZet.Eve.EveApi.Entity;
using eZet.Eve.EveApi.Exceptions;
using Character = eZet.Eve.EveApi.Entity.Character;

namespace eZet.Eve.EveApi {
 
    public class EveApi {

        public ApiKey ApiKey { get; private set; }       

        public Character Character { get; private set; }
        
        public Account Account { get; private set; }

        public Core Core { get; private set; }

        public Map Map { get; private set; }

        public EveCentral EveCentral { get; private set; }

        public Image Image { get; private set; }


        static public void Main() {
            var api = new EveApi();
            var key = new ApiKey(123, "123");
            var a = key.AccessMask;
            api.Core.GetErrorList();
        }

        public EveApi() {
            Core = new Core();
            Map = new Map();
            EveCentral = new EveCentral();
            Image = new Image();
        }

        public void SelectCharacter(long characterId) {
            verifyCharacter(ApiKey, characterId);
            Character = new Character(ApiKey, characterId);
        }

        public EveApi(ApiKey key) {
            ApiKey = key;
            Account = new Account(ApiKey);
        }

        public EveApi(ApiKey key, long characterId) : this(key) {
            verifyCharacter(key, characterId);
            Character = new Character(ApiKey, characterId);
        }

        public EveApi(int keyId, string vCode) : this(new ApiKey(keyId, vCode)) {
        }

        public EveApi(int keyId, string vCode, long characterId)
            : this(new ApiKey(keyId, vCode), characterId) {
        }

        private void verifyCharacter(ApiKey key, long id) {
            if (!key.CharacterIds.Contains(id))
                throw new IllegalCharacterIdException("The API Key is not valid for this character.", key, id);
        }
    }
}
