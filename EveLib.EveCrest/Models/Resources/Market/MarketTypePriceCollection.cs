// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Lars Kristian
// Created          : 12-16-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 12-17-2014
// ***********************************************************************
// <copyright file="MarketTypePriceCollection.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Links;

namespace eZet.EveLib.EveCrestModule.Models.Resources.Market {
    /// <summary>
    ///     Represents CREST market prices
    /// </summary>
    [DataContract]
    public sealed class MarketTypePriceCollection : CollectionResource<MarketTypePriceCollection> {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MarketTypePriceCollection" /> class.
        /// </summary>
        public MarketTypePriceCollection() {
            ContentType = "application/vnd.ccp.eve.MarketTypePriceCollection-v1+json";
        }

        /// <summary>
        ///     A list of market price entries
        /// </summary>
        /// <value>The prices.</value>
        [DataMember(Name = "items")]
        public IReadOnlyList<MarketPriceEntry> Prices { get; set; }

        /// <summary>
        ///     Represents an entry in the Market Price Response collection
        /// </summary>
        [DataContract]
        public class MarketPriceEntry {
            /// <summary>
            ///     The item type
            /// </summary>
            /// <value>The type.</value>
            [DataMember(Name = "type")]
            public LinkedEntity<ItemType> Type { get; set; }

            /// <summary>
            ///     The estimated value as displayed in game
            /// </summary>
            /// <value>The average price.</value>
            [DataMember(Name = "averagePrice")]
            public double AveragePrice { get; set; }

            /// <summary>
            ///     The adjusted price, used for some internal calculations and valuations, ie. industry
            /// </summary>
            /// <value>The adjusted price.</value>
            [DataMember(Name = "adjustedPrice")]
            public double AdjustedPrice { get; set; }
        }
    }
}