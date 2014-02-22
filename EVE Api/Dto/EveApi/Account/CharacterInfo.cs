using System;
using System.Xml.Serialization;

namespace eZet.Eve.EoLib.Dto.EveApi.Account {

    [Serializable]
    [XmlRoot("row")]
    public class CharacterInfo {

        [XmlAttribute("characterName")]
        public string CharacterName { get; set; }

        [XmlAttribute("characterID")]
        public long CharacterId { get; set; }

        [XmlAttribute("corporationName")]
        public string CorporationName { get; set; }

        [XmlAttribute("corporationID")]
        public long CorporationId { get; set; }
 
    }

}