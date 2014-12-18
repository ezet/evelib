// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Lars Kristian
// Created          : 12-16-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 12-17-2014
// ***********************************************************************
// <copyright file="IndustryTeam.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Links;
using eZet.EveLib.EveCrestModule.Models.Shared;

namespace eZet.EveLib.EveCrestModule.Models.Resources.Industry {
    /// <summary>
    ///     Represents a CREST industry team
    /// </summary>
    public sealed class IndustryTeam : CrestResource<IndustryTeam> {
        /// <summary>
        ///     Initializes a new instance of the <see cref="IndustryTeam" /> class.
        /// </summary>
        public IndustryTeam() {
            ContentType = "application/vnd.ccp.eve.IndustryTeam-v1+json";
        }

        /// <summary>
        ///     The team ID
        /// </summary>
        /// <value>The identifier.</value>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        ///     The team name
        /// </summary>
        /// <value>The name.</value>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        ///     The solar system
        /// </summary>
        /// <value>The solar system.</value>
        [DataMember(Name = "solarSystem")]
        public LinkedEntity<SolarSystem> SolarSystem { get; set; }

        /// <summary>
        ///     The team specialization
        /// </summary>
        /// <value>The specialization.</value>
        [DataMember(Name = "specialization")]
        public LinkedEntity<IndustrySpeciality> Specialization { get; set; }

        /// <summary>
        ///     The team creation time
        /// </summary>
        /// <value>The creation time.</value>
        [DataMember(Name = "creationTime")]
        public DateTime CreationTime { get; set; }

        /// <summary>
        ///     The team expiry time
        /// </summary>
        /// <value>The expiry time.</value>
        [DataMember(Name = "expiryTime")]
        public DateTime ExpiryTime { get; set; }

        /// <summary>
        ///     The team cost modifier
        /// </summary>
        /// <value>The cost modifier.</value>
        [DataMember(Name = "costModifier")]
        public float CostModifier { get; set; }

        /// <summary>
        ///     A list of the team workers
        /// </summary>
        /// <value>The workers.</value>
        [DataMember(Name = "workers")]
        public IReadOnlyList<IndustryTeamWorker> Workers { get; set; }

        /// <summary>
        ///     Activity
        /// </summary>
        /// <value>The activity.</value>
        [DataMember(Name = "activity")]
        public int Activity { get; set; }


        /// <summary>
        ///     The expiry time of the auction, if applicable
        /// </summary>
        /// <value>The auction expiry time.</value>
        [DataMember(Name = "auctionExpiryTime")]
        public DateTime AuctionExpiryTime { get; set; }


        /// <summary>
        ///     Gets or sets the solar system bids, if applicable
        /// </summary>
        /// <value>The solar system bids.</value>
        [DataMember(Name = "solarSystemBids")]
        public IReadOnlyList<BidEntry> SolarSystemBids { get; set; }

        /// <summary>
        ///     Class BidEntry.
        /// </summary>
        [DataContract]
        public class BidEntry {
            /// <summary>
            ///     Gets or sets the character bids.
            /// </summary>
            /// <value>The character bids.</value>
            [DataMember(Name = "characterBids")]
            public IReadOnlyList<CharacterBid> CharacterBids { get; set; }

            /// <summary>
            ///     Gets or sets the solar system.
            /// </summary>
            /// <value>The solar system.</value>
            [DataMember(Name = "solarSystem")]
            public LinkedEntity<SolarSystem> SolarSystem { get; set; }

            /// <summary>
            ///     Gets or sets the bid amount.
            /// </summary>
            /// <value>The bid amount.</value>
            [DataMember(Name = "bidAmount")]
            public double BidAmount { get; set; }
        }

        /// <summary>
        ///     Class CharacterBid.
        /// </summary>
        [DataContract]
        public class CharacterBid {
            /// <summary>
            ///     Gets or sets the character.
            /// </summary>
            /// <value>The character.</value>
            [DataMember(Name = "character")]
            public CharacterEntry Character { get; set; }

            /// <summary>
            ///     Gets or sets the bid amount.
            /// </summary>
            /// <value>The bid amount.</value>
            [DataMember(Name = "bidAmount")]
            public double BidAmount { get; set; }
        }
    }
}