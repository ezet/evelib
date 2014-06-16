using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models {
    [DataContract]
    public class Killmail {

        [DataMember(Name = "solarSystem")]
        public EveCrestNamedEntity SolarSystem { get; set; }

        [DataMember(Name = "killID")]
        public long KillId { get; set; }

        [DataMember(Name = "killTime")]
        public DateTime KillTime { get; set; }

        [DataMember(Name = "attackers")]
        public IList<KillmailAttacker> Attackers { get; set; }

        [DataMember(Name = "attackerCount")]
        public int AttackerCount { get; set; }

        [DataMember(Name = "victim")]
        public KillmailVictim Victim { get; set; }

        [DataMember(Name = "war")]
        public EveCrestEntity War { get; set; }


        public class KillmailVictim {

            
        }

        public class KillmailAttacker {
            
        }
        
    }
}
