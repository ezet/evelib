// ***********************************************************************
// Assembly         : EveLib.EveCentral
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="MarketStatResponse.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace eZet.EveLib.EveCentralModule.Models {
    /// <summary>
    ///     Class MarketStatResponse.
    /// </summary>
    [Serializable]
    [XmlType(AnonymousType = true)]
    [XmlRoot(ElementName = "evec_api", Namespace = "", IsNullable = false)]
    public class MarketStatResponse : EveCentralResponse {
        /// <summary>
        ///     Gets or sets the result.
        /// </summary>
        /// <value>The result.</value>
        [XmlArray("marketstat"), XmlArrayItem("type")]
        public Collection<EveCentralMarketStatItem> Result { get; set; }
    }

    /// <summary>
    ///     Class EveCentralMarketStatItem.
    /// </summary>
    public class EveCentralMarketStatItem {
        /// <summary>
        ///     Gets or sets the type identifier.
        /// </summary>
        /// <value>The type identifier.</value>
        [XmlAttribute("id")]
        public int TypeId { get; set; }

        /// <summary>
        ///     Gets or sets the buy orders.
        /// </summary>
        /// <value>The buy orders.</value>
        [XmlElement("buy")]
        public EveCentralMarketStatOrderData BuyOrders { get; set; }

        /// <summary>
        ///     Gets or sets the sell orders.
        /// </summary>
        /// <value>The sell orders.</value>
        [XmlElement("sell")]
        public EveCentralMarketStatOrderData SellOrders { get; set; }

        /// <summary>
        ///     Gets or sets all.
        /// </summary>
        /// <value>All.</value>
        [XmlElement("all")]
        public EveCentralMarketStatOrderData All { get; set; }
    }

    /// <summary>
    ///     Class EveCentralMarketStatOrderData.
    /// </summary>
    public class EveCentralMarketStatOrderData {
        /// <summary>
        ///     Gets or sets the volume.
        /// </summary>
        /// <value>The volume.</value>
        [XmlElement("volume")]
        public long Volume { get; set; }

        /// <summary>
        ///     Gets or sets the average.
        /// </summary>
        /// <value>The average.</value>
        [XmlElement("avg")]
        public decimal Average { get; set; }

        /// <summary>
        ///     Gets or sets the maximum.
        /// </summary>
        /// <value>The maximum.</value>
        [XmlElement("max")]
        public decimal Max { get; set; }

        /// <summary>
        ///     Gets or sets the minimum.
        /// </summary>
        /// <value>The minimum.</value>
        [XmlElement("min")]
        public decimal Min { get; set; }

        /// <summary>
        ///     Gets or sets the standard dev.
        /// </summary>
        /// <value>The standard dev.</value>
        [XmlElement("stddev")]
        public double StdDev { get; set; }

        /// <summary>
        ///     Gets or sets the median.
        /// </summary>
        /// <value>The median.</value>
        [XmlElement("median")]
        public decimal Median { get; set; }

        /// <summary>
        ///     Gets or sets the percentile.
        /// </summary>
        /// <value>The percentile.</value>
        [XmlElement("percentile")]
        public decimal Percentile { get; set; }
    }
}