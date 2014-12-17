// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Lars Kristian
// Created          : 12-17-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 12-17-2014
// ***********************************************************************
// <copyright file="Tournament.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Links;

namespace eZet.EveLib.EveCrestModule.Models.Resources.Tournaments {
    /// <summary>
    ///     Class Tournament.
    /// </summary>
    [DataContract]
    public sealed class Tournament : CrestResource<Tournament> {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Tournament" /> class.
        /// </summary>
        public Tournament() {
            Version = "application/vnd.ccp.eve.Tournament-v1+json";
        }

        /// <summary>
        ///     Gets or sets the series.
        /// </summary>
        /// <value>The series.</value>
        [DataMember(Name = "series")]
        public Href<TournamentSeriesCollection> Series { get; set; }

        /// <summary>
        ///     Gets or sets the membership cutoff.
        /// </summary>
        /// <value>The membership cutoff.</value>
        [DataMember(Name = "membershitCutoff")]
        public DateTime MembershipCutoff { get; set; }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        [DataMember(Name = "type")]
        public string Type { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the entries.
        /// </summary>
        /// <value>The entries.</value>
        [DataMember(Name = "entries")]
        public IReadOnlyList<TournamentEntry> Entries { get; set; }


        /// <summary>
        ///     Class TournamentEntry.
        /// </summary>
        [DataContract]
        public class TournamentEntry : LinkedEntity<TournamentTeam> {
            /// <summary>
            ///     Gets or sets the team stats.
            /// </summary>
            /// <value>The team stats.</value>
            [DataMember(Name = "teamStats")]
            public Href<TournamentTeam> TeamStats { get; set; }
        }
    }
}