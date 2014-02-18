using eZet.Eve.EveApi.Dto.EveApi;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

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
            return request(uri, postString, new AccountBalance());
        }


        public XmlResponse<TransactionCollection> GetWalletTransactions() {
            const string uri = "/char/WalletTransactions.xml.aspx";
            var postString = WebHelper.GeneratePostString(ApiKey, "characterId", Id, "accountKey", AccountKey);
            return request(uri, postString, new TransactionCollection());
        }

        public XmlResponse<CharacterSheet> GetCharacterSheet() {
            const string uri = "/char/CharacterSheet.xml.aspx";
            var postString = WebHelper.GeneratePostString(ApiKey, "characterId", Id);
            return request(uri, postString, new CharacterSheet());
        }

        public override string ToString() {
            return String.Format("ID: {0}, Name: {1}", Id, Name);
        }

        private void load() {
            var response = GetCharacterSheet();
            Corporation = new Corporation(ApiKey, response.Result.CorporationName, response.Result.CorporationId);
        }
    }
}
