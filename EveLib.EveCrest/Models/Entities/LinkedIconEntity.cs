using System.Runtime.Serialization;

namespace eZet.EveLib.EveCrestModule.Models.Entities {
    [DataContract]
    public class LinkedIconEntity<T> : LinkedEntity<T> {
        [DataMember(Name = "icon")]
        public ImageLink Icon { get; set; }
    }
}