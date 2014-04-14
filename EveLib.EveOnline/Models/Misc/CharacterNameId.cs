using System;
using System.Xml.Serialization;

namespace eZet.EveLib.Modules.Models.Misc {
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class CharacterNameId {
        [XmlElement("rowset")]
        public EveOnlineRowCollection<CharacterData> Characters { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class CharacterData {
            [XmlAttribute("name")]
            public string CharacterName { get; set; }

            [XmlAttribute("characterID")]
            public long CharacterId { get; set; }
        }
    }
}