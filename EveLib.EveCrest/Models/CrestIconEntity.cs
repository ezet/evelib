using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models {
    [DataContract]
    public class CrestIconEntity : CrestNamedEntity {
        [DataMember(Name = "icon")]
        public CrestHref<string> Icon { get; set; }
    }
}