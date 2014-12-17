using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Resources;

namespace eZet.EveLib.EveCrestModule.Models.Links {
    [DataContract]
    public class ImageLink {
        [DataMember(Name = "32x32")]
        public Href<NotImplemented> X32 { get; set; }

        [DataMember(Name = "64x64")]
        public Href<NotImplemented> X64 { get; set; }

        [DataMember(Name = "128x128")]
        public Href<NotImplemented> X128 { get; set; }

        [DataMember(Name = "256x256")]
        public Href<NotImplemented> X256 { get; set; }
    }
}