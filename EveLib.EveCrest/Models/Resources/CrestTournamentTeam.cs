// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Lars Kristian
// Created          : 12-17-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 12-17-2014
// ***********************************************************************
// <copyright file="CrestTournamentTeam.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.Runtime.Serialization;
using eZet.EveLib.Modules.Models.Entities;

namespace eZet.EveLib.Modules.Models.Resources {
    /// <summary>
    /// Class CrestTournamentTeam. This class cannot be inherited.
    /// </summary>
    [DataContract]
    public sealed class CrestTournamentTeam : CrestResource {

        /// <summary>
        /// Initializes a new instance of the <see cref="CrestTournamentTeam"/> class.
        /// </summary>
        public CrestTournamentTeam() {
            Version = "application/vnd.ccp.eve.TournamentTeam-v1+json";
        }

        /// <summary>
        /// Gets or sets the seed.
        /// </summary>
        /// <value>The seed.</value>
        [DataMember(Name = "seed")]
        public int Seed { get; set; }

        /// <summary>
        /// Gets or sets the ships killed.
        /// </summary>
        /// <value>The ships killed.</value>
        [DataMember(Name = "shipsKilled")]
        public int ShipsKilled { get; set; }

        /// <summary>
        /// Gets or sets the isk killed.
        /// </summary>
        /// <value>The isk killed.</value>
        [DataMember(Name = "iskKilled")]
        public decimal IskKilled { get; set; }

        /// <summary>
        /// Gets or sets the pilots.
        /// </summary>
        /// <value>The pilots.</value>
        [DataMember(Name = "pilots")]
        public IReadOnlyCollection<CrestLinkedIconEntity<CrestNotImplemented>> Pilots { get; set; }

        /// <summary>
        /// Gets or sets the matches.
        /// </summary>
        /// <value>The matches.</value>
        [DataMember(Name = "matches")]
        public IReadOnlyCollection<CrestLinkedEntity<CrestTournamentMatch>> Matches { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the ban frequency.
        /// </summary>
        /// <value>The ban frequency.</value>
        [DataMember(Name = "banFrequency")]
        public BanFrequencyStats BanFrequency { get; set; }

        /// <summary>
        /// Gets or sets the captain.
        /// </summary>
        /// <value>The captain.</value>
        [DataMember(Name = "captain")]
        public CrestHref<CrestLinkedIconEntity<CrestNotImplemented>> Captain { get; set; }

        /// <summary>
        /// Gets or sets the ban frequency against.
        /// </summary>
        /// <value>The ban frequency against.</value>
        [DataMember(Name = "banFrequencyAgainst")]
        public BanFrequencyStats BanFrequencyAgainst { get; set; }

        /// <summary>
        /// Gets or sets the members.
        /// </summary>
        /// <value>The members.</value>
        [DataMember(Name = "members")]
        public CrestHref<CrestTournamentTeamMemberCollection> Members { get; set; }

            /// <summary>
        /// Class BanFrequencyStats.
        /// </summary>
        [DataContract]
        public class BanFrequencyStats {

            /// <summary>
            /// Gets or sets the number bans.
            /// </summary>
            /// <value>The number bans.</value>
            [DataMember(Name = "numBans")]
            public int NumBans { get; set; }

            /// <summary>
            /// Gets or sets the type of the ship.
            /// </summary>
            /// <value>The type of the ship.</value>
            [DataMember(Name = "shipType")]
            public CrestLinkedIconEntity<CrestItemType> ShipType { get; set; }
        }
    }
}
