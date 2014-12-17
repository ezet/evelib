using System.Collections.Generic;
using System.Runtime.Serialization;
using eZet.EveLib.Modules.Models.Entities;

namespace eZet.EveLib.Modules.Models.Resources {
    [DataContract]
    public sealed class CrestRegion : CrestResource {
        public CrestRegion() {
            Version = "application/vnd.ccp.eve.Region-v1+json";
        }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "marketBuyOrders")]
        public CrestHref<CrestMarketOrderCollection> MarketBuyOrders { get; set; }

        [DataMember(Name = "marketSellOrders")]
        public CrestHref<CrestMarketOrderCollection> MarketSellOrders { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "constellations")]
        public IReadOnlyCollection<CrestHref<CrestConstellation>> Constellations { get; set; }
    }
}