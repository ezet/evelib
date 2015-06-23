// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Lars Kristian
// Created          : 12-16-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 12-17-2014
// ***********************************************************************
// <copyright file="Href.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Runtime.Serialization;
using System;
using System.Linq;

namespace eZet.EveLib.EveCrestModule.Models.Links {
    /// <summary>
    ///     Represents a CREST href object
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [DataContract]
    public class Href<T> : IInferrableId {

        private int _inferredId = -1;

        /// <summary>
        /// Gets or sets the inferred identifier.
        /// </summary>
        /// <value>The inferred identifier.</value>
        public int InferredId {
            get {
                if (_inferredId < 0)
                    _inferredId = inferId();
                return _inferredId;
            }
            set { _inferredId = value; }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Href{T}" /> class.
        /// </summary>
        /// <param name="href">The href.</param>
        public Href(string href) {
            Uri = href;
        }

        /// <summary>
        ///     Gets or sets the URI.
        /// </summary>
        /// <value>The URI.</value>
        [DataMember(Name = "href")]
        public string Uri { get; set; }

        /// <summary>
        ///     Performs an implicit conversion from <see cref="System.String" /> to <see cref="Href{T}" />.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator Href<T>(string s) {
            return new Href<T>(s);
        }

        /// <summary>
        ///     Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString() {
            return Uri;
        }

        private int inferId() {
            int id;
            string[] href = Uri.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            int.TryParse(href.Last(), out id);
            return id;
        }
    }
}