using System.Collections.Generic;
using System.Runtime.Serialization;
using eZet.EveLib.Modules.Models.Entities;

namespace eZet.EveLib.Modules.Models.Resources {
    [DataContract]
    public sealed class CrestItemTypeCollection : CrestCollectionResource<CrestItemTypeCollection> {
        public CrestItemTypeCollection() {
            Version = "application/vnd.ccp.eve.ItemTypeCollection-v1+json";
        }

        [DataMember(Name = "items")]
        public IReadOnlyCollection<CrestLinkedEntity<CrestItemType>> Items { get; set; }
    }
}