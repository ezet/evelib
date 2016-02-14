// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : larsd
// Created          : 02-13-2016
//
// Last Modified By : larsd
// Last Modified On : 02-13-2016
// ***********************************************************************
// <copyright file="ConstellationCollection.cs" company="Lars Kristian Dahl">
//     Copyright ©  2015
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Links;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    /// <summary>
    ///     Class ConstellationCollection.
    /// </summary>
    [DataContract]
    public sealed class ConstellationCollection :
        CollectionResource<ConstellationCollection, LinkedEntity<Constellation>> {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ConstellationCollection" /> class.
        /// </summary>
        public ConstellationCollection() {
            ContentType = "application/vnd.ccp.eve.ConstellationCollection-v1+json";
        }
    }
}