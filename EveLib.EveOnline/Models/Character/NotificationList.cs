// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="NotificationList.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Xml.Serialization;
using eZet.EveLib.Modules.Util;

namespace eZet.EveLib.Modules.Models.Character {
    /// <summary>
    /// Class NotificationList.
    /// </summary>
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class NotificationList {
        /// <summary>
        /// Gets or sets the notifications.
        /// </summary>
        /// <value>The notifications.</value>
        [XmlElement("rowset")]
        public EveOnlineRowCollection<Notification> Notifications { get; set; }

        /// <summary>
        /// Class Notification.
        /// </summary>
        [Serializable]
        [XmlRoot("row")]
        public class Notification {
            /// <summary>
            /// Gets or sets the notification identifier.
            /// </summary>
            /// <value>The notification identifier.</value>
            [XmlAttribute("notificationID")]
            public long NotificationId { get; set; }

            /// <summary>
            /// Gets or sets the type identifier.
            /// </summary>
            /// <value>The type identifier.</value>
            [XmlAttribute("typeID")]
            public int TypeId { get; set; }

            /// <summary>
            /// Gets or sets the sender identifier.
            /// </summary>
            /// <value>The sender identifier.</value>
            [XmlAttribute("senderID")]
            public long SenderId { get; set; }

            /// <summary>
            /// Gets or sets the name of the sender.
            /// </summary>
            /// <value>The name of the sender.</value>
            [XmlAttribute("senderName")]
            public string SenderName { get; set; }

            /// <summary>
            /// Gets the sent date.
            /// </summary>
            /// <value>The sent date.</value>
            [XmlIgnore]
            public DateTime SentDate { get; private set; }

            /// <summary>
            /// Gets or sets the sent date as string.
            /// </summary>
            /// <value>The sent date as string.</value>
            [XmlAttribute("sentDate")]
            public string SentDateAsString {
                get { return SentDate.ToString(XmlHelper.DateFormat); }
                set { SentDate = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
            }

            /// <summary>
            /// Gets or sets a value indicating whether this instance is read.
            /// </summary>
            /// <value><c>true</c> if this instance is read; otherwise, <c>false</c>.</value>
            [XmlAttribute("read")]
            public bool IsRead { get; set; }
        }
    }
}