using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models {

    /// <summary>
    /// Represents a CREST collection of wars
    /// </summary>
    [DataContract]
    public class CrestWars : CrestCollectionResponse {

        /// <summary>
        /// A list of wars
        /// </summary>
        [DataMember(Name = "items")]
        public IList<War> Wars { get; set; }

        /// <summary>
        /// Represents a war in a war collection
        /// </summary>
        public class War {
            /// <summary>
            /// The ID
            /// </summary>
            [DataMember(Name = "id")]
            public int Id { get; set; }

            /// <summary>
            /// The href
            /// </summary>
            [DataMember(Name = "href")]
            public string Href { get; set; }
        }
    }
}