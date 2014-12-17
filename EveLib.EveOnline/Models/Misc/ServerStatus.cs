// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="ServerStatus.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Xml.Serialization;

namespace eZet.EveLib.EveOnlineModule.Models.Misc {
    /// <summary>
    ///     Class ServerStatus.
    /// </summary>
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class ServerStatus {
        /// <summary>
        ///     Gets or sets the server open.
        /// </summary>
        /// <value>The server open.</value>
        [XmlElement("serverOpen")]
        public string ServerOpen { get; set; }

        /// <summary>
        ///     Gets or sets the players online.
        /// </summary>
        /// <value>The players online.</value>
        [XmlElement("onlinePlayers")]
        public int PlayersOnline { get; set; }
    }
}