using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models {
    [DataContract]
    public class EveCrestEntity {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "href")]
        public string Href { get; set; }
    }
}