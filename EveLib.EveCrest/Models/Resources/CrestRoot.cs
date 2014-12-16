using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models {
    /// <summary>
    ///     Represents the root response for CREST
    /// </summary>
    [DataContract]
    public sealed class CrestRoot : CrestResource {
        /// <summary>
        ///     Represents the server status types
        /// </summary>
        public enum ServiceStatusType {
            /// <summary>
            ///     Server is online
            /// </summary>
            Online,

            /// <summary>
            ///     Server is in VIP mode
            /// </summary>
            Vip,

            /// <summary>
            ///     Server is offline
            /// </summary>
            Offline
        }

        public CrestRoot() {
            Version = "application/vnd.ccp.eve.Api-v3+json";
        }

        /// <summary>
        ///     The message of the day for each service
        /// </summary>
        [DataMember(Name = "motd")]
        public MessageOfTheDay Motd { get; set; }

        /// <summary>
        ///     The uri for CREST base
        /// </summary>
        [DataMember(Name = "crestEndpoint")]
        public CrestHref<CrestRoot> CrestEndpoint { get; set; }


        /// <summary>
        ///     Gets or sets the corporation roles.
        /// </summary>
        /// <value>The corporation roles.</value>
        [DataMember(Name = "corporationRoles")]
        public CrestHref<CrestPlaceholderModel> CorporationRoles { get; set; }


        /// <summary>
        ///     Gets or sets the item groups.
        /// </summary>
        /// <value>The item groups.</value>
        [DataMember(Name = "itemGroups")]
        public CrestHref<CrestItemGroupCollection> ItemGroups { get; set; }

        [DataMember(Name = "channel")]
        public CrestHref<CrestPlaceholderModel> Channels { get; set; }

        [DataMember(Name = "corporations")]
        public CrestHref<CrestPlaceholderModel> Corporations { get; set; }

        [DataMember(Name = "alliances")]
        public CrestHref<CrestAllianceCollection> Alliances { get; set; }

        [DataMember(Name = "decode")]
        public CrestHref<CrestPlaceholderModel> Decode { get; set; }

        [DataMember(Name = "battleTheatres")]
        public CrestHref<CrestPlaceholderModel> BattleTheatres { get; set; }

        [DataMember(Name = "marketPrices")]
        public CrestHref<CrestMarketTypePriceCollection> MarketPrices { get; set; }

        [DataMember(Name = "regions")]
        public CrestHref<CrestRegionCollection> Regions { get; set; }

        [DataMember(Name = "bloodlines")]
        public CrestHref<CrestPlaceholderModel> Bloodlines { get; set; }

        [DataMember(Name = "marketGroups")]
        public CrestHref<CrestMarketGroupCollection> MarketGroups { get; set; }


        /// <summary>
        ///     The server version
        /// </summary>
        [DataMember(Name = "serverVersion")]
        public string ServerVersion { get; set; }

        /// <summary>
        ///     The service status for all services
        /// </summary>
        [DataMember(Name = "serviceStatus")]
        public ServerStatus ServiceStatus { get; set; }

        /// <summary>
        ///     The server name
        /// </summary>
        [DataMember(Name = "serverName")]
        public string ServerName { get; set; }

        /// <summary>
        ///     The number of current users of services
        /// </summary>
        [DataMember(Name = "userCount")]
        public UserCount UserCounts { get; set; }

        /// <summary>
        ///     Current Time endpoint
        /// </summary>
        [DataMember(Name = "time")]
        public CrestHref<string> Time { get; set; }

        /// <summary>
        ///     Current Time endpoint
        /// </summary>
        [DataMember(Name = "industry")]
        public CrestIndustry Industry { get; set; }

        [DataContract]
        public class CrestIndustry {
            [DataMember(Name = "facilities")]
            public CrestHref<CrestIndustryFacilityCollection> Facilities { get; set; }

            [DataMember(Name = "specialities")]
            public CrestHref<CrestIndustrySpecialityCollection> Specialities { get; set; }

            [DataMember(Name = "teamsInAuction")]
            public CrestHref<string> TeamsInAuction { get; set; }

            [DataMember(Name = "systems")]
            public CrestHref<CrestIndustrySystemCollection> Systems { get; set; }

            [DataMember(Name = "teams")]
            public CrestHref<CrestIndustryTeamCollection> Teams { get; set; }
        }


        /// <summary>
        ///     Represents a Motd object
        /// </summary>
        [DataContract]
        public class MessageOfTheDay {
            /// <summary>
            ///     Gets the MOTD for Dust 514
            /// </summary>
            [DataMember(Name = "dust")]
            public CrestHref<string> Dust { get; set; }

            /// <summary>
            ///     Gets the MOTD for Eve Online
            /// </summary>
            [DataMember(Name = "eve")]
            public CrestHref<string> Eve { get; set; }

            /// <summary>
            ///     Gets a url for the MOTD on the server
            /// </summary>
            [DataMember(Name = "server")]
            public CrestHref<string> Server { get; set; }
        }

        /// <summary>
        ///     Represents the service status for all servers
        /// </summary>
        public class ServerStatus {
            /// <summary>
            ///     The service status for DUST
            /// </summary>
            [DataMember(Name = "dust")]
            public ServiceStatusType Dust { get; set; }

            /// <summary>
            ///     The service status for EVE Online
            /// </summary>
            [DataMember(Name = "eve")]
            public ServiceStatusType Eve { get; set; }

            /// <summary>
            ///     The service status for the api server
            /// </summary>
            [DataMember(Name = "server")]
            public ServiceStatusType Server { get; set; }
        }

        /// <summary>
        ///     Represents the number of current users of services
        /// </summary>
        [DataContract]
        public class UserCount {
            /// <summary>
            ///     Number of currently online users for DUST
            /// </summary>
            [DataMember(Name = "dust")]
            public int Dust { get; set; }

            /// <summary>
            ///     Number of currently online users for Eve Online
            /// </summary>
            [DataMember(Name = "eve")]
            public int Eve { get; set; }
        }
    }
}