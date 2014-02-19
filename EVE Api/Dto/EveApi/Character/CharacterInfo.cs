using System;
using System.Xml.Serialization;
using eZet.Eve.EveApi;

namespace eZet.Eve.EveApi.Dto.EveApi.Character {

    [Serializable]
    [XmlRoot("row")]
    public class CharacterInfo {

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("characterID")]
        public long CharacterId { get; set; }

        [XmlAttribute("corporationName")]
        public string CorporationName { get; set; }

        [XmlAttribute("corporationID")]
        public long CorporationId { get; set; }

        [XmlIgnore]
        public ApiKey ApiKey { get; set; }

        public Eve.EveApi.Entity.Character Load() {
            return new Eve.EveApi.Entity.Character(ApiKey, CharacterId, CorporationId);
        }
    }

}