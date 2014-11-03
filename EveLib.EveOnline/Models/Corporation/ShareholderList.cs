// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="ShareholderList.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Xml.Serialization;

namespace eZet.EveLib.Modules.Models.Corporation {
    /// <summary>
    ///     Class ShareholderList.
    /// </summary>
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class ShareholderList {
        /// <summary>
        ///     Gets or sets the shareholders.
        /// </summary>
        /// <value>The shareholders.</value>
        [XmlElement("rowset")]
        public EveOnlineRowCollection<Shareholder> Shareholders { get; set; }


        /// <summary>
        ///     Class Shareholder.
        /// </summary>
        [Serializable]
        [XmlRoot("row")]
        public class Shareholder {
            /// <summary>
            ///     Gets or sets the shareholder identifier.
            /// </summary>
            /// <value>The shareholder identifier.</value>
            [XmlAttribute("shareholderID")]
            public long ShareholderId { get; set; }

            /// <summary>
            ///     Gets or sets the name of the shareholder.
            /// </summary>
            /// <value>The name of the shareholder.</value>
            [XmlAttribute("shareholderName")]
            public string ShareholderName { get; set; }

            /// <summary>
            ///     Gets or sets the shares.
            /// </summary>
            /// <value>The shares.</value>
            [XmlAttribute("shares")]
            public int Shares { get; set; }

            /// <summary>
            ///     Gets or sets the shareholder corporation identifier.
            /// </summary>
            /// <value>The shareholder corporation identifier.</value>
            [XmlAttribute("shareholderCorporationID")]
            public long ShareholderCorporationId { get; set; }

            /// <summary>
            ///     Gets or sets the name of the shareholder corporation.
            /// </summary>
            /// <value>The name of the shareholder corporation.</value>
            [XmlAttribute("shareholderCorporationName")]
            public string ShareholderCorporationName { get; set; }
        }
    }
}