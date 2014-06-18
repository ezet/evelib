using System;
using System.Xml.Serialization;

namespace eZet.EveLib.Modules.Models.Misc {
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class CharacterAffiliation {
        [XmlElement("rowset")]
        public EveOnlineRowCollection<CharacterAffiliationData> Characters { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class CharacterAffiliationData {
            [XmlAttribute("characterID")]
            public long CharacterId { get; set; }

            [XmlAttribute("characterName")]
            public string CharacterName { get; set; }

            [XmlAttribute("corporationID")]
            public long CorporationId { get; set; }

            [XmlAttribute("corporationName")]
            public string CorporationName { get; set; }

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