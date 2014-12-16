using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models {
    [DataContract]
    public sealed class CrestSolarSystem : CrestResource {
        public CrestSolarSystem() {
            Version = "application/vnd.ccp.eve.System-v1+json";
        }

        [DataMember(Name = "stats")]
        public CrestHref<CrestPlaceholderModel> Stats { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "securityStatus")]
        public double SecurityStatus { get; set; }

        [DataMember(Name = "securityClass")]
        public string SecurityClass { get; set; }

        [DataMember(Name = "href")]
        public CrestHref<CrestSolarSystem> Href { get; set; }

        [DataMember(Name = "planets")]
        public IReadOnlyCollection<CrestHref<CrestPlanet>> Planets { get; set; }

        [DataMember(Name = "position")]
        public CrestPosition Position { get; set; }

        [DataMember(Name = "constellation")]
        public CrestHref<CrestConstellation> Constellation { get; set; }
    }
}