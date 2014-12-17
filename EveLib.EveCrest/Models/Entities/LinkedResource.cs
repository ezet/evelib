using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Resources;

namespace eZet.EveLib.EveCrestModule.Models.Entities {
    [DataContract]
    public class LinkedResource<T> : ILinkedEntity<T>, ICrestResource {
        /// <summary>
        ///     The entity href
        /// </summary>
        [DataMember(Name = "href")]
        public Href<T> Href { get; set; }

        public bool IsDeprecated { get; set; }

        public string Version { get; protected set; }
    }
}