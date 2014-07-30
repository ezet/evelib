using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models {
    /// <summary>
    /// Represents a CREST href object
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [DataContract]
    public class CrestHref<T> {

        /// <summary>
        /// The href object
        /// </summary>
        [DataMember(Name = "href")]
        public T Value { get; set; }

        /// <summary>
        /// Returns the href as a string
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            return Value.ToString();
        }
    }
}