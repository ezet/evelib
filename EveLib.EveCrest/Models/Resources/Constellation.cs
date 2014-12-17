using System.Collections.Generic;
using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Entities;
using eZet.EveLib.EveCrestModule.Models.Shared;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    [DataContract]
    public sealed class Constellation : CrestResource {
        public Constellation() {
            Version = "application/vnd.ccp.eve.Constellation-v1+json";
        }

        [DataMember(Name = "position")]
        public CrestPosition Position { get; set; }

        [DataMember(Name = "region")]
        public Href<Region> Region { get; set; }

        [DataMember(Name = "systems")]
        public IReadOnlyCollection<Href<SolarSystem>> Systems { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}