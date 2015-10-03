// ***********************************************************************
// Assembly         : EveLib.EveWho
// Author           : Lars Kristian
// Created          : 06-19-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="CharacterResponse.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eZet.EveLib.EveWhoModule.Models {
    /// <summary>
    ///     Class CharacterResponse.
    /// </summary>
    [DataContract]
    public class CharacterResponse {

        /// <summary>
        ///     Gets or sets the history.
        /// </summary>
        /// <value>The history.</value>
        [DataMember(Name = "history")]
        public IList<EveWhoHistoryEntry> History { get; set; }

        /// <summary>
        /// Gets or sets the information.
        /// </summary>
        /// <value>The information.</value>
        [DataMember(Name = "info")]
        public CharacterInfo Info { get; set; }

        /// <summary>
        /// Class CharacterInfo.
        /// </summary>
        [DataContract]
        public class CharacterInfo {
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

            /// <summary>
            ///     Gets or sets the security status.
            /// </summary>
            /// <value>The security status.</value>
            [DataMember(Name = "sec_status")]
            public double SecurityStatus { get; set; }

        }


        /// <summary>
        ///     Class EveWhoHistoryEntry.
        /// </summary>
        [DataContract]
        public class EveWhoHistoryEntry {
            /// <summary>
            ///     Gets or sets the corporation identifier.
            /// </summary>
            /// <value>The corporation identifier.</value>
            [DataMember(Name = "corporation_id")]
            public long CorporationId { get; set; }

            /// <summary>
            ///     Gets or sets the start date.
            /// </summary>
            /// <value>The start date.</value>
            [DataMember(Name = "start_date")]
            public DateTime StartDate { get; set; }

            /// <summary>
            ///     Gets or sets the end date.
            /// </summary>
            /// <value>The end date.</value>
            [DataMember(Name = "end_date")]
            public DateTime? EndDate { get; set; }
        }
    }
}