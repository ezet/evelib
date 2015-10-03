// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Lars Kristian
// Created          : 12-16-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 12-17-2014
// ***********************************************************************
// <copyright file="AllianceCollection.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Links;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    /// <summary>
    ///     Represents a CREST /alliances/ response
    /// </summary>
    [DataContract]
    // TODO Remove HrefWrapper, implement customized json parsing 
    public sealed class AllianceCollection : CollectionResource<AllianceCollection, AllianceCollection.HrefWrapper> {
        /// <summary>
        ///     Initializes a new instance of the <see cref="AllianceCollection" /> class.
        /// </summary>
        public AllianceCollection() {
            ContentType = "application/vnd.ccp.eve.AllianceCollection-v2+json";
        }

        /// <summary>
        ///     Class Alliance.
        /// </summary>
        [DataContract]
        public class Alliance : LinkedEntity<Resources.Alliance> {
            /// <summary>
            ///     Gets or sets the short name.
            /// </summary>
            /// <value>The short name.</value>
            [DataMember(Name = "shortName")]
            public string ShortName { get; set; }



        }

        /// <summary>
        /// Class HrefWrapper.
        /// </summary>
        [DataContract]
        public class HrefWrapper {

            /// <summary>
            /// Gets or sets the alliance.
            /// </summary>
            /// <value>The alliance.</value>
            [DataMember(Name = "href")]
            public Alliance Alliance { get; set; }
            
        }
    }
}