// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 03-31-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="EveApiEnums.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Xml.Serialization;

namespace eZet.EveLib.EveOnlineModule.Models {
    /// <summary>
    ///     Enum OrderType
    /// </summary>
    public enum OrderType {
        /// <summary>
        ///     The buy
        /// </summary>
        [XmlEnum("buy")] Buy,

        /// <summary>
        ///     The sell
        /// </summary>
        [XmlEnum("sell")] Sell
    }
}