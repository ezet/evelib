using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eZet.Eve.EveApi {
    public class Auth {


        public int KeyId { get; private set; }

        public string VCode { get; private set; }

        public Auth(int keyId, string vCode) {
            this.KeyId = keyId;
            this.VCode = vCode;
        }

        public string getAuthString() {
            return "keyID=" + KeyId + "&vCode=" + VCode + "&";
        }


    }
}
