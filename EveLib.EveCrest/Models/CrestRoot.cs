using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models {

    /// <summary>
    /// Represents the root response for CREST
    /// </summary>
    [DataContract]
    public class CrestRoot {

        /// <summary>
        /// The message of the day for each service
        /// </summary>
        [DataMember(Name = "motd")]
        public MessageOfTheDay Motd { get; set; }

        /// <summary>
        /// The uri for CREST base
        /// </summary>
        [DataMember(Name = "crestEndpoint")]
        public CrestHref<string> CrestEndpoint { get; set; }

        /// <summary>
        /// The server version
        /// </summary>
        [DataMember(Name = "serverVersion")]
        public string ServerVersion { get; set; }

        /// <summary>
        /// The service status for all services
        /// </summary>
        [DataMember(Name = "serviceStatus")]
        public ServerStatus ServiceStatus { get; set; }

        /// <summary>
        /// The server name
        /// </summary>
        [DataMember(Name = "serverName")]
        public string ServerName { get; set; }

        /// <summary>
        /// The number of current users of services
        /// </summary>
        [DataMember(Name = "userCount")]
        public UserCount UserCounts { get; set; }

        /// <summary>
        /// Current Time endpoint
        /// </summary>
        [DataMember(Name = "time")]
        public CrestHref<string> Time { get; set; }

        /// <summary>
        /// Represents the number of current users of services
        /// </summary>
        [DataContract]
        public class UserCount {

            /// <summary>
            /// Number of currently online users for DUST
            /// </summary>
            [DataMember(Name = "dust")]
            public int Dust { get; set; }

            /// <summary>
            /// Number of currently online users for Eve Online
            /// </summary>
            [DataMember(Name = "eve")]
            public int Eve { get; set; }
        }

        /// <summary>
        /// Represents the service status for all servers
        /// </summary>
        public class ServerStatus {
            /// <summary>
            /// The service status for DUST
            /// </summary>
            [DataMember(Name = "dust")]
            public ServiceStatusType Dust { get; set; }

            /// <summary>
            /// The service status for EVE Online
            /// </summary>
            [DataMember(Name = "eve")]
            public ServiceStatusType Eve { get; set; }

            /// <summary>
            /// The service status for the api server
            /// </summary>
            [DataMember(Name = "server")]
            public ServiceStatusType Server { get; set; }
        }


        /// <summary>
        /// Represents the server status types
        /// </summary>
        public enum ServiceStatusType {
            /// <summary>
            /// Server is online
            /// </summary>
            Online,
            /// <summary>
            /// Server is in VIP mode
            /// </summary>
            Vip,
            /// <summary>
            /// Server is offline
            /// </summary>
            Offline
        }


        /// <summary>
        /// Represents a Motd object
        /// </summary>
        [DataContract]
        public class MessageOfTheDay {

            /// <summary>
            /// Gets the MOTD for Dust 514
            /// </summary>
            [DataMember(Name = "dust")]
            public CrestHref<string> Dust { get; set; }

            /// <summary>
            /// Gets the MOTD for Eve Online
            /// </summary>
            [DataMember(Name = "eve")]
            public CrestHref<string> Eve { get; set; }

            /// <summary>
            /// Gets a url for the MOTD on the server
            /// </summary>
            [DataMember(Name = "server")]
            public CrestHref<string> Server { get; set; }
        }

    }
}
