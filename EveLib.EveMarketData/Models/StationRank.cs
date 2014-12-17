// ***********************************************************************
// Assembly         : EveLib.EveMarketData
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="StationRank.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using eZet.EveLib.EveMarketDataModule.JsonConverters;
using Newtonsoft.Json;

namespace eZet.EveLib.EveMarketDataModule.Models {
    /// <summary>
    ///     Class StationRank.
    /// </summary>
    [DataContract]
    [JsonConverter(typeof (EmdStationRankJsonConverter))]
    public class StationRank {
        /// <summary>
        ///     Gets or sets the stations.
        /// </summary>
        /// <value>The stations.</value>
        [DataMember(Name = "result")]
        [XmlElement("rowset")]
        public EmdRowCollection<StationRankEntry> Stations { get; set; }

        /// <summary>
        ///     Class StationRankEntry.
        /// </summary>
        [DataContract]
        [XmlRoot("row")]
        public class StationRankEntry {
            /// <summary>
            ///     Gets or sets the station identifier.
            /// </summary>
            /// <value>The station identifier.</value>
            [DataMember(Name = "stationID")]
            [XmlAttribute("stationID")]
            public int StationId { get; set; }

            /// <summary>
            ///     Gets or sets the date.
            /// </summary>
            /// <value>The date.</value>
            [DataMember(Name = "date")]
            [XmlAttribute("date")]
            public DateTime Date { get; set; }

            /// <summary>
            ///     Gets or sets the rank by orders.
            /// </summary>
            /// <value>The rank by orders.</value>
            [DataMember(Name = "rankOrders")]
            [XmlAttribute("rankOrders")]
            public int RankByOrders { get; set; }

            /// <summary>
            ///     Gets or sets the rank by price.
            /// </summary>
            /// <value>The rank by price.</value>
            [DataMember(Name = "rankPrice")]
            [XmlAttribute("rankPrice")]
            public int RankByPrice { get; set; }

            /// <summary>
            ///     Gets or sets the sell orders.
            /// </summary>
            /// <value>The sell orders.</value>
            [DataMember(Name = "countSell")]
            [XmlAttribute("countSell")]
            public long SellOrders { get; set; }

            /// <summary>
            ///     Gets or sets the buy orders.
            /// </summary>
            /// <value>The buy orders.</value>
            [DataMember(Name = "countBuy")]
            [XmlAttribute("countBuy")]
            public long BuyOrders { get; set; }

            /// <summary>
            ///     Gets or sets the sell total.
            /// </summary>
            /// <value>The sell total.</value>
            [DataMember(Name = "priceTotalSell")]
            [XmlAttribute("priceTotalSell")]
            public decimal SellTotal { get; set; }

            /// <summary>
            ///     Gets or sets the buy total.
            /// </summary>
            /// <value>The buy total.</value>
            [DataMember(Name = "priceTotalBuy")]
            [XmlAttribute("priceTotalBuy")]
            public decimal BuyTotal { get; set; }

            /// <summary>
            ///     Gets or sets the average sell price.
            /// </summary>
            /// <value>The average sell price.</value>
            [DataMember(Name = "priceAvgSell")]
            [XmlAttribute("priceAvgSell")]
            public decimal AvgSellPrice { get; set; }

            /// <summary>
            ///     Gets or sets the average buy price.
            /// </summary>
            /// <value>The average buy price.</value>
            [DataMember(Name = "priceAvgBuy")]
            [XmlAttribute("priceAvgBuy")]
            public decimal AvgBuyPrice { get; set; }
        }
    }
}