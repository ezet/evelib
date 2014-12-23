// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="MedalList.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Xml.Serialization;
using eZet.EveLib.EveXmlModule.Util;

namespace eZet.EveLib.EveXmlModule.Models.Character {
    /// <summary>
    ///     Class MedalList.
    /// </summary>
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class MedalList {
        /// <summary>
        ///     Gets or sets the medals.
        /// </summary>
        /// <value>The medals.</value>
        [XmlElement("rowset")]
        public EveXmlRowCollection<Medal> Medals { get; set; }

        /// <summary>
        ///     Class Medal.
        /// </summary>
        [Serializable]
        [XmlRoot("row")]
        public class Medal {
            /// <summary>
            ///     Gets or sets the medal identifier.
            /// </summary>
            /// <value>The medal identifier.</value>
            [XmlAttribute("medalID")]
            public long MedalId { get; set; }

            /// <summary>
            ///     Gets or sets the reason.
            /// </summary>
            /// <value>The reason.</value>
            [XmlAttribute("reason")]
            public string Reason { get; set; }

            /// <summary>
            ///     Gets or sets the status.
            /// </summary>
            /// <value>The status.</value>
            [XmlAttribute("status")]
            public string Status { get; set; }

            /// <summary>
            ///     Gets or sets the issuer identifier.
            /// </summary>
            /// <value>The issuer identifier.</value>
            [XmlAttribute("issuerID")]
            public long IssuerId { get; set; }

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

            /// <summary>
            ///     Gets or sets the corporation identifier.
            /// </summary>
            /// <value>The corporation identifier.</value>
            [XmlAttribute("corporationID")]
            public long CorporationId { get; set; }

            /// <summary>
            ///     Gets or sets the title.
            /// </summary>
            /// <value>The title.</value>
            [XmlAttribute("title")]
            public string Title { get; set; }

            /// <summary>
            ///     Gets or sets the description.
            /// </summary>
            /// <value>The description.</value>
            [XmlAttribute("description")]
            public string Description { get; set; }
        }
    }
}