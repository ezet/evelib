using System.Collections.Generic;
using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Links;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    /// <summary>
    ///     Represents CREST market prices
    /// </summary>
    [DataContract]
    public sealed class MarketTypePriceCollection : CollectionResource<MarketTypePriceCollection> {
        public MarketTypePriceCollection() {
            Version = "application/vnd.ccp.eve.MarketTypePriceCollection-v1+json";
        }

        /// <summary>
        ///     A list of market price entries
        /// </summary>
        [DataMember(Name = "items")]
        public List<MarketPriceEntry> Prices { get; set; }

        /// <summary>
        ///     Represents an entry in the Market Price Response collection
        /// </summary>
        [DataContract]
        public class MarketPriceEntry {
            /// <summary>
            ///     The item type
            /// </summary>
            [DataMember(Name = "type")]
            public LinkedEntity<ItemType> Type { get; set; }

            /// <summary>
            ///     The estimated value as displayed in game
            /// </summary>
            [DataMember(Name = "averagePrice")]
            public double AveragePrice { get; set; }

            /// <summary>
            ///     The adjusted price, used for some internal calculations and valuations, ie. industry
            /// </summary>
            [DataMember(Name = "adjustedPrice")]
            public double AdjustedPrice { get; set; }
        }
    }
}