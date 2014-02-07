using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace eZet.Eve.EveApi {
    public class WebHelper {

        private static string uriBase = "https://api.eveonline.com";

        public static string createUri(string uri, Dictionary<string, object> args) {
            return "";
        }

        public static XDocument Request(string uri) {
            Stream data = Stream.Null;
            var req = (HttpWebRequest)WebRequest.Create(uriBase + uri);
            var document = new XDocument("");
            try {
                using (HttpWebResponse response = (HttpWebResponse)req.GetResponse()) {
                    if (response.StatusCode == HttpStatusCode.OK) {
                        data = response.GetResponseStream();
                        document = XDocument.Load(data);
                    }
                }
            } catch (Exception e) {
                throw;
            }
            return document;
        }

        public static string getAuthString(int keyId, string vCode) {
            return "?keyId=" + keyId + "&vCode=" + vCode;
        }
    }
}
