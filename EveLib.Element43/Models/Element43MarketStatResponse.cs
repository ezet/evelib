// ***********************************************************************
// Assembly         : EveLib.Element43
// Author           : Lars Kristian
// Created          : 04-14-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 11-03-2014
// ***********************************************************************
// <copyright file="Element43MarketStatResponse.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace eZet.EveLib.Modules.Models {
    /// <summary>
    /// Class Element43MarketStatResponse.
    /// </summary>
    [Serializable]
    [XmlType(AnonymousType = true)]
    [XmlRoot(ElementName = "e43_api", IsNullable = false)]
    public class Element43MarketStatResponse {
        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>The result.</value>
        [XmlArray("marketstat"), XmlArrayItem("type")]
        public Collection<Element43MarketStatItem> Result { get; set; }
    }

    /// <summary>
    /// Class Element43MarketStatItem.
    /// </summary>
    public class Element43MarketStatItem {
        /// <summary>
        /// Gets or sets the type identifier.
        /// </summary>
        /// <value>The type identifier.</value>
        [XmlAttribute("id")]
        public int TypeId { get; set; }

        /// <summary>
        /// Gets or sets the buy orders.
        /// </summary>
        /// <value>The buy orders.</value>
        [XmlElement("buy")]
        public Element43MarketStatOrderData BuyOrders { get; set; }

        /// <summary>
        /// Gets or sets the sell orders.
        /// </summary>
        /// <value>The sell orders.</value>
        [XmlElement("sell")]
        public Element43MarketStatOrderData SellOrders { get; set; }

        /// <summary>
        /// Gets or sets the last update.
        /// </summary>
        /// <value>The last update.</value>
        [XmlElement("lastupdate")]
        public DateTime LastUpdate { get; set; }

        /// <summary>
        /// Gets or sets the volume last week.
        /// </summary>
        /// <value>The volume last week.</value>
        [XmlElement("traded_last_7")]
        public long VolumeLastWeek { get; set; }
    }

    /// <summary>
    /// Class Element43MarketStatOrderData.
    /// </summary>
    public class Element43MarketStatOrderData {
        /// <summary>
        /// Gets or sets the volume.
        /// </summary>
        /// <value>The volume.</value>
        [XmlElement("volume")]
        public long Volume { get; set; }

        /// <summary>
        /// Gets or sets the average.
        /// </summary>
        /// <value>The average.</value>
        [XmlElement("avg")]
        public decimal Average { get; set; }

        /// <summary>
        /// Gets or sets the maximum.
        /// </summary>
        /// <value>The maximum.</value>
        [XmlElement("max")]
        public decimal Max { get; set; }

        /// <summary>
        /// Gets or sets the minimum.
        /// </summary>
        /// <value>The minimum.</value>
        [XmlElement("min")]
        public decimal Min { get; set; }

        /// <summary>
        /// Gets or sets the standard dev.
        /// </summary>
        /// <value>The standard dev.</value>
        [XmlElement("stddev")]
        public double StdDev { get; set; }

        /// <summary>
        /// Gets or sets the median.
        /// </summary>
        /// <value>The median.</value>
        [XmlElement("median")]
        public decimal Median { get; set; }

        /// <summary>
        /// Gets or sets the percentile.
        /// </summary>
        /// <value>The percentile.</value>
        [XmlElement("percentile")]
        public decimal Percentile { get; set; }
    }
}