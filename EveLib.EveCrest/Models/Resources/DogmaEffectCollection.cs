// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : larsd
// Created          : 02-14-2016
//
// Last Modified By : larsd
// Last Modified On : 02-14-2016
// ***********************************************************************
// <copyright file="DogmaEffectCollection.cs" company="Lars Kristian Dahl">
//     Copyright ©  2015
// </copyright>
// <summary></summary>
// ***********************************************************************
using eZet.EveLib.EveCrestModule.Models.Links;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    /// <summary>
    /// Class DogmaEffectCollection. This class cannot be inherited.
    /// </summary>
    public sealed class DogmaEffectCollection : CollectionResource<DogmaEffectCollection, LinkedEntity<DogmaEffect>> {

        /// <summary>
        /// Initializes a new instance of the <see cref="DogmaEffectCollection" /> class.
        /// </summary>
        public DogmaEffectCollection() {
            ContentType = "application/vnd.ccp.eve.DogmaEffectCollection-v1+json";
        }
    }
}