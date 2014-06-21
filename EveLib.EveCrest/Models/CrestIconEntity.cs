using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models {
    /// <summary>
    /// Represents a CREST entity with a name and icon
    /// </summary>
    [DataContract]
    public class CrestIconEntity : CrestNamedEntity {
        /// <summary>
        /// The icon href
        /// </summary>
        [DataMember(Name = "icon")]
        public CrestHref<string> Icon { get; set; }
    }
}