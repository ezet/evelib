using System.Collections.Generic;
using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Links;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    [DataContract]
    public sealed class ItemCategory : CrestResource<ItemCategory> {
        public ItemCategory() {
            Version = "application/vnd.ccp.eve.ItemCategory-v1+json";
        }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "groups")]
        public IReadOnlyCollection<LinkedEntity<ItemGroup>> Groups { get; set; }

        [DataMember(Name = "published")]
        public bool Published { get; set; }
    }
}