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

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    /// <summary>
    /// Represents the root response for CREST
    /// </summary>
    [DataContract]
    public sealed class CrestRoot : CrestResource<CrestRoot> {
        /// <summary>
        /// Represents the server status types
        /// </summary>
        public enum ServiceStatusType {
            /// <summary>
            /// Server is offline
            /// </summary>
            [EnumMember(Value = "offline")] Offline,

            /// <summary>
            /// Server is in VIP mode
            /// </summary>
            [EnumMember(Value = "vip")] Vip,

            /// <summary>
            /// Server is online
            /// </summary>
            [EnumMember(Value = "online")] Online,
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CrestRoot" /> class.
        /// </summary>
        public CrestRoot() {
            ContentType = "application/vnd.ccp.eve.Api-v3+json";
        }

        /// <summary>
        /// The message of the day for each service
        /// </summary>
        /// <value>The motd.</value>
        [DataMember(Name = "motd")]
        public MessageOfTheDay Motd { get; set; }

        /// <summary>
        /// The uri for CREST base
        /// </summary>
        /// <value>The crest endpoint.</value>
        [DataMember(Name = "crestEndpoint")]
        public Href<CrestRoot> CrestEndpoint { get; set; }


        /// <summary>
        /// Gets or sets the corporation roles.
        /// </summary>
        /// <value>The corporation roles.</value>
        [DataMember(Name = "corporationRoles")]
        public Href<NotImplemented> CorporationRoles { get; set; }


        /// <summary>
        /// Gets or sets the item groups.
        /// </summary>
        /// <value>The item groups.</value>
        [DataMember(Name = "itemGroups")]
        public Href<ItemGroupCollection> ItemGroups { get; set; }

        /// <summary>
        /// Gets or sets the channels.
        /// </summary>
        /// <value>The channels.</value>
        [DataMember(Name = "channels")]
        public Href<NotImplemented> Channels { get; set; }

        /// <summary>
        /// Gets or sets the corporations.
        /// </summary>
        /// <value>The corporations.</value>
        [DataMember(Name = "corporations")]
        public Href<NotImplemented> Corporations { get; set; }

        /// <summary>
        /// Gets or sets the alliances.
        /// </summary>
        /// <value>The alliances.</value>
        [DataMember(Name = "alliances")]
        public Href<AllianceCollection> Alliances { get; set; }

        /// <summary>
        /// Gets or sets the item types.
        /// </summary>
        /// <value>The item types.</value>
        [DataMember(Name = "itemTypes")]
        public Href<ItemTypeCollection> ItemTypes { get; set; }

        /// <summary>
        /// Gets or sets the decode.
        /// </summary>
        /// <value>The decode.</value>
        [DataMember(Name = "decode")]
        public Href<TokenDecode> Decode { get; set; }

        /// <summary>
        /// Gets or sets the battle theatres.
        /// </summary>
        /// <value>The battle theatres.</value>
        [DataMember(Name = "battleTheatres")]
        public Href<NotImplemented> BattleTheatres { get; set; }

        /// <summary>
        /// Gets or sets the market prices.
        /// </summary>
        /// <value>The market prices.</value>
        [DataMember(Name = "marketPrices")]
        public Href<MarketTypePriceCollection> MarketPrices { get; set; }

        /// <summary>
        /// Gets or sets the item categories.
        /// </summary>
        /// <value>The item categories.</value>
        [DataMember(Name = "itemCategories")]
        public Href<MarketTypePriceCollection> ItemCategories { get; set; }

        /// <summary>
        /// Gets or sets the regions.
        /// </summary>
        /// <value>The regions.</value>
        [DataMember(Name = "regions")]
        public Href<RegionCollection> Regions { get; set; }

        /// <summary>
        /// Gets or sets the bloodlines.
        /// </summary>
        /// <value>The bloodlines.</value>
        [DataMember(Name = "bloodlines")]
        public Href<NotImplemented> Bloodlines { get; set; }

        /// <summary>
        /// Gets or sets the market groups.
        /// </summary>
        /// <value>The market groups.</value>
        [DataMember(Name = "marketGroups")]
        public Href<MarketGroupCollection> MarketGroups { get; set; }

        /// <summary>
        /// Gets or sets the sovereignty.
        /// </summary>
        /// <value>The sovereignty.</value>
        [DataMember(Name = "sovereignty")]
        public SovereigntyRoot Sovereignty { get; set; }


        /// <summary>
        /// Gets or sets the tournaments.
        /// </summary>
        /// <value>The tournaments.</value>
        [DataMember(Name = "tournaments")]
        public Href<TournamentCollection> Tournaments { get; set; }

        /// <summary>
        /// Gets or sets the map.
        /// </summary>
        /// <value>The map.</value>
        [DataMember(Name = "map")]
        public Href<NotImplemented> Map { get; set; }

        /// <summary>
        /// Gets or sets the virtual good store.
        /// </summary>
        /// <value>The virtual good store.</value>
        [DataMember(Name = "virtualGoodStore")]
        public Href<string> VirtualGoodStore { get; set; }

        /// <summary>
        /// The server version
        /// </summary>
        /// <value>The server version.</value>
        [DataMember(Name = "serverVersion")]
        public string ServerVersion { get; set; }

        /// <summary>
        /// Gets or sets the wars.
        /// </summary>
        /// <value>The wars.</value>
        [DataMember(Name = "wars")]
        public Href<WarCollection> Wars { get; set; }

        /// <summary>
        /// Gets or sets the incursions.
        /// </summary>
        /// <value>The incursions.</value>
        [DataMember(Name = "incursions")]
        public Href<IncursionCollection> Incursions { get; set; }

        /// <summary>
        /// Gets or sets the races.
        /// </summary>
        /// <value>The races.</value>
        [DataMember(Name = "races")]
        public Href<NotImplemented> Races { get; set; }

        /// <summary>
        /// Gets or sets the authentication endpoint.
        /// </summary>
        /// <value>The authentication endpoint.</value>
        [DataMember(Name = "authEndpoint")]
        public Href<string> AuthEndpoint { get; set; }

        /// <summary>
        /// The service status for all services
        /// </summary>
        /// <value>The service status.</value>
        [DataMember(Name = "serviceStatus")]
        public ServerStatus ServiceStatus { get; set; }

        /// <summary>
        /// The number of current users of services
        /// </summary>
        /// <value>The user counts.</value>
        [DataMember(Name = "userCounts")]
        public UserCount UserCounts { get; set; }

        /// <summary>
        /// Current Time endpoint
        /// </summary>
        /// <value>The industry.</value>
        [DataMember(Name = "industry")]
        public CrestIndustry Industry { get; set; }

        /// <summary>
        /// Gets or sets the clients.
        /// </summary>
        /// <value>The clients.</value>
        [DataMember(Name = "clients")]
        public ClientLinks Clients { get; set; }

        /// <summary>
        /// Current Time endpoint
        /// </summary>
        /// <value>The time.</value>
        [DataMember(Name = "time")]
        public Href<NotImplemented> Time { get; set; }

        /// <summary>
        /// Gets or sets the market types.
        /// </summary>
        /// <value>The market types.</value>
        [DataMember(Name = "marketTypes")]
        public Href<MarketTypeCollection> MarketTypes { get; set; }

        /// <summary>
        /// The server name
        /// </summary>
        /// <value>The name of the server.</value>
        [DataMember(Name = "serverName")]
        public string ServerName { get; set; }

        /// <summary>
        /// Class SovereigntyRoot.
        /// </summary>
        [DataContract]
        public class SovereigntyRoot {

            /// <summary>
            /// Gets or sets the campaigns.
            /// </summary>
            /// <value>The campaigns.</value>
            [DataMember(Name = "campaigns")]
            public Href<SovCampaignsCollection> Campaigns { get; set; }

            /// <summary>
            /// Gets or sets the structures.
            /// </summary>
            /// <value>The structures.</value>
            [DataMember(Name = "structures")]
            public Href<SovStructureCollection> Structures { get; set; }
        }

        /// <summary>
        /// Class ClientLinks.
        /// </summary>
        [DataContract]
        public class ClientLinks {
            /// <summary>
            /// Gets or sets the dust.
            /// </summary>
            /// <value>The dust.</value>
            [DataMember(Name = "dust")]
            public Href<DustRoot> Dust { get; set; }

            /// <summary>
            /// Gets or sets the eve.
            /// </summary>
            /// <value>The eve.</value>
            [DataMember(Name = "eve")]
            public Href<EveRoot> Eve { get; set; }
        }


        /// <summary>
        /// Class CrestIndustry.
        /// </summary>
        [DataContract]
        public class CrestIndustry {
            /// <summary>
            /// Gets or sets the facilities.
            /// </summary>
            /// <value>The facilities.</value>
            [DataMember(Name = "facilities")]
            public Href<IndustryFacilityCollection> Facilities { get; set; }

            /// <summary>
            /// Gets or sets the specialities.
            /// </summary>
            /// <value>The specialities.</value>
            [DataMember(Name = "specialities")]
            public Href<IndustrySpecialityCollection> Specialities { get; set; }

            /// <summary>
            /// Gets or sets the teams in auction.
            /// </summary>
            /// <value>The teams in auction.</value>
            [DataMember(Name = "teamsInAuction")]
            public Href<IndustryTeamCollection> TeamsInAuction { get; set; }

            /// <summary>
            /// Gets or sets the systems.
            /// </summary>
            /// <value>The systems.</value>
            [DataMember(Name = "systems")]
            public Href<IndustrySystemCollection> Systems { get; set; }

            /// <summary>
            /// Gets or sets the teams.
            /// </summary>
            /// <value>The teams.</value>
            [DataMember(Name = "teams")]
            public Href<IndustryTeamCollection> Teams { get; set; }
        }


        /// <summary>
        /// Represents a Motd object
        /// </summary>
        [DataContract]
        public class MessageOfTheDay {
            /// <summary>
            /// Gets the MOTD for Dust 514
            /// </summary>
            /// <value>The dust.</value>
            [DataMember(Name = "dust")]
            public Href<string> Dust { get; set; }

            /// <summary>
            /// Gets the MOTD for Eve Online
            /// </summary>
            /// <value>The eve.</value>
            [DataMember(Name = "eve")]
            public Href<string> Eve { get; set; }

            /// <summary>
            /// Gets a url for the MOTD on the server
            /// </summary>
            /// <value>The server.</value>
            [DataMember(Name = "server")]
            public Href<string> Server { get; set; }
        }

        /// <summary>
        /// Represents the service status for all servers
        /// </summary>
        public class ServerStatus {
            /// <summary>
            /// The service status for DUST
            /// </summary>
            /// <value>The dust.</value>
            [DataMember(Name = "dust")]
            public ServiceStatusType Dust { get; set; }

            /// <summary>
            /// The service status for EVE Online
            /// </summary>
            /// <value>The eve.</value>
            [DataMember(Name = "eve")]
            public ServiceStatusType Eve { get; set; }

            /// <summary>
            /// The service status for the api server
            /// </summary>
            /// <value>The server.</value>
            [DataMember(Name = "server")]
            public ServiceStatusType Server { get; set; }
        }

        /// <summary>
        /// Represents the number of current users of services
        /// </summary>
        [DataContract]
        public class UserCount {
            /// <summary>
            /// Number of currently online users for DUST
            /// </summary>
            /// <value>The dust.</value>
            [DataMember(Name = "dust")]
            public int Dust { get; set; }

            /// <summary>
            /// Number of currently online users for Eve Online
            /// </summary>
            /// <value>The eve.</value>
            [DataMember(Name = "eve")]
            public int Eve { get; set; }
        }
    }
}