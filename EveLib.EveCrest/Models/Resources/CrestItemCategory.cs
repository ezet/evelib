using System.Collections.Generic;
using System.Runtime.Serialization;
using eZet.EveLib.Modules.Models.Entities;

namespace eZet.EveLib.Modules.Models.Resources {
    [DataContract]
    public sealed class CrestItemCategory : CrestResource {
        public CrestItemCategory() {
            Version = "application/vnd.ccp.eve.ItemCategory-v1+json";
        }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "groups")]
        public IReadOnlyCollection<CrestLinkedEntity<CrestItemGroup>> Groups { get; set; }

        [DataMember(Name = "published")]
        public bool Published { get; set; }
    }
}