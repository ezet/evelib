using System.Runtime.Serialization;
using eZet.EveLib.Modules.Models.Resources;

namespace eZet.EveLib.Modules.Models {
    [DataContract]
    public class CrestLinkedResource<T> : ICrestLinkedEntity<T>, ICrestResource {
        /// <summary>
        ///     The entity href
        /// </summary>
        [DataMember(Name = "href")]
        public CrestHref<T> Href { get; set; }

        public bool IsDeprecated { get; set; }

        public string Version { get; protected set; }
    }
}