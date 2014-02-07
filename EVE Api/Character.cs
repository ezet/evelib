using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace eZet.Eve.EveApi
{
    public class Character {

        private string uriBase = "https://api.eveonline.com";
        public int KeyId{ get; private set; }

        public string KeyCode { get; private set; }

        public int CharId { get; private set; }

        public Character(int keyId, string keyCode, int charId) {
            this.KeyId = keyId;
            this.KeyCode = keyCode;
            this.CharId = charId;
        }

        public void getWalletJournal() {
            string uri = "/char/WalletJournal.xml.aspx";
            Stream stream;
            var req = (HttpWebRequest)WebRequest.Create(uriBase + uri);
            try {
                using (HttpWebResponse response = (HttpWebResponse)req.GetResponse()) {
                    if (response.StatusCode == HttpStatusCode.OK) {
                        stream = response.GetResponseStream();
                    }
                }
            } catch (Exception e) {

            }
        }

        public string createUri(params string[] args) {


            return "";

        }







    }
}
