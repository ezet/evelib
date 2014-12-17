using System.Runtime.Serialization;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    [DataContract]
    public sealed class ItemType : CrestResource {
        public ItemType() {
            Version = "application/vnd.ccp.eve.ItemType-v3+json";
        }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }
    }
}