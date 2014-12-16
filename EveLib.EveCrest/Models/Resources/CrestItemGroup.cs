using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models {
    [DataContract]
    public sealed class CrestItemGroup : CrestResource {
        public CrestItemGroup() {
            Version = "application/vnd.ccp.eve.ItemCategory-v1+json";
        }

        [DataMember(Name = "category")]
        public CrestHref<CrestItemCategory> Category { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "types")]
        public IReadOnlyCollection<CrestLinkedEntity<CrestItemType>> Types { get; set; }

        [DataMember(Name = "published")]
        public bool Published { get; set; }
    }
}