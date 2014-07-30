using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models {
    
    /// <summary>
    /// Represents a basic CREST entity
    /// </summary>
    [DataContract]
    public class CrestLinkedEntity {
        /// <summary>
        /// The entity name
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// The entity href
        /// </summary>
        [DataMember(Name = "href")]
        public string Href { get; set; }
    }
}