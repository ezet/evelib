// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Lars Kristian
// Created          : 12-17-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 12-17-2014
// ***********************************************************************
// <copyright file="CharacterEntry.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Runtime.Serialization;
using eZet.EveLib.Modules.Models.Entities;
using eZet.EveLib.Modules.Models.Resources;

namespace eZet.EveLib.Modules.Models.Shared {
    /// <summary>
    /// Class CharacterEntry.
    /// </summary>
    [DataContract]
    public class CharacterEntry : CrestLinkedEntity<CrestNotImplemented> {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is NPC.
        /// </summary>
        /// <value><c>true</c> if this instance is NPC; otherwise, <c>false</c>.</value>
        [DataMember(Name = "isNPC")]
        public bool IsNpc { get; set; }

        /// <summary>
        /// Gets or sets the capsuleer.
        /// </summary>
        /// <value>The capsuleer.</value>
        [DataMember(Name = "capsuleer")]
        public CrestLinkedEntity<CrestNotImplemented> Capsuleer { get; set; }

        /// <summary>
        /// Gets or sets the portraits.
        /// </summary>
        /// <value>The portraits.</value>
        [DataMember(Name = "portrait")]
        public CrestImageLink Portraits { get; set; }
    }
}
