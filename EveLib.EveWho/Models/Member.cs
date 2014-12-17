// ***********************************************************************
// Assembly         : EveLib.EveWho
// Author           : Lars Kristian
// Created          : 06-19-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="Member.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Runtime.Serialization;

namespace eZet.EveLib.EveWhoModule.Models {
    /// <summary>
    ///     Class Member.
    /// </summary>
    [DataContract]
    public class Member {
        /// <summary>
        ///     Gets or sets the character identifier.
        /// </summary>
        /// <value>The character identifier.</value>
        [DataMember(Name = "character_id")]
        public long CharacterId { get; set; }

        /// <summary>
        ///     Gets or sets the corporation identifier.
        /// </summary>
        /// <value>The corporation identifier.</value>
        [DataMember(Name = "corporation_id")]
        public long CorporationId { get; set; }

        /// <summary>
        ///     Gets or sets the alliance identifier.
        /// </summary>
        /// <value>The alliance identifier.</value>
        [DataMember(Name = "alliance_id")]
        public long AllianceId { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}