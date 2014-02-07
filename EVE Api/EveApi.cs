using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eZet.Eve.EveApi {
    public class EveApi {

        private static int keyId = 3053778;

        private static string keyCode = "Hu3uslqNc3HDP8XmMMt1Cgb56TpPqqnF2tXssniROFkIMEDLztLPD8ktx6q5WVC2";

        private static int charId = 0;

        public int KeyId { get; private set; }

        public string KeyCode { get; private set; }

        public int CharId { get; private set; }

        public Character Character { get; private set; }

        public EveApi(int keyId, string keyCode, int charId) {
            this.KeyId = keyId;
            this.KeyCode = keyCode;
            this.CharId = charId;
            Character = new Character(KeyId, KeyCode, CharId);

        }


        static public void Main() {
            var api = new EveApi(keyId, keyCode, charId);

            api.Character.getWalletJournal();
        }


    }
}
