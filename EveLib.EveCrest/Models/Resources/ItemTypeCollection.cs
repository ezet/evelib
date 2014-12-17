using System.Collections.Generic;
using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Links;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    [DataContract]
    public sealed class ItemTypeCollection : CollectionResource<ItemTypeCollection> {
        public ItemTypeCollection() {
            Version = "application/vnd.ccp.eve.ItemTypeCollection-v1+json";
        }

        [DataMember(Name = "items")]
        public IReadOnlyCollection<LinkedEntity<ItemType>> Items { get; set; }
    }
}