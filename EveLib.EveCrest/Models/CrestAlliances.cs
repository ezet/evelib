using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models {
    /// <summary>
    /// Represents a CREST /alliances/ response
    /// </summary>
    [DataContract]
    public class CrestAlliances : CrestCollectionResponse {
        /// <summary>
        /// A list of alliances
        /// </summary>
        [DataMember(Name = "items")]
        public IList<CrestHref<CrestIconEntity>> Alliances { get; set; }
    }
}