using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Links;
using eZet.EveLib.EveCrestModule.Models.Resources;

namespace eZet.EveLib.EveCrestModule.Models.Shared {
    [DataContract]
    public class CorporationEntry : LinkedEntity<NotImplemented> {
        [DataMember(Name = "isNPC")]
        public bool IsNpc { get; set; }

        [DataMember(Name = "logo")]
        public ImageLink Logo { get; set; }
    }
}