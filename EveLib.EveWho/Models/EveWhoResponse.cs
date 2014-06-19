using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models {
    [DataContract]
    public class EveWhoResponse<T> {
        [DataMember(Name = "info")]
        public T Info { get; set; }
    }
}