using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace eZet.Eve.EveApi {
    public struct ApiKey {

        public int KeyId { get; private set; }

        public string VCode { get; private set; }

        public ApiKey(int keyId, string vCode) : this() {
            KeyId = keyId;
            VCode = vCode;
        }

        public string GetAuthString() {
            return "keyID=" + KeyId + "&vCode=" + VCode + "&";
        }
    }
}
