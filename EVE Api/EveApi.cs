using System.Linq;
using eZet.Eve.EveApi.Dto.EveApi;
using eZet.Eve.EveApi.Entity;
using Character = eZet.Eve.EveApi.Entity.Character;

namespace eZet.Eve.EveApi {
    public class EveApi {

        public ApiKey ApiKey { get; private set; }

        private static int keyId = 3053778;
        
        private static string vCode = "Hu3uslqNc3HDP8XmMMt1Cgb56TpPqqnF2tXssniROFkIMEDLztLPD8ktx6q5WVC2";

        private static string authString = "keyId=3053778&vCode=Hu3uslqNc3HDP8XmMMt1Cgb56TpPqqnF2tXssniROFkIMEDLztLPD8ktx6q5WVC2&characterId=977615922";
        
        
        private static int id = 977615922;

        public int CharacterId { get; private set; }

        public Account Account { get; private set; }

        public Character Character { get; private set; }

        public Core Core { get; private set; }

        public Map Map { get; private set; }

        public EveCentral EveCentral { get; private set; }

        public Image Image { get; private set; }


        static public void Main() {
            var api = new EveApi(keyId, vCode, id);

            var xml = api.Character.GetContactList();
            //var charlist = api.Account.GetCharacterList();
            //var c = charlist.Result.Characters.Rows.First().Load();
            //var trans = c.GetWalletTransactions();
            //var sheet = c.GetCharacterSheet();
            return;
        }

        public EveApi() {
            Core = new Core();
            Map = new Map();
            EveCentral = new EveCentral();
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
