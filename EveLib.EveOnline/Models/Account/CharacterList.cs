using System;
using System.Xml.Serialization;

namespace eZet.EveLib.Modules.Models.Account {
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class CharacterList {
        [XmlElement("rowset")] public EveOnlineRowCollection<CharacterInfo> Characters;

        [Serializable]
        [XmlRoot("row", IsNullable = false)]
        public class CharacterInfo {
            [XmlAttribute("characterName")]
            public string CharacterName { get; set; }

            [XmlAttribute("characterID")]
            public long CharacterId { get; set; }

            [XmlAttribute("corporationName")]
            public string CorporationName { get; set; }

            [XmlAttribute("corporationID")]
            public long corporationId { get; set; }

            [XmlAttribute("allianceName")]
            public string AllianceName { get; set; }

            [XmlAttribute("AllianceID")]
            public long AllianceId { get; set; }

            [XmlAttribute("factionName")]
            public string FactionName { get; set; }

            [XmlAttribute("factionID")]
            public long FactionId { get; set; }
        }
    }
}