// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="ContractItems.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Xml.Serialization;

namespace eZet.EveLib.Modules.Models.Character {
    /// <summary>
    ///     Class ContractItems.
    /// </summary>
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class ContractItems {
        /// <summary>
        ///     Gets or sets the items.
        /// </summary>
        /// <value>The items.</value>
        [XmlElement("rowset")]
        public EveOnlineRowCollection<ContractItem> Items { get; set; }


        /// <summary>
        ///     Class ContractItem.
        /// </summary>
        [Serializable]
        [XmlRoot("row")]
        public class ContractItem {
            /// <summary>
            ///     Gets or sets the record identifier.
            /// </summary>
            /// <value>The record identifier.</value>
            [XmlAttribute("recordID")]
            public long RecordId { get; set; }

            /// <summary>
            ///     Gets or sets the type identifier.
            /// </summary>
            /// <value>The type identifier.</value>
            [XmlAttribute("typeID")]
            public int TypeId { get; set; }

            /// <summary>
            ///     Gets or sets the quantity.
            /// </summary>
            /// <value>The quantity.</value>
            [XmlAttribute("quantity")]
            public long Quantity { get; set; }

            /// <summary>
            ///     Gets or sets the raw quantity.
            /// </summary>
            /// <value>The raw quantity.</value>
            [XmlAttribute("rawQuantity")]
            public long RawQuantity { get; set; }

            /// <summary>
            ///     Gets or sets a value indicating whether this <see cref="ContractItem" /> is singleton.
            /// </summary>
            /// <value><c>true</c> if singleton; otherwise, <c>false</c>.</value>
            [XmlAttribute("singleton")]
            public bool Singleton { get; set; }

            /// <summary>
            ///     Gets or sets a value indicating whether this <see cref="ContractItem" /> is included.
            /// </summary>
            /// <value><c>true</c> if included; otherwise, <c>false</c>.</value>
            [XmlAttribute("included")]
            public bool Included { get; set; }
        }
    }
}