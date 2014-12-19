// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Lars Kristian
// Created          : 12-19-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 12-19-2014
// ***********************************************************************
// <copyright file="DustRoot.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Links;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    /// <summary>
    /// Class DustRoot. This class cannot be inherited.
    /// </summary>
    public sealed class DustRoot : CrestResource<DustRoot> {

        /// <summary>
        /// Initializes a new instance of the <see cref="DustRoot" /> class.
        /// </summary>
        public DustRoot() {
            ContentType = "application/vnd.ccp.eve.DustRoot-v1+json";
        }

        /// <summary>
        /// Gets or sets the battle queues.
        /// </summary>
        /// <value>The battle queues.</value>
        [DataMember(Name = "battleQueues")]
        public Href<NotImplemented> BattleQueues { get; set; }

        /// <summary>
        /// Gets or sets the battles.
        /// </summary>
        /// <value>The battles.</value>
        [DataMember(Name = "battles")]
        public Href<NotImplemented> Battles { get; set; }

        /// <summary>
        /// Gets or sets the checkpoints.
        /// </summary>
        /// <value>The checkpoints.</value>
        [DataMember(Name = "checkpoints")]
        public Href<NotImplemented> Checkpoints { get; set; }

        /// <summary>
        /// Gets or sets the configuration.
        /// </summary>
        /// <value>The configuration.</value>
        [DataMember(Name = "configuration")]
        public Href<NotImplemented> Configuration { get; set; }

        /// <summary>
        /// Gets or sets the content streaming.
        /// </summary>
        /// <value>The content streaming.</value>
        [DataMember(Name = "contentStreaming")]
        public Href<NotImplemented> contentStreaming { get; set; }

        /// <summary>
        /// Gets or sets the devices.
        /// </summary>
        /// <value>The devices.</value>
        [DataMember(Name = "devices")]
        public Href<NotImplemented> Devices { get; set; }

        /// <summary>
        /// Gets or sets the district infrastructure.
        /// </summary>
        /// <value>The district infrastructure.</value>
        [DataMember(Name = "districtInfrastructure")]
        public Href<NotImplemented> DistrictInfrastructure { get; set; }

        /// <summary>
        /// Gets or sets the district reinforce.
        /// </summary>
        /// <value>The district reinforce.</value>
        [DataMember(Name = "districtReinforce")]
        public Href<NotImplemented> DistrictReinforce { get; set; }

        /// <summary>
        /// Gets or sets the documents.
        /// </summary>
        /// <value>The documents.</value>
        [DataMember(Name = "documents")]
        public Href<NotImplemented> Documents { get; set; }

        /// <summary>
        /// Gets or sets the dust portraits.
        /// </summary>
        /// <value>The dust portraits.</value>
        [DataMember(Name = "dustPortraits")]
        public Href<NotImplemented> DustPortraits { get; set; }

        /// <summary>
        /// Gets or sets the dust specialties.
        /// </summary>
        /// <value>The dust specialties.</value>
        [DataMember(Name = "dustSpecialites")]
        public Href<NotImplemented> DustSpecialties { get; set; }

        /// <summary>
        /// Gets or sets the full market groups.
        /// </summary>
        /// <value>The full market groups.</value>
        [DataMember(Name = "fullMarketGroups")]
        public Href<NotImplemented> FullMarketGroups { get; set; }

        /// <summary>
        /// Gets or sets the infantry market groups.
        /// </summary>
        /// <value>The infantry market groups.</value>
        [DataMember(Name = "infantryMarketGroups")]
        public Href<NotImplemented> infantryMarketGroups { get; set; }

        /// <summary>
        /// Gets or sets the keep alive.
        /// </summary>
        /// <value>The keep alive.</value>
        [DataMember(Name = "keepAlive")]
        public Href<NotImplemented> KeepAlive { get; set; }

        /// <summary>
        /// Gets or sets the L10N string.
        /// </summary>
        /// <value>The L10N string.</value>
        [DataMember(Name = "l10nString")]
        public Href<NotImplemented> L10NString { get; set; }

        /// <summary>
        /// Gets or sets the path to game.
        /// </summary>
        /// <value>The path to game.</value>
        [DataMember(Name = "pathToGame")]
        public Href<NotImplemented> PathToGame { get; set; }

        /// <summary>
        /// Gets or sets the squads.
        /// </summary>
        /// <value>The squads.</value>
        [DataMember(Name = "Squads")]
        public Href<NotImplemented> Squads { get; set; }

        /// <summary>
        /// Gets or sets the loyalty stores.
        /// </summary>
        /// <value>The loyalty stores.</value>
        [DataMember(Name = "loyaltyStores")]
        public Href<NotImplemented> LoyaltyStores { get; set; }
    }
}
