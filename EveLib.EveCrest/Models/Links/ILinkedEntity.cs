// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Lars Kristian
// Created          : 12-16-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 12-17-2014
// ***********************************************************************
// <copyright file="ILinkedEntity.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace eZet.EveLib.EveCrestModule.Models.Links {
    /// <summary>
    /// Interface ILinkedEntity
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ILinkedEntity<T> {
        /// <summary>
        /// Gets or sets the href.
        /// </summary>
        /// <value>The href.</value>
        Href<T> Href { get; set; }
    }
}