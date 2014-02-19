using eZet.Eve.EveApi.Dto.EveApi;
using System;

using eZet.Eve.EveApi.Dto.EveApi.Character;

namespace eZet.Eve.EveApi.Entity {

    public class Character : EveApiEntity {

        public const int AccountKey = 1000;

        public string Name { get; private set; }

        public long Id { get; private set; }

        public Corporation Corporation { get; private set; }

        public Character(ApiKey key, long id) : base(key) {
            Id = id;
            load();
        }

        public Character(ApiKey key, string name, long id, string corporationName, long corporationId) : base(key) {
            Name = name;
            Id = id;
            Corporation = new Corporation(key, corporationName, corporationId);
        }


        public XmlResponse<AccountBalance> GetAccountBalance() {
            const string uri = "/char/AccountBalance.xml.aspx";
            var postString = WebHelper.GeneratePostString(ApiKey, "characterId", Id);
            return request(uri, new AccountBalance(), postString);
        }


        public XmlResponse<TransactionCollection> GetWalletTransactions() {
            const string uri = "/char/WalletTransactions.xml.aspx";
            var postString = WebHelper.GeneratePostString(ApiKey, "characterId", Id, "accountKey", AccountKey);
            return request(uri, new TransactionCollection(), postString);
        }

        public XmlResponse<CharacterSheet> GetCharacterSheet() {
            const string uri = "/char/CharacterSheet.xml.aspx";
            var postString = WebHelper.GeneratePostString(ApiKey, "characterId", Id);
            return request(uri, new CharacterSheet(), postString);
        }

        public override string ToString() {
            return String.Format("ID: {0}, CharacterName: {1}", Id, Name);
        }

        private void load() {
            var response = GetCharacterSheet();
            Corporation = new Corporation(ApiKey, response.Result.CorporationName, response.Result.CorporationId);
        }
    }
}
