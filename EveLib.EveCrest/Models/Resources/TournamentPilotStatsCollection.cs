// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Lars Kristian
// Created          : 12-17-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 12-17-2014
// ***********************************************************************
// <copyright file="CrestTournamentPilotStatsCollection.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Links;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    /// <summary>
    ///     Class TournamentPilotStatsCollection. This class cannot be inherited.
    /// </summary>
    [DataContract]
    public sealed class TournamentPilotStatsCollection :
        CollectionResource<TournamentPilotStatsCollection> {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TournamentPilotStatsCollection" /> class.
        /// </summary>
        public TournamentPilotStatsCollection() {
            Version = "application/vnd.ccp.eve.TournamentPilotStatsCollection-v1+json";
        }

        /// <summary>
        ///     Gets or sets the items.
        /// </summary>
        /// <value>The items.</value>
        [DataMember(Name = "items")]
        public IReadOnlyList<PilotStatsEntry> Items { get; set; }

        /// <summary>
        ///     Class PilotStatsEntry.
        /// </summary>
        [DataContract]
        public class PilotStatsEntry {
            /// <summary>
            ///     Gets or sets the damage done.
            /// </summary>
            /// <value>The damage done.</value>
            [DataMember(Name = "damageDone")]
            public double DamageDone { get; set; }

            /// <summary>
            ///     Gets or sets the damage received.
            /// </summary>
            /// <value>The damage received.</value>
            [DataMember(Name = "damageReceived")]
            public double DamageReceived { get; set; }

            /// <summary>
            ///     Gets or sets the pilot tournament stats.
            /// </summary>
            /// <value>The pilot tournament stats.</value>
            [DataMember(Name = "pilotTournamentStats")]
            public Href<PilotTournamentStats> PilotTournamentStats { get; set; }

            /// <summary>
            ///     Gets or sets a value indicating whether this instance is dead.
            /// </summary>
            /// <value><c>true</c> if this instance is dead; otherwise, <c>false</c>.</value>
            [DataMember(Name = "isDead")]
            public bool IsDead { get; set; }

            /// <summary>
            ///     Gets or sets the type of the ship.
            /// </summary>
            /// <value>The type of the ship.</value>
            [DataMember(Name = "shipType")]
            public LinkedIconEntity<ItemType> ShipType { get; set; }

            /// <summary>
            ///     Gets or sets the team.
            /// </summary>
            /// <value>The team.</value>
            [DataMember(Name = "team")]
            public Href<TournamentTeam> Team { get; set; }

            /// <summary>
            ///     Gets or sets the pilot.
            /// </summary>
            /// <value>The pilot.</value>
            [DataMember(Name = "pilot")]
            public LinkedIconEntity<NotImplemented> Pilot { get; set; }
        }
    }
}