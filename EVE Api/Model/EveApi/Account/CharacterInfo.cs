using System;
using System.Xml.Serialization;

namespace eZet.Eve.EveLib.Model.EveApi.Account {

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
        public long CorporationId { get; set; }
 
    }

}