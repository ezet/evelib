using System.Collections.Generic;
using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Entities;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    [DataContract]
    public sealed class ItemGroup : CrestResource {
        public ItemGroup() {
            Version = "application/vnd.ccp.eve.ItemCategory-v1+json";
        }

        [DataMember(Name = "category")]
        public Href<ItemCategory> Category { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "types")]
        public IReadOnlyCollection<LinkedEntity<ItemType>> Types { get; set; }

        [DataMember(Name = "published")]
        public bool Published { get; set; }
    }
}