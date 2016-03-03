// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : larsd
// Created          : 03-03-2016
//
// Last Modified By : larsd
// Last Modified On : 03-03-2016
// ***********************************************************************
// <copyright file="IEditableCollectionResource.cs" company="Lars Kristian Dahl">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************

using eZet.EveLib.EveCrestModule.Models.Resources;

namespace eZet.EveLib.EveCrestModule.Models {
    /// <summary>
    ///     Interface IEditableCollectionResource
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TCollection">The type of the t collection.</typeparam>
    public interface IEditableCollectionResource<T, TCollection> : ICollectionResource<T, TCollection>
        where T : CollectionResource<T, TCollection> {
    }
}