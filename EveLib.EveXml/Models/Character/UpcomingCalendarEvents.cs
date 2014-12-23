// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="UpcomingCalendarEvents.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Xml.Serialization;
using eZet.EveLib.EveXmlModule.Util;

namespace eZet.EveLib.EveXmlModule.Models.Character {
    /// <summary>
    ///     Class UpcomingCalendarEvents.
    /// </summary>
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class UpcomingCalendarEvents {
        /// <summary>
        ///     Gets or sets the events.
        /// </summary>
        /// <value>The events.</value>
        [XmlElement("rowset")]
        public EveXmlRowCollection<Event> Events { get; set; }

        /// <summary>
        ///     Class Event.
        /// </summary>
        [Serializable]
        [XmlRoot("row")]
        public class Event {
            /// <summary>
            ///     Gets or sets the event identifier.
            /// </summary>
            /// <value>The event identifier.</value>
            [XmlAttribute("eventID")]
            public long EventId { get; set; }

            /// <summary>
            ///     Gets or sets the owner identifier.
            /// </summary>
            /// <value>The owner identifier.</value>
            [XmlAttribute("ownerID")]
            public long OwnerId { get; set; }

            /// <summary>
            ///     Gets or sets the name of the owner.
            /// </summary>
            /// <value>The name of the owner.</value>
            [XmlAttribute("ownerName")]
            public string OwnerName { get; set; }

            /// <summary>
            ///     Gets the event date.
            /// </summary>
            /// <value>The event date.</value>
            [XmlIgnore]
            public DateTime EventDate { get; private set; }

            /// <summary>
            ///     Gets or sets the event date as string.
            /// </summary>
            /// <value>The event date as string.</value>
            [XmlAttribute("eventDate")]
            public string EventDateAsString {
                get { return EventDate.ToString(XmlHelper.DateFormat); }
                set { EventDate = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
            }

            /// <summary>
            ///     Gets or sets the event title.
            /// </summary>
            /// <value>The event title.</value>
            [XmlAttribute("eventTitle")]
            public string EventTitle { get; set; }

            /// <summary>
            ///     Gets or sets the duration.
            /// </summary>
            /// <value>The duration.</value>
            [XmlAttribute("duration")]
            public int Duration { get; set; }

            /// <summary>
            ///     Gets or sets a value indicating whether this <see cref="Event" /> is important.
            /// </summary>
            /// <value><c>true</c> if important; otherwise, <c>false</c>.</value>
            [XmlAttribute("importance")]
            public bool Important { get; set; }

            /// <summary>
            ///     Gets or sets the event text.
            /// </summary>
            /// <value>The event text.</value>
            [XmlAttribute("eventText")]
            public string EventText { get; set; }

            /// <summary>
            ///     Gets or sets the response.
            /// </summary>
            /// <value>The response.</value>
            [XmlAttribute("response")]
            public EventResponse Response { get; set; }
        }
    }

    /// <summary>
    ///     Enum EventResponse
    /// </summary>
    public enum EventResponse {
        /// <summary>
        ///     The accepted
        /// </summary>
        Accepted,

        /// <summary>
        ///     The declined
        /// </summary>
        Declined,

        /// <summary>
        ///     The tentative
        /// </summary>
        Tentative,

        /// <summary>
        ///     The undecided
        /// </summary>
        Undecided
    }
}