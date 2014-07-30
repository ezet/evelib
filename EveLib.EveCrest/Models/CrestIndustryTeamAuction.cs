using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models {
    /// <summary>
    /// Response type for CREST Industry Team Auctions
    /// </summary>
    [DataContract]
    public class CrestIndustryTeamAuction : CrestCollectionResponse {

        /// <summary>
        /// A list of team auctions
        /// </summary>
        [DataMember(Name = "items")]
        public List<TeamAuction> Auctions { get; set; }

        /// <summary>
        /// Represents a team auction
        /// </summary>
        [DataContract]
        public class TeamAuction {

            /// <summary>
            /// The solar system the auction is for
            /// </summary>
            [DataMember(Name = "solarSystem")]
            public CrestNamedEntity SolarSystem { get; set; }

            /// <summary>
            /// The specialization of the team
            /// </summary>
            [DataMember(Name = "specialization")]
            public CrestLinkedEntity Specialization { get; set; }

            /// <summary>
            /// The time the team was created
            /// </summary>
            [DataMember(Name = "creationTime")]
            public DateTime CreationTime { get; set; }

            /// <summary>
            /// The time the team will expire
            /// </summary>
            [DataMember(Name = "expiryTime")]
            public DateTime ExpiryTime { get; set; }

            /// <summary>
            /// The expiry time of the auction
            /// </summary>
            [DataMember(Name = "auctionExpiryTime")]
            public DateTime AuctionExpiryTime { get; set; }

            /// <summary>
            /// The team cost modifier
            /// </summary>
            [DataMember(Name = "costModifier")]
            public float CostModifier { get; set; }

            /// <summary>
            /// A list of workers on the team
            /// </summary>
            [DataMember(Name = "workers")]
            public List<CrestIndustryTeamWorker> Workers { get; set; }

        }
    }
}