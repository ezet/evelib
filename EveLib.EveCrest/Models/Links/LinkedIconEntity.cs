// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Lars Kristian
// Created          : 12-16-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 12-17-2014
// ***********************************************************************
// <copyright file="LinkedIconEntity.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Runtime.Serialization;

namespace eZet.EveLib.EveCrestModule.Models.Links {
    /// <summary>
    /// Class LinkedIconEntity.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [DataContract]
    public class LinkedIconEntity<T> : LinkedEntity<T> {
        /// <summary>
        /// Gets or sets the icon.
        /// </summary>
        /// <value>The icon.</value>
        [DataMember(Name = "icon")]
        public ImageLink Icon { get; set; }
    }
}