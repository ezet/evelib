using System.Runtime.Serialization;

namespace eZet.EveLib.EveCrestModule.Models.Entities {
    /// <summary>
    ///     Represents a CREST href object
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [DataContract]
    public class Href<T> {
        public Href() {
        }

        public Href(string href) {
            Uri = href;
        }


        /// <summary>
        ///     The href object
        /// </summary>
        [DataMember(Name = "href")]
        public string Uri { get; set; }

        public T Type { get; set; }

        public static implicit operator Href<T>(string s) {
            return new Href<T>(s);
        }

        /// <summary>
        ///     Returns the href as a string
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            return Type.ToString();
        }
    }
}