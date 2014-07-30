using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models {

    /// <summary>
    /// Represents a CREST /industry/teams/ response
    /// </summary>
    public class CrestIndustryTeams : CrestCollectionResponse {

        /// <summary>
        /// A list of the teams
        /// </summary>
        [DataMember(Name = "items")]
        public IList<Team> Teams { get; set; }

        /// <summary>
        /// Represents a CREST industry team
        /// </summary>
        public class Team {

            /// <summary>
            /// The solar system
            /// </summary>
            [DataMember(Name = "solarSystem")]
            public CrestNamedEntity SolarSystem { get; set; }

            /// <summary>
            /// The team specialization
            /// </summary>
            [DataMember(Name = "specialization")]
            public CrestLinkedEntity Specialization { get; set; }

            /// <summary>
            /// The team creation time
            /// </summary>
            [DataMember(Name = "creationTime")]
            public DateTime CreationTime { get; set; }

            /// <summary>
            /// The team expiry time
            /// </summary>
            [DataMember(Name = "expiryTime")]
            public DateTime ExpiryTime { get; set; }

            /// <summary>
            /// The team cost modifier
            /// </summary>
            [DataMember(Name = "costModifier")]
            public float CostModifier { get; set; }

            /// <summary>
            /// A list of the team workers
            /// </summary>
            [DataMember(Name = "workers")]
            public IList<CrestIndustryTeamWorker> Workers { get; set; }

        }
   
    }
}
