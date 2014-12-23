// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="NotificationTexts.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Xml.Serialization;

namespace eZet.EveLib.EveXmlModule.Models.Character {
    /// <summary>
    ///     Class NotificationTexts.
    /// </summary>
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class NotificationTexts {
        /// <summary>
        ///     Gets or sets the notifications.
        /// </summary>
        /// <value>The notifications.</value>
        [XmlElement("rowset")]
        public EveXmlRowCollection<Notification> Notifications { get; set; }

        /// <summary>
        ///     Gets or sets the missing ids.
        /// </summary>
        /// <value>The missing ids.</value>
        [XmlElement("MissingIDs")]
        public string MissingIds { get; set; }


        /// <summary>
        ///     Class Notification.
        /// </summary>
        [Serializable]
        [XmlRoot("row")]
        public class Notification {
            /// <summary>
            ///     Gets or sets the notification identifier.
            /// </summary>
            /// <value>The notification identifier.</value>
            [XmlAttribute("notificationID")]
            public long NotificationId { get; set; }

            /// <summary>
            ///     Gets or sets the content.
            /// </summary>
            /// <value>The content.</value>
            [XmlText]
            public string Content { get; set; }
        }
    }
}