using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models {
    [Serializable]
    [DataContract]
    public class StaticDataCollection<T> {
        [DataMember(Name = "count")]
        public int Count { get; set; }

        [DataMember(Name = "next")]
        public string Next { get; set; }

        [DataMember(Name = "previous")]
        public string Previous { get; set; }

        [DataMember(Name = "results")]
        public List<T> Results { get; set; }
    }
}