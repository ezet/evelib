using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Links;
using eZet.EveLib.EveCrestModule.Models.Shared;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    [DataContract]
    public sealed class Planet : CrestResource<Planet> {
        public Planet() {
            Version = "application/vnd.ccp.eve.Planet-v1+json";
        }

        [DataMember(Name = "position")]
        public CrestPosition Position { get; set; }

        [DataMember(Name = "type")]
        public Href<ItemType> Type { get; set; }

        [DataMember(Name = "system")]
        public LinkedEntity<SolarSystem> System { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}