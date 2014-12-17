using System.Collections.Generic;
using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Entities;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    /// <summary>
    ///     Represents a CREST collection of wars
    /// </summary>
    [DataContract]
    public sealed class WarCollection : CollectionResource<War> {
        public WarCollection() {
            Version = "application/vnd.ccp.eve.WarsCollection-v1+json";
        }

        /// <summary>
        ///     A list of wars
        /// </summary>
        [DataMember(Name = "items")]
        public IReadOnlyList<LinkedEntity<War>> Items { get; set; }
    }
}