using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models.Entities {
    [DataContract]
    public class CrestLinkedIconEntity<T> : CrestLinkedEntity<T> {
        [DataMember(Name = "icon")]
        public CrestImageLink Icon { get; set; }
    }
}