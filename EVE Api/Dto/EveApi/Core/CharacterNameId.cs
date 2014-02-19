using System;
using System.Xml.Serialization;

namespace eZet.Eve.EveApi.Dto.EveApi.Core {
    public class CharacterNameId : XmlResult {

        [XmlElement("rowset")]
        public XmlRowSet<CharacterData> Characters { get; set; }

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
