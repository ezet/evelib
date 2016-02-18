using System.Runtime.Serialization;

namespace eZet.EveLib.EveCrestModule.Models {

    [DataContract]
    public class CrestWriteable : ICrestWriteable {
        public void Delete() {
            throw new System.NotImplementedException();
        }

        public void Update() {
            throw new System.NotImplementedException();
        }

        [DataMember(Name = "href")]
        public string Href { get; set; }

        public bool ShouldSerializeHref() => false;
    }

}
