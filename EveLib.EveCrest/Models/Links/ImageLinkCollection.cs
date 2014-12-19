// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Lars Kristian
// Created          : 12-16-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 12-17-2014
// ***********************************************************************
// <copyright file="ImageLinkCollection.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Runtime.Serialization;

namespace eZet.EveLib.EveCrestModule.Models.Links {
    /// <summary>
    ///     Class ImageLinkCollection.
    /// </summary>
    [DataContract]
    public class ImageLinkCollection {
        /// <summary>
        ///     Gets or sets the X32.
        /// </summary>
        /// <value>The X32.</value>
        [DataMember(Name = "32x32")]
        public ImageHref X32 { get; set; }

        /// <summary>
        ///     Gets or sets the X64.
        /// </summary>
        /// <value>The X64.</value>
        [DataMember(Name = "64x64")]
        public ImageHref X64 { get; set; }

        /// <summary>
        ///     Gets or sets the X128.
        /// </summary>
        /// <value>The X128.</value>
        [DataMember(Name = "128x128")]
        public ImageHref X128 { get; set; }

        /// <summary>
        ///     Gets or sets the X256.
        /// </summary>
        /// <value>The X256.</value>
        [DataMember(Name = "256x256")]
        public ImageHref X256 { get; set; }
    }
}