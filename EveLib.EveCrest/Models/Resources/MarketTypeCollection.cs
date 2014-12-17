using System.Collections.Generic;
using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Entities;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    [DataContract]
    public sealed class MarketTypeCollection : CollectionResource<MarketGroupCollection> {
        public MarketTypeCollection() {
            Version = "application/vnd.ccp.eve.MarketTypeCollection-v1+json";
        }

        [DataMember(Name = "items")]
        public IReadOnlyCollection<Item> Items { get; set; }


        [DataContract]
        public class Item {
            [DataMember(Name = "marketGroup")]
            public LinkedEntity<MarketGroup> MarketGroup { get; set; }

            [DataMember(Name = "type")]
            public TypeItem Type { get; set; }
        }

        [DataContract]
        public class TypeItem : LinkedEntity<ItemType> {
            [DataMember(Name = "icon")]
            public ImageLink Icon { get; set; }
        }
    }
}