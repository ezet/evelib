using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models {
    /// <summary>
    /// Represents CREST market prices
    /// </summary>
    [DataContract]
    public class CrestMarketPrices : CrestCollectionResponse {

        /// <summary>
        /// A list of market price entries
        /// </summary>
        [DataMember(Name = "items")]
        public List<MarketPriceEntry> Prices { get; set; }

        /// <summary>
        /// Represents an entry in the Market Price Response collection
        /// </summary>
        public class MarketPriceEntry : CrestNamedEntity {

            /// <summary>
            /// The estimated value as displayed in game
            /// </summary>
            [DataMember(Name = "averagePrice")]
            public decimal AveragePrice { get; set; }

            /// <summary>
            /// The adjusted price, used for some internal calculations and valuations, ie. industry
            /// </summary>
            [DataMember(Name = "adjustedPrice")]
            public decimal AdjustedPrice { get; set; }
        }
    }
}
