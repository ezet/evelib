// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : larsd
// Created          : 02-13-2016
//
// Last Modified By : larsd
// Last Modified On : 02-13-2016
// ***********************************************************************
// <copyright file="SystemCollection.cs" company="Lars Kristian Dahl">
//     Copyright ©  2015
// </copyright>
// <summary></summary>
// ***********************************************************************


using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Links;

namespace eZet.EveLib.EveCrestModule.Models.Resources {

    /// <summary>
    /// Class SystemCollection. This class cannot be inherited.
    /// </summary>
    [DataContract]
    public sealed class SystemCollection : CollectionResource<SystemCollection, LinkedEntity<SolarSystem>> {


        /// <summary>
        /// Initializes a new instance of the <see cref="SystemCollection"/> class.
        /// </summary>
        public SystemCollection() {
            ContentType = "application/vnd.ccp.eve.SystemCollection-v1+json";
        }
    }
}