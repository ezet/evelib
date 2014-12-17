using System.Collections.Generic;
using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Entities;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    [DataContract]
    public sealed class ItemGroupCollection : CollectionResource<ItemGroupCollection> {
        public ItemGroupCollection() {
            Version = "application/vnd.ccp.eve.ItemGroupCollection-v1+json";
        }

        [DataMember(Name = "items")]
        public IReadOnlyList<LinkedEntity<ItemGroup>> Items { get; set; }
    }
}