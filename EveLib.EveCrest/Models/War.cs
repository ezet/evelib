using System;
using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models {
    [DataContract]
    public class War {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "timeFinished")]
        public DateTime TimeFinished { get; set; }

        [DataMember(Name = "openForAllies")]
        public bool OpenForAllies { get; set; }

        [DataMember(Name = "timeStarted")]
        public DateTime TimeStarted { get; set; }

        [DataMember(Name = "allyCount")]
        public int AllyCount { get; set; }

        [DataMember(Name = "timeDeclared")]
        public DateTime TimeDeclared { get; set; }

        [DataMember(Name = "mutual")]
        public bool Mutual { get; set; }

        [DataMember(Name = "defender")]
        public WarEntity Defender { get; set; }

        [DataMember(Name = "aggressor")]
        public WarEntity Aggressor { get; set; }

        public class WarEntity : EveCrestIconEntity {
            [DataMember(Name = "shipsKilled")]
            public int ShipsKilled { get; set; }

            [DataMember(Name = "iskKilled")]
            public decimal IskKilled { get; set; }
        }
    }
}