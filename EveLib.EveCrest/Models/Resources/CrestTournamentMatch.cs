// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Lars Kristian
// Created          : 12-17-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 12-17-2014
// ***********************************************************************
// <copyright file="CrestTournamentMatch.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.Runtime.Serialization;
using eZet.EveLib.Modules.Models.Entities;
using eZet.EveLib.Modules.Models.Shared;

namespace eZet.EveLib.Modules.Models.Resources {
    /// <summary>
    /// Class CrestTournamentMatch. This class cannot be inherited.
    /// </summary>
    [DataContract]
    public sealed class CrestTournamentMatch : CrestResource {

        /// <summary>
        /// Initializes a new instance of the <see cref="CrestTournamentMatch"/> class.
        /// </summary>
        public CrestTournamentMatch() {
            Version = "application/vnd.ccp.eve.TournamentMatch-v1+json";
        }


        /// <summary>
        /// Gets or sets the winner.
        /// </summary>
        /// <value>The winner.</value>
        [DataMember(Name = "winner")]
        public CrestHref<CrestTournamentTeam> Winner { get; set; }

        /// <summary>
        /// Gets or sets the stats.
        /// </summary>
        /// <value>The stats.</value>
        [DataMember(Name = "stats")]
        public MatchStats Stats { get; set; }

        /// <summary>
        /// Gets or sets the red team.
        /// </summary>
        /// <value>The red team.</value>
        [DataMember(Name = "redTeam")]
        public CrestLinkedEntity<CrestTournamentTeam> RedTeam { get; set; }

        /// <summary>
        /// Gets or sets the bans.
        /// </summary>
        /// <value>The bans.</value>
        [DataMember(Name = "bans")]
        public BanStats Bans { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="CrestTournamentMatch"/> is finalized.
        /// </summary>
        /// <value><c>true</c> if finalized; otherwise, <c>false</c>.</value>
        [DataMember(Name = "finalized")]
        public bool Finalized { get; set; }

        /// <summary>
        /// Gets or sets the series.
        /// </summary>
        /// <value>The series.</value>
        [DataMember(Name = "series")]
        public CrestHref<CrestTournamentSeries> Series { get; set; }

        /// <summary>
        /// Gets or sets the tournament.
        /// </summary>
        /// <value>The tournament.</value>
        [DataMember(Name = "tournament")]
        public CrestHref<CrestTournament> Tournament { get; set; }

        /// <summary>
        /// Gets or sets the score.
        /// </summary>
        /// <value>The score.</value>
        [DataMember(Name = "score")]
        public MatchScore Score { get; set; }

        /// <summary>
        /// Gets or sets the blue team.
        /// </summary>
        /// <value>The blue team.</value>
        [DataMember(Name = "blueTeam")]
        public CrestLinkedEntity<CrestTournamentTeam> BlueTeam { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [in progress].
        /// </summary>
        /// <value><c>true</c> if [in progress]; otherwise, <c>false</c>.</value>
        [DataMember(Name = "inProgress")]
        public bool InProgress { get; set; }

        /// <summary>
        /// Class MatchScore.
        /// </summary>
        [DataContract]
        public class MatchScore {

            /// <summary>
            /// Gets or sets the red team.
            /// </summary>
            /// <value>The red team.</value>
            [DataMember(Name = "redTeam")]
            public int RedTeam { get; set; }

            /// <summary>
            /// Gets or sets the blue team.
            /// </summary>
            /// <value>The blue team.</value>
            [DataMember(Name = "blueTeam")]
            public int BlueTeam { get; set; }

        }


        /// <summary>
        /// Class BanStats.
        /// </summary>
        [DataContract]
        public class BanStats {

            /// <summary>
            /// Gets or sets the bans.
            /// </summary>
            /// <value>The bans.</value>
            [DataMember(Name = "self")]
            public CrestHref<CrestTournamentTypeBanCollection> Bans { get; set; }

            /// <summary>
            /// Gets or sets the red team.
            /// </summary>
            /// <value>The red team.</value>
            [DataMember(Name = "redTeam")]
            public IReadOnlyList<BanEntry> RedTeam { get; set; }

            /// <summary>
            /// Gets or sets the blue team.
            /// </summary>
            /// <value>The blue team.</value>
            [DataMember(Name = "blueTeam")]
            public IReadOnlyList<BanEntry> BlueTeam { get; set; }

        }




        /// <summary>
        /// Class MatchStats.
        /// </summary>
        [DataContract]
        public class MatchStats {

            /// <summary>
            /// Gets or sets the pilots.
            /// </summary>
            /// <value>The pilots.</value>
            [DataMember(Name = "pilots")]
            public CrestHref<CrestTournamentPilotStatsCollection> Pilots { get; set; }

        }





    }
}
