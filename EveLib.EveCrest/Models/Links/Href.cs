// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Lars Kristian
// Created          : 12-16-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 03-03-2016
// ***********************************************************************
// <copyright file="Href.cs" company="Lars Kristian Dahl">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Linq;
using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.JsonConverters;
using Newtonsoft.Json;

namespace eZet.EveLib.EveCrestModule.Models.Links {
    /// <summary>
    ///     Represents a CREST href object
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [DataContract]
    [JsonConverter(typeof (HrefConverter))]
    public class Href<T> : IInferrableId {
        /// <summary>
        ///     The _inferred identifier
        /// </summary>
        private int _inferredId = -1;

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
        ///     Gets or sets the inferred identifier.
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
        ///     Performs an implicit conversion from <see cref="System.String" /> to <see cref="Href{T}" />.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator Href<T>(string s) {
            return new Href<T>(s);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="LinkedEntity{T}"/> to <see cref="Href{T}"/>.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator Href<T>(LinkedEntity<T> s) {
            return s.Href;
        }

        /// <summary>
        ///     Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString() {
            return Uri;
        }

        /// <summary>
        ///     Infers the identifier.
        /// </summary>
        /// <returns>System.Int32.</returns>
        private int inferId() {
            int id;
            var href = Uri.Split(new[] {'/'}, StringSplitOptions.RemoveEmptyEntries);
            int.TryParse(href.Last(), out id);
            return id;
        }
    }
}