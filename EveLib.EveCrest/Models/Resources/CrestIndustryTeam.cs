using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using eZet.EveLib.Modules.Models.Entities;
using eZet.EveLib.Modules.Models.Shared;

namespace eZet.EveLib.Modules.Models.Resources {
    /// <summary>
    ///     Represents a CREST industry team
    /// </summary>
    public sealed class CrestIndustryTeam : CrestResource {
        public CrestIndustryTeam() {
            Version = "application/vnd.ccp.eve.IndustryTeam-v1+json";
        }

        /// <summary>
        ///     The solar system
        /// </summary>
        [DataMember(Name = "solarSystem")]
        public CrestLinkedEntity<CrestSolarSystem> SolarSystem { get; set; }

        /// <summary>
        ///     The team specialization
        /// </summary>
        [DataMember(Name = "specialization")]
        public CrestLinkedEntity<CrestIndustrySpeciality> Specialization { get; set; }

        /// <summary>
        ///     The team creation time
        /// </summary>
        [DataMember(Name = "creationTime")]
        public DateTime CreationTime { get; set; }

        /// <summary>
        ///     The team expiry time
        /// </summary>
        [DataMember(Name = "expiryTime")]
        public DateTime ExpiryTime { get; set; }

        /// <summary>
        ///     The team cost modifier
        /// </summary>
        [DataMember(Name = "costModifier")]
        public float CostModifier { get; set; }

        /// <summary>
        ///     A list of the team workers
        /// </summary>
        [DataMember(Name = "workers")]
        public IList<CrestIndustryTeamWorker> Workers { get; set; }

        /// <summary>
        ///     The team name
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        ///     The team ID
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        ///     Activity
        /// </summary>
        [DataMember(Name = "activity")]
        public int Activity { get; set; }
    }
}