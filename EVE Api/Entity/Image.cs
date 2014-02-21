using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace eZet.Eve.EolNet.Entity {
    public class Image {

        private const string UriBase = "http://image.eveonline.com";

        public void GetCharacterPortrait() {
            const string path = "/CharacterInfo";

        }

        public void GetCorporationLogo() {
            const string path = "/Corporation";

        }

        public void GetAllianceLogo() {
            const string path = "/Alliance";
        }

        public void GetTypeIcon() {
            const string path = "/InventoryType";
        }

        public void GetRender() {
            const string path = "/Render";
        }

        public void GetOldPortrait() {
            const string path = "http://oldportraits.eveonline.com/CharacterInfo/<characterID>_256.jpg";
        }
    }
}
