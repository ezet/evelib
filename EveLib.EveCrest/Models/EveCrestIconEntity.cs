using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models {
    [DataContract]
    public class EveCrestIconEntity : EveCrestNamedEntity {
        [DataMember(Name = "icon")]
        public EveCrestHref<string> Icon { get; set; }
    }
}