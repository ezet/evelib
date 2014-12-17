using System.Collections.Generic;
using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Entities;
using eZet.EveLib.EveCrestModule.Models.Shared;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    [DataContract]
    public sealed class SolarSystem : CrestResource {
        public SolarSystem() {
            Version = "application/vnd.ccp.eve.System-v1+json";
        }

        [DataMember(Name = "stats")]
        public Href<NotImplemented> Stats { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "securityStatus")]
        public double SecurityStatus { get; set; }

        [DataMember(Name = "securityClass")]
        public string SecurityClass { get; set; }

        [DataMember(Name = "href")]
        public Href<SolarSystem> Href { get; set; }

        [DataMember(Name = "planets")]
        public IReadOnlyCollection<Href<Planet>> Planets { get; set; }

        [DataMember(Name = "position")]
        public CrestPosition Position { get; set; }

        [DataMember(Name = "constellation")]
        public Href<Constellation> Constellation { get; set; }
    }
}