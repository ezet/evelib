using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models {
    [DataContract]
    public class EveCrestNamedEntity : EveCrestEntity {
        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}