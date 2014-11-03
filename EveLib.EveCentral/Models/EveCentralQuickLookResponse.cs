// ***********************************************************************
// Assembly         : EveLib.EveCentral
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="EveCentralQuickLookResponse.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace eZet.EveLib.Modules.Models {
    /// <summary>
    /// Class EveCentralQuickLookResponse.
    /// </summary>
    [Serializable]
    [XmlType(AnonymousType = true)]
    [XmlRoot(ElementName = "evec_api", Namespace = "", IsNullable = false)]
    public class EveCentralQuickLookResponse : EveCentralResponse {
        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>The result.</value>
        [XmlElement("quicklook")]
        public QuicklookResult Result { get; set; }
    }

    /// <summary>
    /// Class QuicklookResult.
    /// </summary>
    public class QuicklookResult {
        /// <summary>
        /// Gets or sets the type identifier.
        /// </summary>
        /// <value>The type identifier.</value>
        [XmlElement("item")]
        public int TypeId { get; set; }

        /// <summary>
        /// Gets or sets the name of the type.
        /// </summary>
        /// <value>The name of the type.</value>
        [XmlElement("itemname")]
        public string TypeName { get; set; }

        /// <summary>
        /// Gets or sets the hour limit.
        /// </summary>
        /// <value>The hour limit.</value>
        [XmlElement("hours")]
        public int HourLimit { get; set; }

        /// <summary>
        /// Gets or sets the minimum quantity.
        /// </summary>
        /// <value>The minimum quantity.</value>
        [XmlElement("minqty")]
        public int MinQuantity { get; set; }

        /// <summary>
        /// Gets or sets the regions.
        /// </summary>
        /// <value>The regions.</value>
        [XmlArray("regions"), XmlArrayItem("region")]
        public Collection<string> Regions { get; set; }

        /// <summary>
        /// Gets or sets the sell orders.
        /// </summary>
        /// <value>The sell orders.</value>
        [XmlArray("sell_orders"), XmlArrayItem("order")]
        public Collection<EveCentralQuicklookOrder> SellOrders { get; set; }

        /// <summary>
        /// Gets or sets the buy orders.
        /// </summary>
        /// <value>The buy orders.</value>
        [XmlArray("buy_orders"), XmlArrayItem("order")]
        public Collection<EveCentralQuicklookOrder> BuyOrders { get; set; }
    }

    /// <summary>
    /// Class EveCentralQuicklookOrder.
    /// </summary>
    public class EveCentralQuicklookOrder {
        /// <summary>
        /// Gets or sets the order identifier.
        /// </summary>
        /// <value>The order identifier.</value>
        [XmlAttribute("id")]
        public long OrderId { get; set; }

        /// <summary>
        /// Gets or sets the region identifier.
        /// </summary>
        /// <value>The region identifier.</value>
        [XmlElement("region")]
        public int RegionId { get; set; }

        /// <summary>
        /// Gets or sets the station identifier.
        /// </summary>
        /// <value>The station identifier.</value>
        [XmlElement("station")]
        public int StationId { get; set; }

        /// <summary>
        /// Gets or sets the name of the station.
        /// </summary>
        /// <value>The name of the station.</value>
        [XmlElement("station_name")]
        public string StationName { get; set; }

        /// <summary>
        /// Gets or sets the security rating.
        /// </summary>
        /// <value>The security rating.</value>
        [XmlElement("security")]
        public double SecurityRating { get; set; }

        /// <summary>
        /// Gets or sets the range.
        /// </summary>
        /// <value>The range.</value>
        [XmlElement("range")]
        public int Range { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>The price.</value>
        [XmlElement("price")]
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the vol remaining.
        /// </summary>
        /// <value>The vol remaining.</value>
        [XmlElement("vol_remain")]
        public int VolRemaining { get; set; }

        /// <summary>
        /// Gets or sets the minimum volume.
        /// </summary>
        /// <value>The minimum volume.</value>
        [XmlElement("min_volume")]
        public int MinVolume { get; set; }

        /// <summary>
        /// Gets or sets the expires.
        /// </summary>
        /// <value>The expires.</value>
        [XmlElement("expires")]
        public DateTime Expires { get; set; }

        /// <summary>
        /// Gets or sets the reported time.
        /// </summary>
        /// <value>The reported time.</value>
        [XmlElement("reported_time")]
        public string ReportedTime { get; set; }
    }
}