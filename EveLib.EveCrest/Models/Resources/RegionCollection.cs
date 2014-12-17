using System.Collections.Generic;
using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Links;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    [DataContract]
    public sealed class RegionCollection : CollectionResource<RegionCollection> {
        public RegionCollection() {
            Version = "application/vnd.ccp.eve.RegionCollection-v1+json";
        }

        [DataMember(Name = "items")]
        public IReadOnlyCollection<LinkedEntity<Region>> Items { get; set; }
    }
}