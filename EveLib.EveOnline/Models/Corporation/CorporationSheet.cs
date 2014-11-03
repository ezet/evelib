// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="CorporationSheet.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Xml.Serialization;

namespace eZet.EveLib.Modules.Models.Corporation {
    /// <summary>
    /// Class CorporationSheet.
    /// </summary>
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class CorporationSheet {
        /// <summary>
        /// Gets or sets the corporation identifier.
        /// </summary>
        /// <value>The corporation identifier.</value>
        [XmlElement("corporationID")]
        public long CorporationId { get; set; }

        /// <summary>
        /// Gets or sets the name of the corporation.
        /// </summary>
        /// <value>The name of the corporation.</value>
        [XmlElement("corporationName")]
        public string CorporationName { get; set; }

        /// <summary>
        /// Gets or sets the ticker.
        /// </summary>
        /// <value>The ticker.</value>
        [XmlElement("ticker")]
        public string Ticker { get; set; }

        /// <summary>
        /// Gets or sets the ceo identifier.
        /// </summary>
        /// <value>The ceo identifier.</value>
        [XmlElement("ceoID")]
        public long CeoId { get; set; }

        /// <summary>
        /// Gets or sets the name of the ceo.
        /// </summary>
        /// <value>The name of the ceo.</value>
        [XmlElement("ceoName")]
        public string CeoName { get; set; }

        /// <summary>
        /// Gets or sets the station identifier.
        /// </summary>
        /// <value>The station identifier.</value>
        [XmlElement("stationID")]
        public int StationId { get; set; }

        /// <summary>
        /// Gets or sets the name of the station.
        /// </summary>
        /// <value>The name of the station.</value>
        [XmlElement("stationName")]
        public string StationName { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [XmlElement("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>The URL.</value>
        [XmlElement("url")]
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the alliance identifier.
        /// </summary>
        /// <value>The alliance identifier.</value>
        [XmlElement("allianceID")]
        public long AllianceId { get; set; }

        /// <summary>
        /// Gets or sets the faction identifier.
        /// </summary>
        /// <value>The faction identifier.</value>
        [XmlElement("factionID")]
        public long FactionId { get; set; }

        /// <summary>
        /// Gets or sets the tax rate.
        /// </summary>
        /// <value>The tax rate.</value>
        [XmlElement("taxRate")]
        public string TaxRate { get; set; }

        /// <summary>
        /// Gets or sets the member count.
        /// </summary>
        /// <value>The member count.</value>
        [XmlElement("memberCount")]
        public int MemberCount { get; set; }

        /// <summary>
        /// Gets or sets the member limit.
        /// </summary>
        /// <value>The member limit.</value>
        [XmlElement("memberLimit")]
        public int MemberLimit { get; set; }

        /// <summary>
        /// Gets or sets the shares.
        /// </summary>
        /// <value>The shares.</value>
        [XmlElement("shares")]
        public int Shares { get; set; }

        /// <summary>
        /// Gets or sets the divisions.
        /// </summary>
        /// <value>The divisions.</value>
        [XmlElement("rowset")]
        public EveOnlineRowCollection<Division> Divisions { get; set; }

        /// <summary>
        /// Gets or sets the logo.
        /// </summary>
        /// <value>The logo.</value>
        [XmlElement("logo")]
        public LogoData Logo { get; set; }

        /// <summary>
        /// Class Division.
        /// </summary>
        [Serializable]
        [XmlRoot("row")]
        public class Division {
            /// <summary>
            /// Gets or sets the account key.
            /// </summary>
            /// <value>The account key.</value>
            [XmlAttribute("accountKey")]
            public int AccountKey { get; set; }

            /// <summary>
            /// Gets or sets the description.
            /// </summary>
            /// <value>The description.</value>
            [XmlAttribute("description")]
            public string Description { get; set; }
        }

        /// <summary>
        /// Class LogoData.
        /// </summary>
        public class LogoData {
            /// <summary>
            /// Gets or sets the graphic identifier.
            /// </summary>
            /// <value>The graphic identifier.</value>
            [XmlElement("graphicID")]
            public int GraphicId { get; set; }

            /// <summary>
            /// Gets or sets the shape1.
            /// </summary>
            /// <value>The shape1.</value>
            [XmlElement("shape1")]
            public int Shape1 { get; set; }

            /// <summary>
            /// Gets or sets the shape2.
            /// </summary>
            /// <value>The shape2.</value>
            [XmlElement("shape2")]
            public int Shape2 { get; set; }

            /// <summary>
            /// Gets or sets the shape3.
            /// </summary>
            /// <value>The shape3.</value>
            [XmlElement("shape3")]
            public int Shape3 { get; set; }

            /// <summary>
            /// Gets or sets the color1.
            /// </summary>
            /// <value>The color1.</value>
            [XmlElement("color1")]
            public int Color1 { get; set; }

            /// <summary>
            /// Gets or sets the color2.
            /// </summary>
            /// <value>The color2.</value>
            [XmlElement("color2")]
            public int Color2 { get; set; }

            /// <summary>
            /// Gets or sets the color3.
            /// </summary>
            /// <value>The color3.</value>
            [XmlElement("color3")]
            public int Color3 { get; set; }
        }
    }
}