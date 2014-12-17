// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Lars Kristian
// Created          : 12-16-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 12-17-2014
// ***********************************************************************
// <copyright file="IndustrySystemCollection.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Links;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    /// <summary>
    /// Represents the response for Industry Systems in CREST
    /// </summary>
    [DataContract]
    public sealed class IndustrySystemCollection : CollectionResource<IndustrySystemCollection> {
        /// <summary>
        /// Initializes a new instance of the <see cref="IndustrySystemCollection"/> class.
        /// </summary>
        public IndustrySystemCollection() {
            Version = "application/vnd.ccp.eve.IndustrySystemCollection-v1+json";
        }

        /// <summary>
        /// The solar system
        /// </summary>
        /// <value>The solar systems.</value>
        [DataMember(Name = "items")]
        public List<SolarSystemEntry> SolarSystems { get; set; }

        /// <summary>
        /// Represesents a solar system for a SystemCostEntry
        /// </summary>
        [DataContract]
        public class SolarSystemEntry {
            /// <summary>
            /// The solar system
            /// </summary>
            /// <value>The solar system.</value>
            [DataMember(Name = "solarSystem")]
            public LinkedEntity<SolarSystem> SolarSystem { get; set; }

            /// <summary>
            /// A list of system costs
            /// </summary>
            /// <value>The system cost indices.</value>
            [DataMember(Name = "systemCostIndices")]
            public List<SystemCostEntry> SystemCostIndices { get; set; }
        }

        /// <summary>
        /// Represents a system cost index in CREST Industry Systems collection
        /// </summary>
        [DataContract]
        public class SystemCostEntry {
            /// <summary>
            /// The cost index
            /// </summary>
            /// <value>The index of the cost.</value>
            [DataMember(Name = "costIndex")]
            public float CostIndex { get; set; }

            /// <summary>
            /// The activity ID
            /// </summary>
            /// <value>The activity identifier.</value>
            [DataMember(Name = "activityID")]
            public int ActivityId { get; set; }

            /// <summary>
            /// The activity name
            /// </summary>
            /// <value>The name of the activity.</value>
            [DataMember(Name = "activityName")]
            public string ActivityName { get; set; }
        }
    }
}