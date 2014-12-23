// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="MailMessages.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Xml.Serialization;
using eZet.EveLib.EveXmlModule.Util;

namespace eZet.EveLib.EveXmlModule.Models.Character {
    /// <summary>
    ///     Class MailMessages.
    /// </summary>
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class MailMessages {
        /// <summary>
        ///     Gets or sets the messages.
        /// </summary>
        /// <value>The messages.</value>
        [XmlElement("rowset")]
        public EveXmlRowCollection<Message> Messages { get; set; }

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
            ///     Gets or sets the name of the sender.
            /// </summary>
            /// <value>The name of the sender.</value>
            [XmlAttribute("senderName")]
            public string SenderName { get; set; }

            /// <summary>
            ///     Gets or sets the sender identifier.
            /// </summary>
            /// <value>The sender identifier.</value>
            [XmlAttribute("senderID")]
            public long SenderId { get; set; }

            /// <summary>
            ///     Gets the sent date.
            /// </summary>
            /// <value>The sent date.</value>
            [XmlIgnore]
            public DateTime SentDate { get; private set; }

            /// <summary>
            ///     Gets or sets the sent date as string.
            /// </summary>
            /// <value>The sent date as string.</value>
            [XmlAttribute("sentDate")]
            public string SentDateAsString {
                get { return SentDate.ToString(XmlHelper.DateFormat); }
                set { SentDate = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
            }

            /// <summary>
            ///     Gets or sets the title.
            /// </summary>
            /// <value>The title.</value>
            [XmlAttribute("title")]
            public string Title { get; set; }

            /// <summary>
            ///     Gets or sets to organization ids.
            /// </summary>
            /// <value>To organization ids.</value>
            [XmlAttribute("toCorpOrAllianceID")]
            public string ToOrganizationIds { get; set; }

            /// <summary>
            ///     Gets or sets to character ids.
            /// </summary>
            /// <value>To character ids.</value>
            [XmlAttribute("toCharacterIDs")]
            public string ToCharacterIds { get; set; }

            /// <summary>
            ///     Gets or sets to list ids.
            /// </summary>
            /// <value>To list ids.</value>
            [XmlAttribute("toListID")]
            public string ToListIds { get; set; }
        }
    }
}