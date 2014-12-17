using System.Runtime.Serialization;
using eZet.EveLib.Modules.Models.Resources;

namespace eZet.EveLib.Modules.Models.Entities {
    [DataContract]
    public class CrestImageLink {
        [DataMember(Name = "32x32")]
        public CrestHref<CrestPlaceholderModel> X32 { get; set; }

        [DataMember(Name = "64x64")]
        public CrestHref<CrestPlaceholderModel> X64 { get; set; }

        [DataMember(Name = "128x128")]
        public CrestHref<CrestPlaceholderModel> X128 { get; set; }

        [DataMember(Name = "256x256")]
        public CrestHref<CrestPlaceholderModel> X256 { get; set; }
    }
}