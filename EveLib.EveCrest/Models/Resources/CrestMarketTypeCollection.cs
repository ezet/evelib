using System.Collections.Generic;
using System.Runtime.Serialization;
using eZet.EveLib.Modules.Models.Entities;

namespace eZet.EveLib.Modules.Models.Resources {
    [DataContract]
    public sealed class CrestMarketTypeCollection : CrestCollectionResource<CrestMarketGroupCollection> {
        public CrestMarketTypeCollection() {
            Version = "application/vnd.ccp.eve.MarketTypeCollection-v1+json";
        }

        [DataMember(Name = "items")]
        public IReadOnlyCollection<Item> Items { get; set; }


        [DataContract]
        public class Item {
            [DataMember(Name = "marketGroup")]
            public CrestLinkedEntity<CrestMarketGroup> MarketGroup { get; set; }

            [DataMember(Name = "type")]
            public TypeItem Type { get; set; }
        }

        [DataContract]
        public class TypeItem : CrestLinkedEntity<CrestItemType> {
            [DataMember(Name = "icon")]
            public CrestImageLink Icon { get; set; }
        }
    }
}