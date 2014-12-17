// ***********************************************************************
// Assembly         : EveLib.EveMarketData
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="ItemOrders.cs" company="">
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
    ///     Class ItemOrders.
    /// </summary>
    [JsonConverter(typeof (EmdItemOrderJsonConverter))]
    [DataContract]
    public class ItemOrders {
        /// <summary>
        ///     Gets or sets the orders.
        /// </summary>
        /// <value>The orders.</value>
        [XmlElement("rowset")]
        [DataMember(Name = "result")]
        public EmdRowCollection<ItemOrderEntry> Orders { get; set; }

        /// <summary>
        ///     Class ItemOrderEntry.
        /// </summary>
        [XmlRoot("row")]
        [DataContract]
        public class ItemOrderEntry {
            /// <summary>
            ///     Gets or sets the type of the order.
            /// </summary>
            /// <value>The type of the order.</value>
            [XmlAttribute("buysell")]
            [DataMember(Name = "buysell")]
            public OrderType OrderType { get; set; }

            /// <summary>
            ///     Gets or sets the type identifier.
            /// </summary>
            /// <value>The type identifier.</value>
            [XmlAttribute("typeID")]
            [DataMember(Name = "typeID")]
            public int TypeId { get; set; }

            /// <summary>
            ///     Gets or sets the station identifier.
            /// </summary>
            /// <value>The station identifier.</value>
            [XmlAttribute("stationID")]
            [DataMember(Name = "stationID")]
            public int StationId { get; set; }

            /// <summary>
            ///     Gets or sets the solar system identifier.
            /// </summary>
            /// <value>The solar system identifier.</value>
            [XmlAttribute("solarsystemID")]
            [DataMember(Name = "solarsystemID")]
            public int SolarSystemId { get; set; }

            /// <summary>
            ///     Gets or sets the region identifier.
            /// </summary>
            /// <value>The region identifier.</value>
            [XmlAttribute("regionID")]
            [DataMember(Name = "regionID")]
            public int RegionId { get; set; }

            /// <summary>
            ///     Gets or sets the price.
            /// </summary>
            /// <value>The price.</value>
            [XmlAttribute("price")]
            [DataMember(Name = "price")]
            public decimal Price { get; set; }

            /// <summary>
            ///     Gets or sets the order identifier.
            /// </summary>
            /// <value>The order identifier.</value>
            [XmlAttribute("orderID")]
            [DataMember(Name = "orderID")]
            public long OrderId { get; set; }

            /// <summary>
            ///     Gets or sets the vol entered.
            /// </summary>
            /// <value>The vol entered.</value>
            [XmlAttribute("volEntered")]
            [DataMember(Name = "volEntered")]
            public long VolEntered { get; set; }

            /// <summary>
            ///     Gets or sets the vol remaining.
            /// </summary>
            /// <value>The vol remaining.</value>
            [XmlAttribute("volRemaining")]
            [DataMember(Name = "volRemaining")]
            public long VolRemaining { get; set; }

            /// <summary>
            ///     Gets or sets the minimum volume.
            /// </summary>
            /// <value>The minimum volume.</value>
            [XmlAttribute("minVolume")]
            [DataMember(Name = "minVolume")]
            public int MinVolume { get; set; }

            /// <summary>
            ///     Gets or sets the range.
            /// </summary>
            /// <value>The range.</value>
            [XmlAttribute("range")]
            [DataMember(Name = "range")]
            public int Range { get; set; }

            /// <summary>
            ///     Gets or sets the issued date.
            /// </summary>
            /// <value>The issued date.</value>
            [XmlAttribute("issued")]
            [DataMember(Name = "issued")]
            public DateTime IssuedDate { get; set; }

            /// <summary>
            ///     Gets or sets the expires date.
            /// </summary>
            /// <value>The expires date.</value>
            [XmlAttribute("expires")]
            [DataMember(Name = "expires")]
            public DateTime ExpiresDate { get; set; }

            /// <summary>
            ///     Gets or sets the created date.
            /// </summary>
            /// <value>The created date.</value>
            [XmlAttribute("created")]
            [DataMember(Name = "created")]
            public DateTime CreatedDate { get; set; }
        }
    }
}