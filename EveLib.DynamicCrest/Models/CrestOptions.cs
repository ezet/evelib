// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : larsd
// Created          : 03-16-2016
//
// Last Modified By : larsd
// Last Modified On : 03-16-2016
// ***********************************************************************
// <copyright file="CrestOptions.cs" company="Lars Kristian Dahl">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eZet.EveLib.DynamicCrest.Models {
    /// <summary>
    ///     Class CrestOptions. This class cannot be inherited.
    /// </summary>
    [DataContract]
    public sealed class CrestOptions  {
        /// <summary>
        ///     Enum HttpVerb
        /// </summary>
        public enum HttpVerb {
            /// <summary>
            ///     The get
            /// </summary>
            [EnumMember(Value = "GET")] Get,

            /// <summary>
            ///     The options
            /// </summary>
            [EnumMember(Value = "OPTIONS")] Options,

            /// <summary>
            ///     The head
            /// </summary>
            [EnumMember(Value = "HEAD")] Head,

            /// <summary>
            ///     The post
            /// </summary>
            [EnumMember(Value = "POST")] Post,

            /// <summary>
            ///     The put
            /// </summary>
            [EnumMember(Value = "PUT")] Put,

            /// <summary>
            ///     The delete
            /// </summary>
            [EnumMember(Value = "DELETE")] Delete
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="CrestOptions" /> class.
        /// </summary>
        public CrestOptions() {
        }

        /// <summary>
        ///     Gets or sets the representations.
        /// </summary>
        /// <value>The representations.</value>
        [DataMember(Name = "representations")]
        public IReadOnlyCollection<CrestRepresentations> Representations { get; set; }


        /// <summary>
        ///     Class CrestRepresentations.
        /// </summary>
        [DataContract]
        public class CrestRepresentations {
            /// <summary>
            ///     Gets or sets the type of the accept.
            /// </summary>
            /// <value>The type of the accept.</value>
            [DataMember(Name = "acceptType")]
            public Jsonstructure AcceptType { get; set; }

            /// <summary>
            ///     Gets or sets the verb.
            /// </summary>
            /// <value>The verb.</value>
            [DataMember(Name = "verb")]
            public HttpVerb Verb { get; set; }

            /// <summary>
            ///     Gets or sets the version.
            /// </summary>
            /// <value>The version.</value>
            [DataMember(Name = "version")]
            public int Version { get; set; }
        }

        /// <summary>
        ///     Class Jsonstructure.
        /// </summary>
        [DataContract]
        public class Jsonstructure {
            /// <summary>
            ///     Gets or sets the json dump of structure.
            /// </summary>
            /// <value>The json dump of structure.</value>
            [DataMember(Name = "jsonDumpOfStructure")]
            public string jsonDumpOfStructure { get; set; }

            /// <summary>
            ///     Gets or sets the name.
            /// </summary>
            /// <value>The name.</value>
            [DataMember(Name = "name")]
            public string Name { get; set; }
        }
    }
}