// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : larsd
// Created          : 10-03-2015
//
// Last Modified By : larsd
// Last Modified On : 02-15-2016
// ***********************************************************************
// <copyright file="SovCampaignsCollection.cs" company="Lars Kristian Dahl">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Links;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    /// <summary>
    ///     Class SovCampaignsCollection. This class cannot be inherited.
    /// </summary>
    [DataContract]
    public sealed class SovCampaignsCollection :
        CollectionResource<SovCampaignsCollection, SovCampaignsCollection.Campaign> {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SovCampaignsCollection" /> class.
        /// </summary>
        public SovCampaignsCollection() {
            ContentType = "application/vnd.ccp.eve.SovCampaignsCollection-v1+json; charset=utf-8";
        }


        /// <summary>
        ///     Class Campaign.
        /// </summary>
        [DataContract]
        public class Campaign {
            /// <summary>
            ///     Gets or sets the type of the event.
            /// </summary>
            /// <value>The type of the event.</value>
            [DataMember(Name = "eventType")]
            public int EventType { get; set; }

            /// <summary>
            ///     Gets or sets the campaign identifier.
            /// </summary>
            /// <value>The campaign identifier.</value>
            [DataMember(Name = "campaignID")]
            public int CampaignId { get; set; }

            /// <summary>
            ///     Gets or sets the source solar system.
            /// </summary>
            /// <value>The source solar system.</value>
            [DataMember(Name = "sourceSolarSystem")]
            public LinkedEntity<SolarSystem> SourceSolarSystem { get; set; }

            /// <summary>
            ///     Gets or sets the source item identifier.
            /// </summary>
            /// <value>The source item identifier.</value>
            [DataMember(Name = "sourceItemID")]
            public long SourceItemId { get; set; }

            /// <summary>
            ///     Gets or sets the start time.
            /// </summary>
            /// <value>The start time.</value>
            [DataMember(Name = "startTime")]
            public DateTime StartTime { get; set; }

            /// <summary>
            ///     Gets or sets the constellation.
            /// </summary>
            /// <value>The constellation.</value>
            [DataMember(Name = "constellation")]
            public LinkedEntity<Constellation> Constellation { get; set; }

            /// <summary>
            ///     Gets or sets the attackers.
            /// </summary>
            /// <value>The attackers.</value>
            [DataMember(Name = "attackers")]
            public AttackerEntity Attackers { get; set; }

            /// <summary>
            ///     Gets or sets the defender.
            /// </summary>
            /// <value>The defender.</value>
            [DataMember(Name = "defender")]
            public DefenderEntity Defender { get; set; }
        }

        /// <summary>
        ///     Class DefenderEntity.
        /// </summary>
        [DataContract]
        public class DefenderEntity {
            /// <summary>
            ///     Gets or sets the defender.
            /// </summary>
            /// <value>The defender.</value>
            [DataMember(Name = "defender")]
            public LinkedEntity<Alliance> Defender { get; set; }

            /// <summary>
            ///     Gets or sets the score.
            /// </summary>
            /// <value>The score.</value>
            [DataMember(Name = "score")]
            public float Score { get; set; }
        }

        /// <summary>
        ///     Class AttackerEntity.
        /// </summary>
        [DataContract]
        public class AttackerEntity {
            /// <summary>
            ///     Gets or sets the score.
            /// </summary>
            /// <value>The score.</value>
            [DataMember(Name = "score")]
            public float Score { get; set; }
        }
    }
}