using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models {
    
    [DataContract]
    public class EveCrestHref<T> {

        [DataMember(Name = "href")]
        public T Value { get; set; }

        public override string ToString() {
            return Value.ToString();
        }
    }
}
