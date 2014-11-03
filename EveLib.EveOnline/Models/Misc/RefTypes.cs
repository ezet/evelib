// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="RefTypes.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Xml.Serialization;

namespace eZet.EveLib.Modules.Models.Misc {
    /// <summary>
    ///     Class ReferenceTypes.
    /// </summary>
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class ReferenceTypes {
        /// <summary>
        ///     Gets or sets the reference types.
        /// </summary>
        /// <value>The reference types.</value>
        [XmlElement("rowset")]
        public EveOnlineRowCollection<ReferenceType> RefTypes { get; set; }

        /// <summary>
        ///     Class ReferenceType.
        /// </summary>
        [Serializable]
        [XmlRoot("row")]
        public class ReferenceType {
            /// <summary>
            ///     Gets or sets the reference type identifier.
            /// </summary>
            /// <value>The reference type identifier.</value>
            [XmlAttribute("refTypeID")]
            public int RefTypeId { get; set; }

            /// <summary>
            ///     Gets or sets the name of the reference type.
            /// </summary>
            /// <value>The name of the reference type.</value>
            [XmlAttribute("refTypeName")]
            public string RefTypeName { get; set; }
        }
    }
}