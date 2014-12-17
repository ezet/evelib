using System.Runtime.Serialization;

namespace eZet.EveLib.EveCrestModule.Models.Shared {
    [DataContract]
    public class CrestPosition {
        [DataMember(Name = "x")]
        public long X { get; set; }

        [DataMember(Name = "y")]
        public long Y { get; set; }

        [DataMember(Name = "z")]
        public long Z { get; set; }
    }
}