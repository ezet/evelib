// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="Locations.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Xml.Serialization;

namespace eZet.EveLib.Modules.Models.Character {
    /// <summary>
    ///     Class Locations.
    /// </summary>
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class Locations {
        /// <summary>
        ///     Gets or sets the items.
        /// </summary>
        /// <value>The items.</value>
        [XmlElement("rowset")]
        public EveOnlineRowCollection<Location> Items { get; set; }

        /// <summary>
        ///     Class Location.
        /// </summary>
        [Serializable]
        [XmlRoot("row")]
        public class Location {
            /// <summary>
            ///     Gets or sets the item identifier.
            /// </summary>
            /// <value>The item identifier.</value>
            [XmlAttribute("itemID")]
            public long ItemId { get; set; }

            /// <summary>
            ///     Gets or sets the name of the item.
            /// </summary>
            /// <value>The name of the item.</value>
            [XmlAttribute("itemName")]
            public string ItemName { get; set; }

            /// <summary>
            ///     Gets or sets the x.
            /// </summary>
            /// <value>The x.</value>
            [XmlAttribute("x")]
            public double X { get; set; }

            /// <summary>
            ///     Gets or sets the y.
            /// </summary>
            /// <value>The y.</value>
            [XmlAttribute("y")]
            public double Y { get; set; }

            /// <summary>
            ///     Gets or sets the z.
            /// </summary>
            /// <value>The z.</value>
            [XmlAttribute("z")]
            public double Z { get; set; }
        }
    }
}