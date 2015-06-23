// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Lars Kristian
// Created          : 12-16-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 12-17-2014
// ***********************************************************************
// <copyright file="LinkedEntity.cs" company="">
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
        private int _inferredId = -1;
        private int _id = -1;


        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [DataMember(Name = "id")]
        public int Id {
            get { return _id >= 0 ? _id : InferredId; }
            set { _id = value; }
        }

        /// <summary>
        /// Gets or sets the inferred identifier.
        /// </summary>
        /// <value>The inferred identifier.</value>
        public int InferredId {
            get {
                if (_inferredId < 0)
                    _inferredId = inferId();
                return _inferredId; }
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

        private int inferId() {
            int id;
            string[] href = Href.Uri.Split(new[] {'/'}, StringSplitOptions.RemoveEmptyEntries);
            int.TryParse(href.Last(), out id);
            return id;
        }
    }
}