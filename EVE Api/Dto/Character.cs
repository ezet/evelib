using System.Xml.Serialization;

namespace eZet.Eve.EveApi.Dto {
    public partial class Character {

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
            return new Entity.Character(ApiKey, Name, CharacterId, CorporationName, CorporationId);
        }


    }

}