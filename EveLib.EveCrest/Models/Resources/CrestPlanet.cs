using System.Runtime.Serialization;
using eZet.EveLib.Modules.Models.Entities;
using eZet.EveLib.Modules.Models.Shared;

namespace eZet.EveLib.Modules.Models.Resources {
    [DataContract]
    public sealed class CrestPlanet : CrestResource {
        public CrestPlanet() {
            Version = "application/vnd.ccp.eve.Planet-v1+json";
        }

        [DataMember(Name = "position")]
        public CrestPosition Position { get; set; }

        [DataMember(Name = "type")]
        public CrestHref<CrestItemType> Type { get; set; }

        [DataMember(Name = "system")]
        public CrestLinkedEntity<CrestSolarSystem> System { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}