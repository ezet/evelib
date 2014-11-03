// ***********************************************************************
// Assembly         : EveLib.EveMarketData
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="EmdItemHistory.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Runtime.Serialization;
using System.Xml.Serialization;
using eZet.EveLib.Modules.JsonConverters;
using Newtonsoft.Json;

namespace eZet.EveLib.Modules.Models {
    /// <summary>
    ///     Class EmdItemHistory.
    /// </summary>
    [DataContract]
    [JsonConverter(typeof (EmdItemHistoryJsonConverter))]
    public class EmdItemHistory {
        /// <summary>
        ///     Gets or sets the history.
        /// </summary>
        /// <value>The history.</value>
        [DataMember(Name = "result")]
        [XmlElement("rowset")]
        public EveMarketDataRowCollection<ItemHistoryEntry> History { get; set; }

        /// <summary>
        ///     Class ItemHistoryEntry.
        /// </summary>
        [XmlRoot("row")]
        [DataContract]
        public class ItemHistoryEntry {
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
            ///     Gets or sets the date.
            /// </summary>
            /// <value>The date.</value>
            [XmlAttribute("date")]
            [DataMember(Name = "date")]
            public string Date { get; set; }

            /// <summary>
            ///     Gets or sets the minimum price.
            /// </summary>
            /// <value>The minimum price.</value>
            [XmlAttribute("lowPrice")]
            [DataMember(Name = "lowPrice")]
            public decimal MinPrice { get; set; }

            /// <summary>
            ///     Gets or sets the maximum price.
            /// </summary>
            /// <value>The maximum price.</value>
            [XmlAttribute("highPrice")]
            [DataMember(Name = "highPrice")]
            public decimal MaxPrice { get; set; }

            /// <summary>
            ///     Gets or sets the average price.
            /// </summary>
            /// <value>The average price.</value>
            [XmlAttribute("avgPrice")]
            [DataMember(Name = "avgPrice")]
            public decimal AvgPrice { get; set; }

            /// <summary>
            ///     Gets or sets the volume.
            /// </summary>
            /// <value>The volume.</value>
            [XmlAttribute("volume")]
            [DataMember(Name = "volume")]
            public long Volume { get; set; }

            /// <summary>
            ///     Gets or sets the orders.
            /// </summary>
            /// <value>The orders.</value>
            [XmlAttribute("orders")]
            [DataMember(Name = "orders")]
            public long Orders { get; set; }
        }
    }
}