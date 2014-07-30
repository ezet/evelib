using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models {

    /// <summary>
    /// Represents a simple CREST entity with an ID
    /// </summary>
    [DataContract]
    public class CrestEntity {
        /// <summary>
        /// The ID
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }
    }
}
