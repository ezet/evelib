using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models {
    [DataContract]
    public class CrestEntity {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "href")]
        public string Href { get; set; }
    }
}