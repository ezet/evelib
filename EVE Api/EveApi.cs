using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace eZet.Eve.EveApi {
    public class EveApi {

        private static int keyId = 3053778;

        private static string vCode = "Hu3uslqNc3HDP8XmMMt1Cgb56TpPqqnF2tXssniROFkIMEDLztLPD8ktx6q5WVC2";

        private static int charId = 0;

        public int KeyId { get; private set; }

        public string VCode { get; private set; }

        public int CharId { get; private set; }

        public Character Character { get; private set; }

        public Corporation Corporation { get; private set; }

        public List<Character> characters = new List<Character>();

        static public void Main() {
            var api = new EveApi(keyId, vCode, charId);
            api.getCharacters();
        }

        public EveApi() {

        }

        public EveApi(int keyId, string vCode) {
            this.KeyId = keyId;
            this.VCode = vCode;
        }

        public EveApi(int keyId, string vCode, int charId) {
            this.KeyId = keyId;
            this.VCode = vCode;
            this.CharId = charId;
            Character = new Character(KeyId, VCode, CharId);
        }

        public void getCharacters() {
            var uri = "/account/Characters.xml.aspx" + WebHelper.getAuthString(KeyId, VCode);
            XDocument xml = WebHelper.Request(uri);

            var elements = xml.Element("eveapi").Element("result").Element("rowset").Elements();

            foreach (var row in elements) {
                string name = row.Attribute("name").Value;
                string id = row.Attribute("characterID").Value;
                string corporationName = row.Attribute("corporationName").Value;
                string corporationId = row.Attribute("corporationID").Value;
                var character = new Character(name, id, corporationName, corporationId);

            }
        }

        public void getStatus() {

        }

        public void getKeyInfo() {

        }

        public void AllianceList() {

        }
    }
}
