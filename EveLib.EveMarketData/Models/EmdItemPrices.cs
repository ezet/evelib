// ***********************************************************************
// Assembly         : EveLib.EveMarketData
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="EmdItemPrices.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using eZet.EveLib.Modules.JsonConverters;
using Newtonsoft.Json;

namespace eZet.EveLib.Modules.Models {
    /// <summary>
    ///     Class EmdItemPrices.
    /// </summary>
    [DataContract]
    [JsonConverter(typeof (EmdItemPricesJsonConverter))]
    public class EmdItemPrices {
        /// <summary>
        ///     Gets or sets the prices.
        /// </summary>
        /// <value>The prices.</value>
        [XmlElement("rowset")]
        [DataMember(Name = "result")]
        public EveMarketDataRowCollection<ItemPriceEntry> Prices { get; set; }

        /// <summary>
        ///     Class ItemPriceEntry.
        /// </summary>
        [DataContract]
        [XmlRoot("row")]
        public class ItemPriceEntry {
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
            ///     Gets or sets the updated.
            /// </summary>
            /// <value>The updated.</value>
            [XmlAttribute("updated")]
            [DataMember(Name = "updated")]
            public DateTime Updated { get; set; }
        }
    }
}