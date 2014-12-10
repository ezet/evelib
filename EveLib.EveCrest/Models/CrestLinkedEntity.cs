using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models {
    /// <summary>
    ///     Represents a basic CREST entity
    /// </summary>
    [DataContract]
    public class CrestLinkedEntity : CrestEntity {

        /// <summary>
        ///     The entity href
        /// </summary>
        [DataMember(Name = "href")]
        public string Href { get; set; }
    }
}