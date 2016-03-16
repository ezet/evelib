// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Lars Kristian
// Created          : 12-16-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 03-03-2016
// ***********************************************************************
// <copyright file="LinkedEntity.cs" company="Lars Kristian Dahl">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Linq;
using System.Runtime.Serialization;

namespace eZet.EveLib.EveCrestModule.Models.Links {
    /// <summary>
    ///     Class LinkedEntity. A base class for linked resources that has a name and ID.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [DataContract]
    public class LinkedEntity<T> : ILinkedEntity<T> {
        /// <summary>
        ///     The _id
        /// </summary>
        private int _id = -1;

        /// <summary>
        ///     The _inferred identifier
        /// </summary>
        private int _inferredId = -1;

        /// <summary>
        ///     Initializes a new instance of the <see cref="LinkedEntity{T}" /> class.
        /// </summary>
        public LinkedEntity() {
            Name = "";
            SetSerializeName = true;
        }

        /// <summary>
        ///     Gets or sets a value indicating whether [set serialize name].
        /// </summary>
        /// <value><c>true</c> if [set serialize name]; otherwise, <c>false</c>.</value>
        public bool SetSerializeName { private get; set; }

        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [DataMember(Name = "id")]
        public int Id {
            get { return _id >= 0 ? _id : InferredId; }
            set { _id = value; }
        }

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
        ///     Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        ///     The entity href
        /// </summary>
        /// <value>The href.</value>
        [DataMember(Name = "href")]
        public Href<T> Href { get; set; }

        /// <summary>
        ///     Shoulds the name of the serialize.
        /// </summary>
        /// <returns>System.Boolean.</returns>
        public bool ShouldSerializeName() => SetSerializeName;

        private int inferId() {
            int id;
            var href = Href.Uri.Split(new[] {'/'}, StringSplitOptions.RemoveEmptyEntries);
            int.TryParse(href.Last(), out id);
            return id;
        }
    }
}