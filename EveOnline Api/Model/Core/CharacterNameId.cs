using System;
using System.Xml.Serialization;

namespace eZet.EveLib.EveOnlineApi.Model.Core {
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class CharacterNameId : XmlElement {
        [XmlElement("rowset")]
        public RowCollection<CharacterData> Characters { get; set; }

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