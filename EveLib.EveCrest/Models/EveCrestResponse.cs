using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models {

    [DataContract]
    public abstract class EveCrestResponse {

        [DataMember(Name = "totalCount")]
        public int TotalCount { get; set; }

        [DataMember(Name = "pageCount")]
        public int PageCount { get; set; }

    }
}
