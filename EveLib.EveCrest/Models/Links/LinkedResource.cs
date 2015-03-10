// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Lars Kristian
// Created          : 12-16-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 12-17-2014
// ***********************************************************************
// <copyright file="LinkedResource.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Linq;
using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Resources;

namespace eZet.EveLib.EveCrestModule.Models.Links {
    /// <summary>
    ///     Class LinkedResource.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [DataContract]
    public class LinkedResource<T> : CrestResource<T>, ILinkedEntity<T> where T : class, ICrestResource<T> {
        /// <summary>
        ///     The entity href
        /// </summary>
        /// <value>The href.</value>
        [DataMember(Name = "href")]
        public Href<T> Href { get; set; }

        private int _inferredId;

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the inferred identifier.
        /// </summary>
        /// <value>The inferred identifier.</value>
        public int InferredId {
            get {
                if (_inferredId == 0)
                    _inferredId = inferId();
                return _inferredId;
            }
            set { _inferredId = value; }
        }


        private int inferId() {
            int id;
            string[] href = Href.Uri.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            int.TryParse(href.Last(), out id);
            //id = -1;
            return id;
        }
    }
}