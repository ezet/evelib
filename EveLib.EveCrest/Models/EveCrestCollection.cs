using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models {

    [DataContract]
    public abstract class EveCrestCollection {

        [DataMember(Name = "totalCount")]
        public int TotalCount { get; set; }

        [DataMember(Name = "pageCount")]
        public int PageCount { get; set; }

        [DataMember(Name = "totalCount_str")]
        public string TotalCountAsString { get; set; }

        [DataMember(Name = "pageCount_str")]
        public string PageCounAsString { get; set; }

    }
}
