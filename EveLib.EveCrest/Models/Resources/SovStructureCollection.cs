// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : larsd
// Created          : 10-03-2015
//
// Last Modified By : larsd
// Last Modified On : 10-03-2015
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
    /// Class SovStructureCollection.
    /// </summary>
    [DataContract]
    public sealed class SovStructureCollection : CollectionResource<SovStructureCollection, SovStructureCollection.Structure> {
        [DataContract]
        public class Structure {

            [DataMember(Name = "alliance")]
            public LinkedEntity<Alliance> Alliance { get; set; }

            [DataMember(Name = "vulnerabilityOccupancyLevel")]
            public float VulnerabilityOccupancyLevel { get; set; }

            [DataMember(Name = "structureID")]
            public long StructureId { get; set; }

            [DataMember(Name = "vulnerableStartTime")]
            public DateTime VulnerableStartTime { get; set; }

            [DataMember(Name = "vulnerableEndTime")]
            public DateTime VulnerableEndTime { get; set; }

            [DataMember(Name = "type")]
            public LinkedEntity<ItemType> Type { get; set; }

            [DataMember(Name = "solarSystem")]
            public LinkedEntity<SolarSystem> SolarSystem { get; set; }
        }

        public SovStructureCollection() {
            ContentType = "application/vnd.ccp.eve.SovStructureCollection-v1+json; charset=utf-8";
        }

    }
}
