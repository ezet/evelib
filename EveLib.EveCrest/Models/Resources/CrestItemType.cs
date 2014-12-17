using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models.Resources {
    [DataContract]
    public sealed class CrestItemType : CrestResource {
        public CrestItemType() {
            Version = "application/vnd.ccp.eve.ItemType-v3+json";
        }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }
    }
}