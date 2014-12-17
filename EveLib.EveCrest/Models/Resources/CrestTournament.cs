// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Lars Kristian
// Created          : 12-17-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 12-17-2014
// ***********************************************************************
// <copyright file="CrestTournament.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using eZet.EveLib.Modules.Models.Entities;

namespace eZet.EveLib.Modules.Models.Resources {
    /// <summary>
    /// Class CrestTournament.
    /// </summary>
    [DataContract]
    public sealed class CrestTournament : CrestResource {


        /// <summary>
        /// Initializes a new instance of the <see cref="CrestTournament"/> class.
        /// </summary>
        public CrestTournament() {
            Version = "application/vnd.ccp.eve.Tournament-v1+json";
        }

        /// <summary>
        /// Gets or sets the series.
        /// </summary>
        /// <value>The series.</value>
        [DataMember(Name = "series")]
        public CrestHref<CrestTournamentSeriesCollection> Series { get; set; }

        /// <summary>
        /// Gets or sets the membership cutoff.
        /// </summary>
        /// <value>The membership cutoff.</value>
        [DataMember(Name = "membershitCutoff")]
        public DateTime MembershipCutoff { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        [DataMember(Name = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the entries.
        /// </summary>
        /// <value>The entries.</value>
        [DataMember(Name = "entries")]
        public IReadOnlyList<TournamentEntry> Entries { get; set; }



        /// <summary>
        /// Class TournamentEntry.
        /// </summary>
        [DataContract]
        public class TournamentEntry : CrestLinkedEntity<CrestTournamentTeam> {

            /// <summary>
            /// Gets or sets the team stats.
            /// </summary>
            /// <value>The team stats.</value>
            [DataMember(Name = "teamStats")]
            public CrestHref<CrestTournamentTeam> TeamStats { get; set; }


        }


    }
}
