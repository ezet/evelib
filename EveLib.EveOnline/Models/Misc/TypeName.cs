// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="TypeName.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Xml.Serialization;

namespace eZet.EveLib.Modules.Models.Misc {
    /// <summary>
    ///     Class TypeName.
    /// </summary>
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class TypeName {
        /// <summary>
        ///     Gets or sets the types.
        /// </summary>
        /// <value>The types.</value>
        [XmlElement("rowset")]
        public EveOnlineRowCollection<TypeData> Types { get; set; }

        /// <summary>
        ///     Class TypeData.
        /// </summary>
        [Serializable]
        [XmlRoot("row")]
        public class TypeData {
            /// <summary>
            ///     Gets or sets the type identifier.
            /// </summary>
            /// <value>The type identifier.</value>
            [XmlAttribute("typeID")]
            public int TypeId { get; set; }

            /// <summary>
            ///     Gets or sets the name of the type.
            /// </summary>
            /// <value>The name of the type.</value>
            [XmlAttribute("typeName")]
            public string TypeName { get; set; }
        }
    }
}