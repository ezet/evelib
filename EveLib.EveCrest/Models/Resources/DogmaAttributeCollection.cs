// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : larsd
// Created          : 02-14-2016
//
// Last Modified By : larsd
// Last Modified On : 02-14-2016
// ***********************************************************************
// <copyright file="DogmaAttributeCollection.cs" company="Lars Kristian Dahl">
//     Copyright ©  2015
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Links;

namespace eZet.EveLib.EveCrestModule.Models {
    /// <summary>
    ///     Class DogmaAttributeCollection. This class cannot be inherited.
    /// </summary>
    [DataContract]
    public sealed class DogmaAttributeCollection :
        CollectionResource<DogmaAttributeCollection, LinkedEntity<DogmaAttribute>> {
        /// <summary>
        ///     Initializes a new instance of the <see cref="DogmaAttributeCollection" /> class.
        /// </summary>
        public DogmaAttributeCollection() {
            ContentType = "application/vnd.ccp.eve.DogmaAttributeCollection-v1+json";
        }
    }
}