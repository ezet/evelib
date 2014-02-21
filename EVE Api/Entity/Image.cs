using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace eZet.Eve.EoLib.Entity {
    public class Image {

        private const string UriBase = "http://image.eveonline.com";

        /// <summary>
        /// Returns the character portrait
        /// </summary>
        public void GetCharacterPortrait() {
            const string path = "/CharacterInfo";

        }

        /// <summary>
        /// Returns the corporation logo
        /// </summary>
        public void GetCorporationLogo() {
            const string path = "/Corporation";

        }

        /// <summary>
        /// Returns the alliance logo
        /// </summary>
        public void GetAllianceLogo() {
            const string path = "/Alliance";
        }

        /// <summary>
        /// Returns the type icon
        /// </summary>
        public void GetTypeIcon() {
            const string path = "/InventoryType";
        }

        /// <summary>
        /// Returns the render image
        /// </summary>
        public void GetRender() {
            const string path = "/Render";
        }

        /// <summary>
        /// Returns the old style character portrait
        /// </summary>
        public void GetOldPortrait() {
            const string path = "http://oldportraits.eveonline.com/CharacterInfo/<characterID>_256.jpg";
        }
    }
}
