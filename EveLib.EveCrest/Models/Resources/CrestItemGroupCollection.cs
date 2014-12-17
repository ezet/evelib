using System.Collections.Generic;
using System.Runtime.Serialization;
using eZet.EveLib.Modules.Models.Entities;

namespace eZet.EveLib.Modules.Models.Resources {
    [DataContract]
    public sealed class CrestItemGroupCollection : CrestCollectionResource<CrestItemGroupCollection> {
        public CrestItemGroupCollection() {
            Version = "application/vnd.ccp.eve.ItemGroupCollection-v1+json";
        }

        [DataMember(Name = "items")]
        public IReadOnlyList<CrestLinkedEntity<CrestItemGroup>> Items { get; set; }
    }
}