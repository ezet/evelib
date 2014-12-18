// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Lars Kristian
// Created          : 12-16-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 12-17-2014
// ***********************************************************************
// <copyright file="MarketHistoryCollection.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eZet.EveLib.EveCrestModule.Models.Resources.Market {
    /// <summary>
    ///     Represents a CREST market history response
    /// </summary>
    [DataContract]
    public sealed class MarketHistoryCollection : CollectionResource<MarketHistoryCollection, MarketHistoryCollection.MarketHistoryEntry> {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MarketHistoryCollection" /> class.
        /// </summary>
        public MarketHistoryCollection() {
            ContentType = "application/vnd.ccp.eve.MarketTypeHistoryCollection-v1+json";
        }

        /// <summary>
        ///     Class MarketHistoryEntry.
        /// </summary>
        [DataContract]
        public class MarketHistoryEntry {
            /// <summary>
            ///     The volume of items moved
            /// </summary>
            /// <value>The volume.</value>
            [DataMember(Name = "volume")]
            public long Volume { get; set; }

            /// <summary>
            ///     The number of orders
            /// </summary>
            /// <value>The order count.</value>
            [DataMember(Name = "orderCount")]
            public long OrderCount { get; set; }

            /// <summary>
            ///     The lowest price
            /// </summary>
            /// <value>The low price.</value>
            [DataMember(Name = "lowPrice")]
            public double LowPrice { get; set; }

            /// <summary>
            ///     The highst price
            /// </summary>
            /// <value>The high price.</value>
            [DataMember(Name = "highPrice")]
            public double HighPrice { get; set; }

            /// <summary>
            ///     The average price
            /// </summary>
            /// <value>The average price.</value>
            [DataMember(Name = "avgPrice")]
            public double AvgPrice { get; set; }

            /// <summary>
            ///     The date this entry represents
            /// </summary>
            /// <value>The date.</value>
            [DataMember(Name = "date")]
            public DateTime Date { get; set; }
        }
    }
}