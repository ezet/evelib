using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models {
    /// <summary>
    /// Represents a CREST entity with a name
    /// </summary>
    [DataContract]
    public class CrestNamedEntity : CrestLinkedEntity {
        /// <summary>
        /// The name
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}