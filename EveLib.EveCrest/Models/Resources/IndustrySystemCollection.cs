using System.Collections.Generic;
using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Entities;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    /// <summary>
    ///     Represents the response for Industry Systems in CREST
    /// </summary>
    [DataContract]
    public sealed class IndustrySystemCollection : CollectionResource<IndustrySystemCollection> {
        public IndustrySystemCollection() {
            Version = "application/vnd.ccp.eve.IndustrySystemCollection-v1+json";
        }

        /// <summary>
        ///     The solar system
        /// </summary>
        [DataMember(Name = "items")]
        public List<SolarSystemEntry> SolarSystems { get; set; }

        /// <summary>
        ///     Represesents a solar system for a SystemCostEntry
        /// </summary>
        [DataContract]
        public class SolarSystemEntry {
            /// <summary>
            ///     The solar system
            /// </summary>
            [DataMember(Name = "solarSystem")]
            public LinkedEntity<SolarSystem> SolarSystem { get; set; }

            /// <summary>
            ///     A list of system costs
            /// </summary>
            [DataMember(Name = "systemCostIndices")]
            public List<SystemCostEntry> SystemCostIndices { get; set; }
        }

        /// <summary>
        ///     Represents a system cost index in CREST Industry Systems collection
        /// </summary>
        [DataContract]
        public class SystemCostEntry {
            /// <summary>
            ///     The cost index
            /// </summary>
            [DataMember(Name = "costIndex")]
            public float CostIndex { get; set; }

            /// <summary>
            ///     The activity ID
            /// </summary>
            [DataMember(Name = "activityID")]
            public int ActivityId { get; set; }

            /// <summary>
            ///     The activity name
            /// </summary>
            [DataMember(Name = "activityName")]
            public string ActivityName { get; set; }
        }
    }
}