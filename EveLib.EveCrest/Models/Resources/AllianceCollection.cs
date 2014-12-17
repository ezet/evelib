using System.Collections.Generic;
using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Entities;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    /// <summary>
    ///     Represents a CREST /alliances/ response
    /// </summary>
    [DataContract]
    public sealed class AllianceCollection : CollectionResource<AllianceCollection> {
        public AllianceCollection() {
            Version = "application/vnd.ccp.eve.AllianceCollection-v1+json";
        }

        /// <summary>
        ///     A list of alliances
        /// </summary>
        [DataMember(Name = "items")]
        public List<Alliance> Alliances { get; set; }

        public class Alliance : LinkedEntity<Resources.Alliance> {
            [DataMember(Name = "shortName")]
            public string ShortName { get; set; }
        }
    }
}