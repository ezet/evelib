// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Lars Kristian
// Created          : 12-16-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 12-17-2014
// ***********************************************************************
// <copyright file="CollectionResource.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Links;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    /// <summary>
    /// Represents a CREST collection response
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [DataContract]
    public abstract class CollectionResource<T> : CrestResource<T> where T : class, ICrestResource<T> {
        /// <summary>
        /// The total number of items in the collection
        /// </summary>
        /// <value>The total count.</value>
        [DataMember(Name = "totalCount")]
        public int TotalCount { get; set; }

        /// <summary>
        /// The number of pages in the collection
        /// </summary>
        /// <value>The page count.</value>
        [DataMember(Name = "pageCount")]
        public int PageCount { get; set; }

        /// <summary>
        /// Gets or sets the next.
        /// </summary>
        /// <value>The next.</value>
        [DataMember(Name = "next")]
        public Href<T> Next { get; set; }

        /// <summary>
        /// Gets or sets the previous.
        /// </summary>
        /// <value>The previous.</value>
        [DataMember(Name = "previous")]
        public Href<T> Previous { get; set; }

    }
}