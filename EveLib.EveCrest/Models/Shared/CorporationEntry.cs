// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Lars Kristian
// Created          : 12-17-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 12-17-2014
// ***********************************************************************
// <copyright file="CorporationEntry.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Links;
using eZet.EveLib.EveCrestModule.Models.Resources;

namespace eZet.EveLib.EveCrestModule.Models.Shared {
    /// <summary>
    /// Class CorporationEntry.
    /// </summary>
    [DataContract]
    public class CorporationEntry : LinkedEntity<NotImplemented> {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is NPC.
        /// </summary>
        /// <value><c>true</c> if this instance is NPC; otherwise, <c>false</c>.</value>
        [DataMember(Name = "isNPC")]
        public bool IsNpc { get; set; }

        /// <summary>
        /// Gets or sets the logo.
        /// </summary>
        /// <value>The logo.</value>
        [DataMember(Name = "logo")]
        public ImageLink Logo { get; set; }
    }
}