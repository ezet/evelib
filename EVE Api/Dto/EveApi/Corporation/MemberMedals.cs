using System;
using System.Xml.Serialization;

namespace eZet.Eve.EveApi.Dto.EveApi.Corporation {
    public class MemberMedals : XmlResult {

        [XmlElement("rowset")]
        public XmlRowSet<Medal> Medals { get; set; }


        [Serializable]
        [XmlRoot("row")]
        public class Medal {
            
            [XmlAttribute("medalID")]
            public long MedalId { get; set; }
            
            [XmlAttribute("characterID")]
            public long CharacterId { get; set; }

            [XmlAttribute("reason")]
            public string Reason { get; set; }

            [XmlAttribute("status")]
            public string Status { get; set; }

            [XmlAttribute("issuerID")]
            public long IssuerId { get; set; }

            // TODO DateTime
            [XmlAttribute("issued")]
            public string Issued { get; set; }
        }
    }
}
