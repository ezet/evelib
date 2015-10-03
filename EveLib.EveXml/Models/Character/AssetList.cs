// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 07-09-2014
// ***********************************************************************
// <copyright file="AssetList.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace eZet.EveLib.EveXmlModule.Models.Character {
    /// <summary>
    ///     Class AssetList.
    /// </summary>
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class AssetList {
        /// <summary>
        ///     Gets or sets the items.
        /// </summary>
        /// <value>The items.</value>
        [XmlElement("rowset")]
        public EveXmlRowCollection<Item> Items { get; set; }

        /// <summary>
        ///     Returns a flat list of all assets.
        /// </summary>
        /// <returns>IEnumerable&lt;Item&gt;.</returns>
        public IEnumerable<Item> Flatten() {
            return flatten(Items);
        }

        /// <summary>
        ///     Flattens the specified items.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns>ICollection&lt;Item&gt;.</returns>
        private ICollection<Item> flatten(ICollection<Item> items) {
            var list = new List<Item>();
            var stack = new Stack<Item>(items);
            while (stack.Count > 0) {
                var current = stack.Pop();
                list.Add(current);
                if (current.Items == null) continue;
                foreach (var child in current.Items)
                    stack.Push(child);
            }
            return list;
        }

        /// <summary>
        ///     Class Item.
        /// </summary>
        [Serializable]
        [XmlRoot("row")]
        public class Item {
            /// <summary>
            ///     Gets or sets the item identifier.
            /// </summary>
            /// <value>The item identifier.</value>
            [XmlAttribute("itemID")]
            public long ItemId { get; set; }

            /// <summary>
            ///     Gets or sets the location identifier.
            /// </summary>
            /// <value>The location identifier.</value>
            [XmlAttribute("locationID")]
            public long LocationId { get; set; }

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
            public int Quantity { get; set; }

            /// <summary>
            ///     Gets or sets the flag.
            /// </summary>
            /// <value>The flag.</value>
            [XmlAttribute("flag")]
            public int Flag { get; set; }

            /// <summary>
            ///     Gets or sets a value indicating whether this <see cref="Item" /> is singleton.
            /// </summary>
            /// <value><c>true</c> if singleton; otherwise, <c>false</c>.</value>
            [XmlAttribute("singleton")]
            public bool Singleton { get; set; }

            /// <summary>
            ///     Blueprint: -1 = original; -2= copy; otherwise -1 for singelton
            /// </summary>
            /// <value>The raw quantity.</value>
            [XmlAttribute("rawQuantity")]
            public int RawQuantity { get; set; }

            /// <summary>
            ///     Gets or sets the items.
            /// </summary>
            /// <value>The items.</value>
            [XmlElement("rowset")]
            public EveXmlRowCollection<Item> Items { get; set; }
        }
    }
}