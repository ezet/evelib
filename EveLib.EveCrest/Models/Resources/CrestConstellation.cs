using System.Collections.Generic;
using System.Runtime.Serialization;
using eZet.EveLib.Modules.Models.Entities;
using eZet.EveLib.Modules.Models.Shared;

namespace eZet.EveLib.Modules.Models.Resources {
    [DataContract]
    public sealed class CrestConstellation : CrestResource {
        public CrestConstellation() {
            Version = "application/vnd.ccp.eve.Constellation-v1+json";
        }

        [DataMember(Name = "position")]
        public CrestPosition Position { get; set; }

        [DataMember(Name = "region")]
        public CrestHref<CrestRegion> Region { get; set; }

        [DataMember(Name = "systems")]
        public IReadOnlyCollection<CrestHref<CrestSolarSystem>> Systems { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}