using System.Runtime.Serialization;
using eZet.EveLib.Modules.Models.Entities;
using eZet.EveLib.Modules.Models.Resources;

namespace eZet.EveLib.Modules.Models.Shared {
    [DataContract]
    public class CorporationEntry : CrestLinkedEntity<CrestNotImplemented> {
        [DataMember(Name = "isNPC")]
        public bool IsNpc { get; set; }

        [DataMember(Name = "logo")]
        public CrestImageLink Logo { get; set; }
    }
}
