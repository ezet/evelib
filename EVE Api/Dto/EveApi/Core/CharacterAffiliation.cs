using System;
using System.Xml.Serialization;

namespace eZet.Eve.EoLib.Dto.EveApi.Core {
    public class CharacterAffiliation : XmlResult {

        [XmlElement("rowset")]
        public XmlRowSet<CharacterAffiliationData> Characters { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class CharacterAffiliationData {

            [XmlAttribute("characterName")]
            public string CharacterName { get; set; }

            [XmlAttribute("characterID")]
            public long CharacterId { get; set; }

            [XmlAttribute("corporationName")]
            public string CorporationName { get; set; }

            [XmlAttribute("corporationID")]
            public long CorporationId { get; set; }

            [XmlAttribute("allianceName")]
            public string AllianceName { get; set; }

            [XmlAttribute("allianceID")]
            public long AllianceId { get; set; }

            [XmlAttribute("factionName")]
            public string FactionName { get; set; }

            [XmlAttribute("factionID")]
            public long FactionId { get; set; }

        }
    }

}
