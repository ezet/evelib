using System.Runtime.Serialization;

namespace eZet.EveLib.ZKillboardModule {

    [DataContract]
    public class ZkbStatResponse {


        [DataMember(Name = "allTimeSum")]
        public int AllTimeSum { get; set; }

    }
}