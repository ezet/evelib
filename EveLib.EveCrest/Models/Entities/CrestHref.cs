using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models.Entities {
    /// <summary>
    ///     Represents a CREST href object
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [DataContract]
    public class CrestHref<T> {

        public CrestHref() {
            
        }

        public CrestHref(string href) {
            Uri = href;
        }

        public static implicit operator CrestHref<T>(string s) {
            return new CrestHref<T>(s);
        }


            /// <summary>
        ///     The href object
        /// </summary>
        [DataMember(Name = "href")]
        public string Uri { get; set; }

        public T Type { get; set; }

        /// <summary>
        ///     Returns the href as a string
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            return Type.ToString();
        }
    }
}