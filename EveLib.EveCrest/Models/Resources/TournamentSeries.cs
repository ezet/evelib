// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Lars Kristian
// Created          : 12-17-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 12-17-2014
// ***********************************************************************
// <copyright file="TournamentSeries.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Links;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    /// <summary>
    ///     Class TournamentSeries.
    /// </summary>
    [DataContract]
    public sealed class TournamentSeries : CrestResource<TournamentSeries> {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TournamentSeries" /> class.
        /// </summary>
        public TournamentSeries() {
            Version = "application/vnd.ccp.eve.TournamentSeries-v1+json";
        }

        /// <summary>
        ///     Gets or sets the red team.
        /// </summary>
        /// <value>The red team.</value>
        [DataMember(Name = "redTeam")]
        public TournamentTeam RedTeam { get; set; }

        /// <summary>
        ///     Gets or sets the matches won.
        /// </summary>
        /// <value>The matches won.</value>
        [DataMember(Name = "matchesWon")]
        public MatchStats MatchesWon { get; set; }

        /// <summary>
        ///     Gets or sets the matches.
        /// </summary>
        /// <value>The matches.</value>
        [DataMember(Name = "matches")]
        public Href<TournamentMatchCollection> Matches { get; set; }

        /// <summary>
        ///     Gets or sets the self.
        /// </summary>
        /// <value>The self.</value>
        [DataMember(Name = "self")]
        public Href<TournamentSeries> Self { get; set; }

        /// <summary>
        ///     Gets or sets the winner.
        /// </summary>
        /// <value>The winner.</value>
        [DataMember(Name = "winner")]
        public TournamentTeam Winner { get; set; }

        /// <summary>
        ///     Gets or sets the loser.
        /// </summary>
        /// <value>The loser.</value>
        [DataMember(Name = "loser")]
        public TournamentTeam Loser { get; set; }

        /// <summary>
        ///     Gets or sets the length.
        /// </summary>
        /// <value>The length.</value>
        [DataMember(Name = "length")]
        public int Length { get; set; }

        /// <summary>
        ///     Gets or sets the blue team.
        /// </summary>
        /// <value>The blue team.</value>
        [DataMember(Name = "blueTeam")]
        public TournamentTeam BlueTeam { get; set; }

        /// <summary>
        ///     Gets or sets the structure.
        /// </summary>
        /// <value>The structure.</value>
        [DataMember(Name = "structure")]
        public SeriesStructure Structure { get; set; }

        /// <summary>
        ///     Class MatchStats.
        /// </summary>
        [DataContract]
        public class MatchStats {
            /// <summary>
            ///     Gets or sets the red team.
            /// </summary>
            /// <value>The red team.</value>
            [DataMember(Name = "redTeam")]
            public int RedTeam { get; set; }

            /// <summary>
            ///     Gets or sets the blue team.
            /// </summary>
            /// <value>The blue team.</value>
            [DataMember(Name = "blueTeam")]
            public int BlueTeam { get; set; }
        }

        /// <summary>
        ///     Class TournamentSeries.
        /// </summary>
        [DataContract]
        public class SeriesStructure {
            /// <summary>
            ///     Gets or sets the outgoing loser.
            /// </summary>
            /// <value>The outgoing loser.</value>
            [DataMember(Name = "outgoingLoser")]
            public Href<TournamentSeries> OutgoingLoser { get; set; }

            /// <summary>
            ///     Gets or sets the outgoing winner.
            /// </summary>
            /// <value>The outgoing winner.</value>
            [DataMember(Name = "outgoingWinner")]
            public Href<TournamentSeries> OutgoingWinner { get; set; }
        }


        /// <summary>
        ///     Class TournamentTeam.
        /// </summary>
        [DataContract]
        public class TournamentTeam {
            /// <summary>
            ///     Gets or sets the team.
            /// </summary>
            /// <value>The team.</value>
            [DataMember(Name = "team")]
            public LinkedEntity<Resources.TournamentTeam> Team { get; set; }

            /// <summary>
            ///     Gets or sets a value indicating whether this instance is decided.
            /// </summary>
            /// <value><c>true</c> if this instance is decided; otherwise, <c>false</c>.</value>
            [DataMember(Name = "isDecided")]
            public bool IsDecided { get; set; }

            /// <summary>
            ///     Gets or sets a value indicating whether this instance is bye.
            /// </summary>
            /// <value><c>true</c> if this instance is bye; otherwise, <c>false</c>.</value>
            [DataMember(Name = "isBye")]
            public bool IsBye { get; set; }
        }
    }
}