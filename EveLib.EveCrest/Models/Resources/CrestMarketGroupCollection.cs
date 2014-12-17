using System.Collections.Generic;
using System.Runtime.Serialization;
using eZet.EveLib.Modules.Models.Entities;

namespace eZet.EveLib.Modules.Models.Resources {
    [DataContract]
    public sealed class CrestMarketGroupCollection : CrestCollectionResource<CrestMarketGroupCollection> {
        public CrestMarketGroupCollection() {
            Version = "application/vnd.ccp.eve.MarketGroupCollection-v1+json";
        }

        [DataMember(Name = "items")]
        public IReadOnlyCollection<CrestMarketGroup> Items { get; set; }

        public class CrestMarketGroup : CrestLinkedEntity<CrestMarketGroup> {
            [DataMember(Name = "description")]
            public string Description { get; set; }

            [DataMember(Name = "types")]
            public CrestLinkedEntity<CrestMarketTypeCollection> Types { get; set; }
        }
    }
}