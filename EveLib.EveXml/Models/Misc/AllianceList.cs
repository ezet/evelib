// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="AllianceList.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Xml.Serialization;
using eZet.EveLib.EveXmlModule.Util;

namespace eZet.EveLib.EveXmlModule.Models.Misc {
    /// <summary>
    ///     Class AllianceList.
    /// </summary>
    [Serializable]
    [XmlRoot("result")]
    public class AllianceList {
        /// <summary>
        ///     Gets or sets the alliances.
        /// </summary>
        /// <value>The alliances.</value>
        [XmlElement("rowset")]
        public EveXmlRowCollection<AllianceData> Alliances { get; set; }

        /// <summary>
        ///     Class AllianceData.
        /// </summary>
        [Serializable]
        [XmlRoot("row")]
        public class AllianceData {
            /// <summary>
            ///     Gets or sets the name of the alliance.
            /// </summary>
            /// <value>The name of the alliance.</value>
            [XmlAttribute("name")]
            public string AllianceName { get; set; }

            /// <summary>
            ///     Gets or sets the alliance tag.
            /// </summary>
            /// <value>The alliance tag.</value>
            [XmlAttribute("shortName")]
            public string AllianceTag { get; set; }

            /// <summary>
            ///     Gets or sets the alliance identifier.
            /// </summary>
            /// <value>The alliance identifier.</value>
            [XmlAttribute("allianceID")]
            public long AllianceId { get; set; }

            /// <summary>
            ///     Gets or sets the executor corp identifier.
            /// </summary>
            /// <value>The executor corp identifier.</value>
            [XmlAttribute("executorCorpID")]
            public long ExecutorCorpId { get; set; }

            /// <summary>
            ///     Gets or sets the member count.
            /// </summary>
            /// <value>The member count.</value>
            [XmlAttribute("memberCount")]
            public int MemberCount { get; set; }


            /// <summary>
            ///     Gets the start date.
            /// </summary>
            /// <value>The start date.</value>
            [XmlIgnore]
            public DateTime StartDate { get; private set; }

            /// <summary>
            ///     Gets or sets the start date as string.
            /// </summary>
            /// <value>The start date as string.</value>
            [XmlAttribute("startDate")]
            public string StartDateAsString {
                get { return StartDate.ToString(XmlHelper.DateFormat); }
                set { StartDate = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
            }

            /// <summary>
            ///     Gets or sets the corporations.
            /// </summary>
            /// <value>The corporations.</value>
            [XmlElement("rowset")]
            public EveXmlRowCollection<CorporationData> Corporations { get; set; }
        }

        /// <summary>
        ///     Class CorporationData.
        /// </summary>
        [Serializable]
        [XmlRoot("row")]
        public class CorporationData {
            /// <summary>
            ///     Gets or sets the corporation identifier.
            /// </summary>
            /// <value>The corporation identifier.</value>
            [XmlAttribute("corporationID")]
            public long CorporationId { get; set; }

            /// <summary>
            ///     Gets the start date.
            /// </summary>
            /// <value>The start date.</value>
            [XmlIgnore]
            public DateTime StartDate { get; private set; }

            /// <summary>
            ///     Gets or sets the start date as string.
            /// </summary>
            /// <value>The start date as string.</value>
            [XmlAttribute("startDate")]
            public string StartDateAsString {
                get { return StartDate.ToString(XmlHelper.DateFormat); }
                set { StartDate = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
            }
        }
    }
}