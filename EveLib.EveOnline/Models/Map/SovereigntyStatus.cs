// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="SovereigntyStatus.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Xml.Serialization;

namespace eZet.EveLib.Modules.Models.Map {
    /// <summary>
    /// Class SovereigntyStatus.
    /// </summary>
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class SovereigntyStatus {
        /// <summary>
        /// Gets or sets the structures.
        /// </summary>
        /// <value>The structures.</value>
        [XmlElement("rowset")]
        public EveOnlineRowCollection<Structure> Structures { get; set; }

        /// <summary>
        /// Class Structure.
        /// </summary>
        public class Structure {
            // TODO Implement
        }
    }
}