using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models {
    /// <summary>
    /// Represents a CREST /killmails/ response
    /// </summary>
    [DataContract]
    public class CrestKillmails : CrestCollectionResponse {
        /// <summary>
        /// A list of killmails
        /// </summary>
        [DataMember(Name = "items")]
        public IList<CrestLinkedEntity> Killmails { get; set; }
    }
}