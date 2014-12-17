// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Lars Kristian
// Created          : 12-16-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 12-17-2014
// ***********************************************************************
// <copyright file="CrestPosition.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Runtime.Serialization;

namespace eZet.EveLib.EveCrestModule.Models.Shared {
    /// <summary>
    ///     Class CrestPosition.
    /// </summary>
    [DataContract]
    public class CrestPosition {
        /// <summary>
        ///     Gets or sets the x.
        /// </summary>
        /// <value>The x.</value>
        [DataMember(Name = "x")]
        public long X { get; set; }

        /// <summary>
        ///     Gets or sets the y.
        /// </summary>
        /// <value>The y.</value>
        [DataMember(Name = "y")]
        public long Y { get; set; }

        /// <summary>
        ///     Gets or sets the z.
        /// </summary>
        /// <value>The z.</value>
        [DataMember(Name = "z")]
        public long Z { get; set; }
    }
}