// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="MailingLists.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Xml.Serialization;

namespace eZet.EveLib.Modules.Models.Character {
    /// <summary>
    /// Class MailingLists.
    /// </summary>
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class MailingLists {
        /// <summary>
        /// Gets or sets the lists.
        /// </summary>
        /// <value>The lists.</value>
        [XmlElement("rowset")]
        public EveOnlineRowCollection<List> Lists { get; set; }

        /// <summary>
        /// Class List.
        /// </summary>
        [Serializable]
        [XmlRoot("row")]
        public class List {
            /// <summary>
            /// Gets or sets the list identifier.
            /// </summary>
            /// <value>The list identifier.</value>
            [XmlAttribute("listID")]
            public long ListId { get; set; }

            /// <summary>
            /// Gets or sets the display name.
            /// </summary>
            /// <value>The display name.</value>
            [XmlAttribute("displayName")]
            public string DisplayName { get; set; }
        }
    }
}