using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models {
    [DataContract]
    public class KillmailCollection : EveCrestCollection {
        [DataMember(Name = "items")]
        public IList<EveCrestEntity> Killmails { get; set; }
    }
}