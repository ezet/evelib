// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 08-08-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 11-02-2014
// ***********************************************************************
// <copyright file="BlueprintList.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Xml.Serialization;

namespace eZet.EveLib.EveOnlineModule.Models.Character {
    /// <summary>
    ///     Eve Online Blueprint response
    /// </summary>
    [Serializable]
    [XmlRoot("result")]
    public class BlueprintList {
        /// <summary>
        ///     A list of blueprints
        /// </summary>
        /// <value>The blueprints.</value>
        [XmlElement("rowset")]
        public EveOnlineRowCollection<Blueprint> Blueprints { get; set; }

        /// <summary>
        ///     Represents a blueprint
        /// </summary>
        [Serializable]
        [XmlRoot("row")]
        public class Blueprint {
            /// <summary>
            ///     Unique ID of the blueprint
            /// </summary>
            /// <value>The item identifier.</value>
            [XmlAttribute("itemID")]
            public long ItemId { get; set; }

            /// <summary>
            ///     ID for the location of the blueprint
            /// </summary>
            /// <value>The location identifier.</value>
            [XmlAttribute("locationID")]
            public long LocationId { get; set; }

            /// <summary>
            ///     TypeID of the blueprint
            /// </summary>
            /// <value>The type identifier.</value>
            [XmlAttribute("typeID")]
            public int TypeId { get; set; }

            /// <summary>
            ///     Typename of the blueprint
            /// </summary>
            /// <value>The name of the type.</value>
            [XmlAttribute("typeName")]
            public string TypeName { get; set; }

            /// <summary>
            ///     Indicates something about this item's storage location. The flag is used to differentiate between hangar divisions,
            ///     drone bay, fitting location, and similar. Please see the Inventory Flags documentation.
            /// </summary>
            /// <value>The flag.</value>
            [XmlAttribute("flagID")]
            public int Flag { get; set; }

            /// <summary>
            ///     Typically will be -1 or -2 designating a singleton item, where -1 is an original and -2 is a copy. It can be a
            ///     positive integer if it is a stack of blueprint originals fresh from the market (no activities performed on them
            ///     yet).
            /// </summary>
            /// <value>The quantity.</value>
            [XmlAttribute("quantity")]
            public int Quantity { get; set; }

            /// <summary>
            ///     Time Efficiency Level of the blueprint.
            /// </summary>
            /// <value>The time efficiency.</value>
            [XmlAttribute("timeEfficiency")]
            public int TimeEfficiency { get; set; }

            /// <summary>
            ///     Material Efficiency Level of the blueprint.
            /// </summary>
            /// <value>The material efficiency.</value>
            [XmlAttribute("materialEfficiency")]
            public int MaterialEfficiency { get; set; }

            /// <summary>
            ///     Number of runs remaining if the blueprint is a copy, -1 if it is an original.
            /// </summary>
            /// <value>The runs.</value>
            [XmlAttribute("runs")]
            public int Runs { get; set; }
        }
    }
}