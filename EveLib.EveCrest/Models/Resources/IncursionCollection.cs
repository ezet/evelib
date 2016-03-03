// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Lars Kristian
// Created          : 12-16-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 12-17-2014
// ***********************************************************************
// <copyright file="IncursionCollection.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Links;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    /// <summary>
    ///     Represents a CREST /incursions/ response
    /// </summary>
    [DataContract]
    public sealed class IncursionCollection : CollectionResource<IncursionCollection, IncursionCollection.Incursion> {
        /// <summary>
        ///     Represens the incursion states
        /// </summary>
        [JsonConverter(typeof (StringEnumConverter))]
        public enum IncursionState {
            /// <summary>
            ///     Established incursion
            /// </summary>
            [EnumMember(Value = "Established")] Established,

            /// <summary>
            ///     Mobilizing incursion
            /// </summary>
            [EnumMember(Value = "Mobilizing")] Mobilizing,

            /// <summary>
            ///     Withdrawing incursion
            /// </summary>
            [EnumMember(Value = "Withdrawing")] Withdrawing
        }

        /// <summary>
        ///     Enum Type
        /// </summary>
        [JsonConverter(typeof (StringEnumConverter))]
        public enum Type {
            /// <summary>
            ///     The incursion
            /// </summary>
            [EnumMember(Value = "Incursion")] Incursion,

            /// <summary>
            ///     The spreading incursion
            /// </summary>
            [EnumMember(Value = "Spreading Incursion")] SpreadingIncursion
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="IncursionCollection" /> class.
        /// </summary>
        public IncursionCollection() {
            ContentType = "application/vnd.ccp.eve.IncursionCollection-v1+json";
        }


        /// <summary>
        ///     Class Incursion.
        /// </summary>
        [DataContract]
        public class Incursion {
            /// <summary>
            ///     Gets or sets the aggression faction.
            /// </summary>
            /// <value>The aggression faction.</value>
            [DataMember(Name = "aggressorFactionID")]
            public LinkedEntity<Alliance> AggressorFaction { get; set; }

            /// <summary>
            ///     Gets or sets the type of the incursion.
            /// </summary>
            /// <value>The type of the incursion.</value>
            [DataMember(Name = "incursionType")]
            public Type IncursionType { get; set; }

            /// <summary>
            ///     Gets or sets the infested solar systems.
            /// </summary>
            /// <value>The infested solar systems.</value>
            [DataMember(Name = "infestedSolarSystems")]
            public IReadOnlyCollection<LinkedEntity<SolarSystem>> InfestedSolarSystems { get; set; }

            /// <summary>
            ///     The incursion influence
            /// </summary>
            /// <value>The influence.</value>
            [DataMember(Name = "influence")]
            public double Influence { get; set; }

            /// <summary>
            ///     True if the incursion has a boss
            /// </summary>
            /// <value><c>true</c> if this instance has boss; otherwise, <c>false</c>.</value>
            [DataMember(Name = "hasBoss")]
            public bool HasBoss { get; set; }

            /// <summary>
            ///     The incursion state
            /// </summary>
            /// <value>The state.</value>
            [DataMember(Name = "state")]
            public IncursionState State { get; set; }

            /// <summary>
            ///     The incursion's staging system
            /// </summary>
            /// <value>The staging solar system.</value>
            [DataMember(Name = "stagingSolarSystem")]
            public LinkedEntity<SolarSystem> StagingSolarSystem { get; set; }

            /// <summary>
            ///     The constellation
            /// </summary>
            /// <value>The constellation.</value>
            [DataMember(Name = "constellation")]
            public LinkedEntity<Constellation> Constellation { get; set; }
        }
    }
}