using System.Runtime.Serialization;
using eZet.EveLib.Modules.Models.Entities;
using eZet.EveLib.Modules.Models.Resources;

namespace eZet.EveLib.Modules.Models.Shared {
    [DataContract]
    public class CharacterEntry : CrestLinkedEntity<CrestPlaceholderModel> {
        [DataMember(Name = "isNPC")]
        public bool IsNpc { get; set; }

        [DataMember(Name = "capsuleer")]
        public CrestLinkedEntity<CrestPlaceholderModel> Capsuleer { get; set; }

        [DataMember(Name = "portrait")]
        public CrestImageLink Portraits { get; set; }
    }
}
