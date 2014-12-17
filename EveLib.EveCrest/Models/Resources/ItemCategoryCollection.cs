using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Links;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    [DataContract]
    public sealed class ItemCategoryCollection : CollectionResource<ItemCategoryCollection> {
        public ItemCategoryCollection() {
            Version = "application/vnd.ccp.eve.ItemCategoryCollection-v1+json";
        }

        [DataMember(Name = "items")]
        public ReadOnlyCollection<LinkedEntity<ItemCategory>> Items { get; set; }
    }
}