using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models {
    [DataContract]
    public class CrestNamedEntity : CrestEntity {
        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}