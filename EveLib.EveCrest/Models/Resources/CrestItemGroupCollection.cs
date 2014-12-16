using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models {
    [DataContract]
    public sealed class CrestItemGroupCollection : CrestCollectionResource<CrestItemGroupCollection> {
        public CrestItemGroupCollection() {
            Version = "application/vnd.ccp.eve.ItemGroupCollection-v1+json";
        }

        [DataMember(Name = "items")]
        public IReadOnlyList<CrestLinkedEntity<CrestItemGroup>> Items { get; set; }
    }
}