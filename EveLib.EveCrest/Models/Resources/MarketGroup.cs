using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Links;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    [DataContract]
    public sealed class MarketGroup : LinkedResource<MarketGroup> {
        public MarketGroup() {
            Version = "application/vnd.ccp.eve.MarketGroup-v1+json";
        }

        [DataMember(Name = "name")]
        public string Blueprints { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "types")]
        public Href<MarketTypeCollection> Types { get; set; }
    }
}