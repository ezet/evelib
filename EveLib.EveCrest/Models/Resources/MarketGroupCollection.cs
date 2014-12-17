using System.Collections.Generic;
using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Links;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    [DataContract]
    public sealed class MarketGroupCollection : CollectionResource<MarketGroupCollection> {
        public MarketGroupCollection() {
            Version = "application/vnd.ccp.eve.MarketGroupCollection-v1+json";
        }

        [DataMember(Name = "items")]
        public IReadOnlyCollection<MarketGroup> Items { get; set; }

        public class MarketGroup : LinkedEntity<MarketGroup> {
            [DataMember(Name = "description")]
            public string Description { get; set; }

            [DataMember(Name = "types")]
            public LinkedEntity<MarketTypeCollection> Types { get; set; }
        }
    }
}