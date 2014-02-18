using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eZet.Eve.EveApi.Dto.EveApi;
using eZet.Eve.EveApi.Dto.EveApi.Core;

namespace eZet.Eve.EveApi.Entity {
    public class Core : EveApiEntity {


        public XmlResponse<AllianceList> GetAllianceList() {
            const string uri = "/eve/AllianceList.xml.aspx";
            return request(uri, new AllianceList());
        }

        public void GetCertificateTree() {

        }

        public void GetCharacterAffiliation() {

        }

        public void GetCharacterId() {

        }
    }
}
