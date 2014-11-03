// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="ContractBids.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Xml.Serialization;
using eZet.EveLib.Modules.Util;

namespace eZet.EveLib.Modules.Models.Character {
    /// <summary>
    /// Class ContractBids.
    /// </summary>
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class ContractBids {
        /// <summary>
        /// Gets or sets the bids.
        /// </summary>
        /// <value>The bids.</value>
        [XmlElement("rowset")]
        public EveOnlineRowCollection<Bid> Bids { get; set; }

        /// <summary>
        /// Class Bid.
        /// </summary>
        [Serializable]
        [XmlRoot("row")]
        public class Bid {
            /// <summary>
            /// Gets or sets the bid identifier.
            /// </summary>
            /// <value>The bid identifier.</value>
            [XmlAttribute("bidID")]
            public long BidId { get; set; }

            /// <summary>
            /// Gets or sets the contract identifier.
            /// </summary>
            /// <value>The contract identifier.</value>
            [XmlAttribute("contractID")]
            public long ContractId { get; set; }

            /// <summary>
            /// Gets or sets the bidder identifier.
            /// </summary>
            /// <value>The bidder identifier.</value>
            [XmlAttribute("bidderID")]
            public long BidderId { get; set; }

            /// <summary>
            /// Gets the bid date.
            /// </summary>
            /// <value>The bid date.</value>
            [XmlIgnore]
            public DateTime BidDate { get; private set; }

            /// <summary>
            /// Gets or sets the bid date as string.
            /// </summary>
            /// <value>The bid date as string.</value>
            [XmlAttribute("dateBid")]
            public string BidDateAsString {
                get { return BidDate.ToString(XmlHelper.DateFormat); }
                set { BidDate = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
            }

            /// <summary>
            /// Gets or sets the amount.
            /// </summary>
            /// <value>The amount.</value>
            [XmlAttribute("amount")]
            public decimal Amount { get; set; }
        }
    }
}