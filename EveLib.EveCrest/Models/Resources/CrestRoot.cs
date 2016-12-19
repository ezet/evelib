// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Lars Kristian
// Created          : 12-16-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 10-03-2015
// ***********************************************************************
// <copyright file="CrestRoot.cs" company="Lars Kristian Dahl">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Links;
using eZet.EveLib.EveCrestModule.Models.Resources.Industry;
using eZet.EveLib.EveCrestModule.Models.Resources.Market;
using eZet.EveLib.EveCrestModule.Models.Resources.Tournaments;

// TODO InsurancePrices
// TODO time
// TODO oppurtunities
// TODO bloodlines
// TODO races

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    /// <summary>
    ///     Represents the root response for CREST
    /// </summary>
    [DataContract]
    public sealed class CrestRoot : CrestResource<CrestRoot> {
        /// <summary>
        ///     Represents the server status types
        /// </summary>
        public enum ServiceStatusType {
            /// <summary>
            ///     Server is offline
            /// </summary>
            [EnumMember(Value = "offline")]
            Offline,

            /// <summary>
            ///     Server is in VIP mode
            /// </summary>
            [EnumMember(Value = "vip")]
            Vip,

            /// <summary>
            ///     Server is online
            /// </summary>
            [EnumMember(Value = "online")]
            Online
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="CrestRoot" /> class.
        /// </summary>
        public CrestRoot() {
            ContentType = "application/vnd.ccp.eve.Api-v3+json";
        }

        /// <summary>
        ///     Gets or sets the constellations.
        /// </summary>
        /// <value>The constellations.</value>
        [DataMember(Name = "constellations")]
        public Href<ConstellationCollection> Constellations { get; set; }

        /// <summary>
        ///     Gets or sets the item groups.
        /// </summary>
        /// <value>The item groups.</value>
        [DataMember(Name = "itemGroups")]
        public Href<ItemGroupCollection> ItemGroups { get; set; }

        /// <summary>
        ///     Gets or sets the corporations.
        /// </summary>
        /// <value>The corporations.</value>
        [DataMember(Name = "corporations")]
        public Href<NotImplemented> Corporations { get; set; }

        /// <summary>
        ///     Gets or sets the alliances.
        /// </summary>
        /// <value>The alliances.</value>
        [DataMember(Name = "alliances")]
        public Href<AllianceCollection> Alliances { get; set; }

        /// <summary>
        ///     Gets or sets the item types.
        /// </summary>
        /// <value>The item types.</value>
        [DataMember(Name = "itemTypes")]
        public Href<ItemTypeCollection> ItemTypes { get; set; }


        /// <summary>
        /// Gets or sets the user count.
        /// </summary>
        /// <value>
        /// The user count.
        /// </value>
        [DataMember(Name = "userCount")]
        public int UserCount { get; set; }

        /// <summary>
        ///     Gets or sets the decode.
        /// </summary>
        /// <value>The decode.</value>
        [DataMember(Name = "decode")]
        public Href<TokenDecode> Decode { get; set; }

        /// <summary>
        ///     Gets or sets the market prices.
        /// </summary>
        /// <value>The market prices.</value>
        [DataMember(Name = "marketPrices")]
        public Href<MarketTypePriceCollection> MarketPrices { get; set; }

        /// <summary>
        ///     Gets or sets the item categories.
        /// </summary>
        /// <value>The item categories.</value>
        [DataMember(Name = "itemCategories")]
        public Href<MarketTypePriceCollection> ItemCategories { get; set; }

        /// <summary>
        ///     Gets or sets the regions.
        /// </summary>
        /// <value>The regions.</value>
        [DataMember(Name = "regions")]
        public Href<RegionCollection> Regions { get; set; }

        /// <summary>
        ///     Gets or sets the bloodlines.
        /// </summary>
        /// <value>The bloodlines.</value>
        [DataMember(Name = "bloodlines")]
        public Href<NotImplemented> Bloodlines { get; set; }

        /// <summary>
        ///     Gets or sets the market groups.
        /// </summary>
        /// <value>The market groups.</value>
        [DataMember(Name = "marketGroups")]
        public Href<MarketGroupCollection> MarketGroups { get; set; }

        /// <summary>
        ///     Gets or sets the systems.
        /// </summary>
        /// <value>The systems.</value>
        [DataMember(Name = "systems")]
        public Href<SystemCollection> Systems { get; set; }

        /// <summary>
        ///     Gets or sets the sovereignty.
        /// </summary>
        /// <value>The sovereignty.</value>
        [DataMember(Name = "sovereignty")]
        public SovereigntyRoot Sovereignty { get; set; }


        /// <summary>
        ///     Gets or sets the tournaments.
        /// </summary>
        /// <value>The tournaments.</value>
        [DataMember(Name = "tournaments")]
        public Href<TournamentCollection> Tournaments { get; set; }

        /// <summary>
        ///     Gets or sets the virtual good store.
        /// </summary>
        /// <value>The virtual good store.</value>
        [DataMember(Name = "virtualGoodStore")]
        public Href<string> VirtualGoodStore { get; set; }

        /// <summary>
        ///     The server version
        /// </summary>
        /// <value>The server version.</value>
        [DataMember(Name = "serverVersion")]
        public string ServerVersion { get; set; }

        /// <summary>
        ///     Gets or sets the wars.
        /// </summary>
        /// <value>The wars.</value>
        [DataMember(Name = "wars")]
        public Href<WarCollection> Wars { get; set; }

        /// <summary>
        ///     Gets or sets the incursions.
        /// </summary>
        /// <value>The incursions.</value>
        [DataMember(Name = "incursions")]
        public Href<IncursionCollection> Incursions { get; set; }

        /// <summary>
        ///     Gets or sets the dogma.
        /// </summary>
        /// <value>The dogma.</value>
        [DataMember(Name = "dogma")]
        public DogmaCategory Dogma { get; set; }

        /// <summary>
        ///     Gets or sets the races.
        /// </summary>
        /// <value>The races.</value>
        [DataMember(Name = "races")]
        public Href<NotImplemented> Races { get; set; }

        /// <summary>
        ///     Gets or sets the authentication endpoint.
        /// </summary>
        /// <value>The authentication endpoint.</value>
        [DataMember(Name = "authEndpoint")]
        public Href<string> AuthEndpoint { get; set; }

        /// <summary>
        ///     The service status for all services
        /// </summary>
        /// <value>The service status.</value>
        [DataMember(Name = "serviceStatus")]
        public ServiceStatusType ServiceStatus { get; set; }

        /// <summary>
        ///     Current Time endpoint
        /// </summary>
        /// <value>The industry.</value>
        [DataMember(Name = "industry")]
        public CrestIndustry Industry { get; set; }

        /// <summary>
        /// Gets or sets the NPC corporations.
        /// </summary>
        /// <value>
        /// The NPC corporations.
        /// </value>
        [DataMember(Name = "npcCorporations")]
        public Href<NpcCorporationsCollection> NpcCorporations { get; set; }

        /// <summary>
        ///     Current Time endpoint
        /// </summary>
        /// <value>The time.</value>
        [DataMember(Name = "time")]
        public Href<NotImplemented> Time { get; set; }

        /// <summary>
        ///     Gets or sets the market types.
        /// </summary>
        /// <value>The market types.</value>
        [DataMember(Name = "marketTypes")]
        public Href<MarketTypeCollection> MarketTypes { get; set; }

        /// <summary>
        ///     The server name
        /// </summary>
        /// <value>The name of the server.</value>
        [DataMember(Name = "serverName")]
        public string ServerName { get; set; }

        /// <summary>
        ///     Class SovereigntyRoot.
        /// </summary>
        [DataContract]
        public class SovereigntyRoot {
            /// <summary>
            ///     Gets or sets the campaigns.
            /// </summary>
            /// <value>The campaigns.</value>
            [DataMember(Name = "campaigns")]
            public Href<SovCampaignsCollection> Campaigns { get; set; }

            /// <summary>
            ///     Gets or sets the structures.
            /// </summary>
            /// <value>The structures.</value>
            [DataMember(Name = "structures")]
            public Href<SovStructureCollection> Structures { get; set; }
        }

        /// <summary>
        ///     Class CrestIndustry.
        /// </summary>
        [DataContract]
        public class CrestIndustry {
            /// <summary>
            ///     Gets or sets the facilities.
            /// </summary>
            /// <value>The facilities.</value>
            [DataMember(Name = "facilities")]
            public Href<IndustryFacilityCollection> Facilities { get; set; }

            /// <summary>
            ///     Gets or sets the systems.
            /// </summary>
            /// <value>The systems.</value>
            [DataMember(Name = "systems")]
            public Href<IndustrySystemCollection> Systems { get; set; }
        }

        /// <summary>
        ///     Class DogmaCategory.
        /// </summary>
        [DataContract]
        public class DogmaCategory {
            /// <summary>
            ///     Gets or sets the attributes.
            /// </summary>
            /// <value>The attributes.</value>
            [DataMember(Name = "attributes")]
            public Href<DogmaAttributeCollection> Attributes { get; set; }

            /// <summary>
            ///     Gets or sets the effects.
            /// </summary>
            /// <value>The effects.</value>
            [DataMember(Name = "effects")]
            public Href<DogmaEffectCollection> Effects { get; set; }
        }
    }
}