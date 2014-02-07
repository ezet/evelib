using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace eZet.Eve.EveApi {
    public class Character {


        public int KeyId { get; private set; }

        public string VCode { get; private set; }

        public int Id { get; private set; }

        public int AccountKey { get; private set; }

        public string Name { get; private set; }

        public int CorporationId { get; private set; }

        public string CorporationName { get; private set; }


        private string authString;

        public Character(string name, int id, string corporationName, int corporationId) {
            this.Name = name;
            this.Id = id;
            this.CorporationName = corporationName;
            this.CorporationId = corporationId;
        }

        public Character(int keyId, string keyCode, int characterId) {
            this.KeyId = keyId;
            this.VCode = keyCode;
            this.Id = characterId;
            AccountKey = 1000;
            authString = "?keyId=" + KeyId + "&vCode=" + VCode;
        }

        public void getTransactions() {
            long fromId = 0;
            int rowCount = 1000;
            string uri = "/char/WalletTransactions.xml.aspx" + authString;
            var args = new Dictionary<string, object>() { { "characterId", Id }, { "accountKey", AccountKey } };
            uri = WebHelper.createUri(uri, args);
            WebHelper.Request(uri);
        }
    }
}
