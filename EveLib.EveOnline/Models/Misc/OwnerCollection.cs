// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 04-02-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="OwnerCollection.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Xml.Serialization;

namespace eZet.EveLib.Modules.Models.Misc {
    /// <summary>
    /// Class OwnerCollection.
    /// </summary>
    [Serializable]
    [XmlRoot("result")]
    public class OwnerCollection {
        /// <summary>
        /// Enum OwnerGroup
        /// </summary>
        public enum OwnerGroup {
            /// <summary>
            /// The none
            /// </summary>
            [XmlEnum("0")] None = 0,
            /// <summary>
            /// The character
            /// </summary>
            [XmlEnum("1")] Character = 1,
            /// <summary>
            /// The corporation
            /// </summary>
            [XmlEnum("2")] Corporation = 2,
            /// <summary>
            /// The faction
            /// </summary>
            [XmlEnum("19")] Faction = 19,
            /// <summary>
            /// The alliance
            /// </summary>
            [XmlEnum("32")] Alliance = 32
        }

        /// <summary>
        /// Gets or sets the owners.
        /// </summary>
        /// <value>The owners.</value>
        [XmlElement("rowset")]
        public EveOnlineRowCollection<Owner> Owners { get; set; }

        /// <summary>
        /// Class Owner.
        /// </summary>
        [Serializable]
        [XmlRoot("row")]
        public class Owner {
            /// <summary>
            /// Gets or sets the owner identifier.
            /// </summary>
            /// <value>The owner identifier.</value>
            [XmlAttribute("ownerID")]
            public long OwnerId { get; set; }

            /// <summary>
            /// Gets or sets the name of the owner.
            /// </summary>
            /// <value>The name of the owner.</value>
            [XmlAttribute("ownerName")]
            public string OwnerName { get; set; }

            /// <summary>
            /// Gets or sets the owner group.
            /// </summary>
            /// <value>The owner group.</value>
            [XmlAttribute("ownerGroupID")]
            public OwnerGroup OwnerGroup { get; set; }
        }
    }
}