using System.Collections.Generic;
using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Entities;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    [DataContract]
    public sealed class Region : CrestResource {
        public Region() {
            Version = "application/vnd.ccp.eve.Region-v1+json";
        }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "marketBuyOrders")]
        public Href<MarketOrderCollection> MarketBuyOrders { get; set; }

        [DataMember(Name = "marketSellOrders")]
        public Href<MarketOrderCollection> MarketSellOrders { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "constellations")]
        public IReadOnlyCollection<Href<Constellation>> Constellations { get; set; }
    }
}