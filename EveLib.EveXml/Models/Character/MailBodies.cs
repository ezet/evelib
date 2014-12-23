// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="MailBodies.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Xml.Serialization;

namespace eZet.EveLib.EveXmlModule.Models.Character {
    /// <summary>
    ///     Class MailBodies.
    /// </summary>
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class MailBodies {
        /// <summary>
        ///     Gets or sets the messages.
        /// </summary>
        /// <value>The messages.</value>
        [XmlElement("rowset")]
        public EveXmlRowCollection<Message> Messages { get; set; }

        /// <summary>
        ///     Gets or sets the missing message ids.
        /// </summary>
        /// <value>The missing message ids.</value>
        [XmlElement("missingMessageIDs")]
        public string MissingMessageIds { get; set; }

        /// <summary>
        ///     Class Message.
        /// </summary>
        [Serializable]
        [XmlRoot("row")]
        public class Message {
            /// <summary>
            ///     Gets or sets the message identifier.
            /// </summary>
            /// <value>The message identifier.</value>
            [XmlAttribute("messageID")]
            public long MessageId { get; set; }

            /// <summary>
            ///     Gets or sets the message data.
            /// </summary>
            /// <value>The message data.</value>
            [XmlText]
            public string MessageData { get; set; }
        }
    }
}