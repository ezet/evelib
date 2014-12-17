using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Resources;

namespace eZet.EveLib.EveCrestModule.Models.Links {
    [DataContract]
    public class LinkedResource<T> :  CrestResource<T>, ILinkedEntity<T> where T : class, ICrestResource<T> {
        /// <summary>
        ///     The entity href
        /// </summary>
        [DataMember(Name = "href")]
        public Href<T> Href { get; set; }

    }
}