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
            public CrestEntity Specialization { get; set; }

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
            public IList<Worker> Workers { get; set; }

        }

        /// <summary>
        /// Represents a team worker
        /// </summary>
        public class Worker {

            /// <summary>
            /// The worker bonus
            /// </summary>
            [DataMember(Name = "bonus")]
            public WorkerBonus Bonus { get; set; }

            /// <summary>
            /// The worker specialization
            /// </summary>
            [DataMember(Name = "specialization")]
            public CrestEntity Specialization { get; set; }

        }

        /// <summary>
        /// Represents a worker bonus
        /// </summary>
        public class WorkerBonus {

            /// <summary>
            /// The bonus ID
            /// </summary>
            [DataMember(Name = "id")]
            public int Id { get; set; }

            /// <summary>
            /// The bonus value
            /// </summary>
            [DataMember(Name = "value")]
            public float Value { get; set; }

            /// <summary>
            /// The bonus type
            /// </summary>
            [DataMember(Name = "bonusType")]
            public BonusType Type { get; set; }
        }

        /// <summary>
        /// Represents the worker bonus types
        /// </summary>
        public enum BonusType {
            /// <summary>
            /// Material Efficency Bonus
            /// </summary>
            Me,
            /// <summary>
            /// Production Efficiency Bonus
            /// </summary>
            Pe
        }
    }
}
