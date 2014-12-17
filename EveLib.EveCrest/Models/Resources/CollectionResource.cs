using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Links;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    /// <summary>
    ///     Represents a CREST collection response
    /// </summary>
    [DataContract]
    public abstract class CollectionResource<T> : CrestResource<T> where T : class, ICrestResource<T> {
        /// <summary>
        ///     The total number of items in the collection
        /// </summary>
        [DataMember(Name = "totalCount")]
        public int TotalCount { get; set; }

        /// <summary>
        ///     The number of pages in the collection
        /// </summary>
        [DataMember(Name = "pageCount")]
        public int PageCount { get; set; }

        [DataMember(Name = "next")]
        public Href<T> Next { get; set; }

        [DataMember(Name = "previous")]
        public Href<T> Previous { get; set; }

    }
}