using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models {
    [DataContract]
    public class CrestLinkedEntity<T> : ICrestLinkedEntity<T> {

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        ///     The entity href
        /// </summary>
        [DataMember(Name = "href")]
        public CrestHref<T> Href { get; set; }
    }
}