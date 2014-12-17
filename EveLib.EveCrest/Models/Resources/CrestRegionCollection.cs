using System.Collections.Generic;
using System.Runtime.Serialization;
using eZet.EveLib.Modules.Models.Entities;

namespace eZet.EveLib.Modules.Models.Resources {
    [DataContract]
    public sealed class CrestRegionCollection : CrestCollectionResource<CrestRegionCollection> {
        public CrestRegionCollection() {
            Version = "application/vnd.ccp.eve.RegionCollection-v1+json";
        }

        [DataMember(Name = "items")]
        public IReadOnlyCollection<CrestLinkedEntity<CrestRegion>> Items { get; set; }
    }
}