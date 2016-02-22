// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : larsd
// Created          : 10-03-2015
//
// Last Modified By : larsd
// Last Modified On : 02-14-2016
// ***********************************************************************
// <copyright file="SovStructureCollection.cs" company="Lars Kristian Dahl">
//     Copyright ©  2015
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Links;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    /// <summary>
    ///     Class SovStructureCollection.
    /// </summary>
    [DataContract]
    public sealed class SovStructureCollection :
        CollectionResource<SovStructureCollection, SovStructureCollection.Structure> {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SovStructureCollection" /> class.
        /// </summary>
        public SovStructureCollection() {
            ContentType = "application/vnd.ccp.eve.SovStructureCollection-v1+json; charset=utf-8";
        }

        /// <summary>
        ///     Class Structure.
        /// </summary>
        [DataContract]
        public class Structure {
            /// <summary>
            ///     Gets or sets the alliance.
            /// </summary>
            /// <value>The alliance.</value>
            [DataMember(Name = "alliance")]
            public LinkedEntity<Alliance> Alliance { get; set; }

            /// <summary>
            ///     Gets or sets the vulnerability occupancy level.
            /// </summary>
            /// <value>The vulnerability occupancy level.</value>
            [DataMember(Name = "vulnerabilityOccupancyLevel")]
            public float VulnerabilityOccupancyLevel { get; set; }

            /// <summary>
            ///     Gets or sets the structure identifier.
            /// </summary>
            /// <value>The structure identifier.</value>
            [DataMember(Name = "structureID")]
            public long StructureId { get; set; }

            /// <summary>
            ///     Gets or sets the vulnerable start time.
            /// </summary>
            /// <value>The vulnerable start time.</value>
            [DataMember(Name = "vulnerableStartTime")]
            public DateTime VulnerableStartTime { get; set; }

            /// <summary>
            ///     Gets or sets the vulnerable end time.
            /// </summary>
            /// <value>The vulnerable end time.</value>
            [DataMember(Name = "vulnerableEndTime")]
            public DateTime VulnerableEndTime { get; set; }

            /// <summary>
            ///     Gets or sets the type.
            /// </summary>
            /// <value>The type.</value>
            [DataMember(Name = "type")]
            public LinkedEntity<ItemType> Type { get; set; }

            /// <summary>
            ///     Gets or sets the solar system.
            /// </summary>
            /// <value>The solar system.</value>
            [DataMember(Name = "solarSystem")]
            public LinkedEntity<SolarSystem> SolarSystem { get; set; }
        }
    }
}