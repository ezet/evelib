using System.Runtime.Serialization;
using eZet.EveLib.Modules.Models.Resources;

namespace eZet.EveLib.Modules.Models {
    /// <summary>
    ///     Represents a CREST collection response
    /// </summary>
    [DataContract]
    public abstract class CrestCollectionResource<T> : ICrestResource {
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
        public CrestHref<T> Next { get; set; }

        [DataMember(Name = "previous")]
        public CrestHref<T> Previous { get; set; }

        //[DataMember(Name="totalCount_str")]
        //public string TotalCountAsString { get; set; }

        //[DataMember(Name="pageCount_str")]
        //public string PageCounAsString { get; set; }
        public virtual bool IsDeprecated { get; set; }
        public virtual string Version { get; protected set; }
    }
}