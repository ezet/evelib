// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="CalendarEventAttendees.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Xml.Serialization;

namespace eZet.EveLib.Modules.Models.Character {
    /// <summary>
    ///     Class CalendarEventAttendees.
    /// </summary>
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class CalendarEventAttendees {
        /// <summary>
        ///     Gets or sets the attendees.
        /// </summary>
        /// <value>The attendees.</value>
        [XmlElement("rowset")]
        public EveOnlineRowCollection<Attendee> Attendees { get; set; }


        /// <summary>
        ///     Class Attendee.
        /// </summary>
        [Serializable]
        [XmlRoot("row")]
        public class Attendee {
            /// <summary>
            ///     Gets or sets the character identifier.
            /// </summary>
            /// <value>The character identifier.</value>
            [XmlAttribute("characterID")]
            public long CharacterId { get; set; }

            /// <summary>
            ///     Gets or sets the name of the character.
            /// </summary>
            /// <value>The name of the character.</value>
            [XmlAttribute("characterName")]
            public string CharacterName { get; set; }

            /// <summary>
            ///     Gets or sets the response.
            /// </summary>
            /// <value>The response.</value>
            [XmlAttribute("response")]
            public EventResponse Response { get; set; }
        }
    }
}