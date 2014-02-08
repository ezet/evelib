using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace eZet.Eve.EveApi {
    public class EveApi {

        public Auth ApiKey { get; private set; }

        private static int keyId = 3053778;

        private static string vCode = "Hu3uslqNc3HDP8XmMMt1Cgb56TpPqqnF2tXssniROFkIMEDLztLPD8ktx6q5WVC2";

        private static int charId = 0;

        public int CharId { get; private set; }

        public Character Character { get; private set; }

        public Corporation Corporation { get; private set; }

        private Dictionary<int, Character> characters = new Dictionary<int, Character>();

        static public void Main() {
            var api = new EveApi(keyId, vCode);
            var list = api.getCharacters();
            list.First().Value.getWalletTransactions();
        }

        public EveApi(int keyId, string vCode) {
            ApiKey = new Auth(keyId, vCode);
        }

        public EveApi(int keyId, string vCode, int charId)
            : this(keyId, vCode) {
            this.CharId = charId;
        }

        public Dictionary<int, Character> getCharacters() {
            var uri = "/account/Characters.xml.aspx";
            XDocument xml = WebHelper.Request(uri, ApiKey);
            var elements = XmlHelper.getRows(xml);
            foreach (var row in elements) {
                string name = row.Attribute("name").Value;
                int id = int.Parse(row.Attribute("characterID").Value);
                string corporationName = row.Attribute("corporationName").Value;
                int corporationId = int.Parse(row.Attribute("corporationID").Value);
                var character = new Character(name, id, corporationName, corporationId, ApiKey);
                characters.Add(id, character);
            }
            return characters;
        }

        public void getStatus() {

        }

        public void getKeyInfo() {

        }

        public void AllianceList() {

        }
    }
}
