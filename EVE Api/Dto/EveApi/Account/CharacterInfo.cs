using System;
using System.Xml.Serialization;
using eZet.Eve.EolNet.Entity;

namespace eZet.Eve.EolNet.Dto.EveApi.Account {

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

        public Entity.Character Load() {
            return new Entity.Character(ApiKey, CharacterId, CorporationId);
        }
    }

}