using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace eZet.Eve.EveApi {
    public class Character {

        public const int AccountKey = 1000;

        public string Name { get; private set; }

        public int Id { get; private set; }

        public Corporation Corporation { get; private set; }

        public Auth ApiKey { get; private set; }

        public List<Transaction> Transactions { get; private set; }


        public Character(string name, int id, string corporationName, int corporationId, Auth apiKey) {
            this.Name = name;
            this.Id = id;
            this.ApiKey = apiKey;
            Corporation = new Corporation(corporationName, corporationId, apiKey);
        }


        public List<Transaction> getWalletTransactions() {
            string uri = "/char/WalletTransactions.xml.aspx";
            var args = new Dictionary<string, object>() { { "characterId", Id }, { "accountKey", AccountKey } };
            var xml = WebHelper.Request(uri, ApiKey, "characterId", Id, "accountKey", AccountKey);
            var elements = XmlHelper.getRows(xml);

            return Transactions;

        }

        public override string ToString() {
            return String.Format("ID: {0}, Name: {1}", Id, Name);
        }
    }
}
