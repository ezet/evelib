using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models {
    /// <summary>
    ///     Represents a CREST /alliances/ response
    /// </summary>
    [DataContract]
    public sealed class CrestAllianceCollection : CrestCollectionResource<CrestAllianceCollection> {
        public CrestAllianceCollection() {
            Version = "application/vnd.ccp.eve.AllianceCollection-v1+json";
        }

        /// <summary>
        ///     A list of alliances
        /// </summary>
        [DataMember(Name = "items")]
        public List<Alliance> Alliances { get; set; }

        public class Alliance : CrestLinkedEntity<CrestAlliance> {
            [DataMember(Name = "shortName")]
            public string ShortName { get; set; }
        }
    }
}