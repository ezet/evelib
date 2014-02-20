using System.Xml.Serialization;
using eZet.Eve.EveApi.Entity;
using Character = eZet.Eve.EveApi.Entity.Character;

namespace eZet.Eve.EveApi {

 
    public class EveApi {

        public ApiKey ApiKey { get; private set; }       

        public int CharacterId { get; private set; }

        public Account Account { get; private set; }

        public Character Character { get; private set; }

        public Core Core { get; private set; }

        public Map Map { get; private set; }

        public EveCentral EveCentral { get; private set; }

        public Image Image { get; private set; }


        static public void Main() {
            var api = new EveApi();
            var xml = api.Core.GetErrorList();
            return;

        }

        public EveApi() {
            Core = new Core();
            Map = new Map();
            EveCentral = new EveCentral();
            Image = new Image();
        }

        public EveApi(int keyId, string vCode) : this() {
            ApiKey = new ApiKey(keyId, vCode);
            Account = new Account(ApiKey);
        }

        public EveApi(int keyId, string vCode, int characterId)
            : this(keyId, vCode) {
                Character = new Character(ApiKey, characterId);
        }
    }
}
