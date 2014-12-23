// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="MarketOrders.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Xml.Serialization;
using eZet.EveLib.EveXmlModule.Util;

namespace eZet.EveLib.EveXmlModule.Models.Character {
    /// <summary>
    ///     Class MarketOrders.
    /// </summary>
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class MarketOrders {
        /// <summary>
        ///     Gets or sets the orders.
        /// </summary>
        /// <value>The orders.</value>
        [XmlElement("rowset")]
        public EveXmlRowCollection<MarketOrder> Orders { get; set; }

        /// <summary>
        ///     Class MarketOrder.
        /// </summary>
        [Serializable]
        [XmlRoot("row")]
        public class MarketOrder {
            /// <summary>
            ///     Gets or sets the order identifier.
            /// </summary>
            /// <value>The order identifier.</value>
            [XmlAttribute("orderID")]
            public long OrderId { get; set; }

            /// <summary>
            ///     Gets or sets the character identifier.
            /// </summary>
            /// <value>The character identifier.</value>
            [XmlAttribute("charID")]
            public long CharacterId { get; set; }

            /// <summary>
            ///     Gets or sets the station identifier.
            /// </summary>
            /// <value>The station identifier.</value>
            [XmlAttribute("stationID")]
            public int StationId { get; set; }

            /// <summary>
            ///     Gets or sets the volume entered.
            /// </summary>
            /// <value>The volume entered.</value>
            [XmlAttribute("volEntered")]
            public int VolumeEntered { get; set; }

            /// <summary>
            ///     Gets or sets the volume remaining.
            /// </summary>
            /// <value>The volume remaining.</value>
            [XmlAttribute("volRemaining")]
            public int VolumeRemaining { get; set; }

            /// <summary>
            ///     Gets or sets the minimum volume.
            /// </summary>
            /// <value>The minimum volume.</value>
            [XmlAttribute("minVolume")]
            public int MinVolume { get; set; }

            /// <summary>
            ///     Gets or sets the state of the order.
            /// </summary>
            /// <value>The state of the order.</value>
            [XmlAttribute("orderState")]
            public int OrderState { get; set; }

            /// <summary>
            ///     Gets or sets the type identifier.
            /// </summary>
            /// <value>The type identifier.</value>
            [XmlAttribute("typeID")]
            public int TypeId { get; set; }

            /// <summary>
            ///     Gets or sets the range.
            /// </summary>
            /// <value>The range.</value>
            [XmlAttribute("range")]
            public int Range { get; set; }

            /// <summary>
            ///     Gets or sets the account key.
            /// </summary>
            /// <value>The account key.</value>
            [XmlAttribute("accountKey")]
            public int AccountKey { get; set; }

            /// <summary>
            ///     Gets or sets the duration.
            /// </summary>
            /// <value>The duration.</value>
            [XmlAttribute("duration")]
            public int Duration { get; set; }

            /// <summary>
            ///     Gets or sets the escrow.
            /// </summary>
            /// <value>The escrow.</value>
            [XmlAttribute("escrow")]
            public decimal Escrow { get; set; }

            /// <summary>
            ///     Gets or sets the price.
            /// </summary>
            /// <value>The price.</value>
            [XmlAttribute("price")]
            public decimal Price { get; set; }

            /// <summary>
            ///     Gets or sets the bid.
            /// </summary>
            /// <value>The bid.</value>
            [XmlAttribute("bid")]
            public int Bid { get; set; }

            /// <summary>
            ///     Gets the issued date.
            /// </summary>
            /// <value>The issued date.</value>
            [XmlIgnore]
            public DateTime IssuedDate { get; private set; }

            /// <summary>
            ///     Gets or sets the issued date as string.
            /// </summary>
            /// <value>The issued date as string.</value>
            [XmlAttribute("issued")]
            public string IssuedDateAsString {
                get { return IssuedDate.ToString(XmlHelper.DateFormat); }
                set { IssuedDate = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
            }
        }
    }
}