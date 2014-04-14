using System;
using System.Xml.Serialization;
using eZet.EveLib.Modules.Util;

namespace eZet.EveLib.Modules.Models.Character {
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class UpcomingCalendarEvents {
        [XmlElement("rowset")]
        public EveOnlineRowCollection<Event> Events { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class Event {
            [XmlAttribute("eventID")]
            public long EventId { get; set; }

            [XmlAttribute("ownerID")]
            public long OwnerId { get; set; }

            [XmlAttribute("ownerName")]
            public string OwnerName { get; set; }

            [XmlIgnore]
            public DateTime EventDate { get; private set; }

            [XmlAttribute("eventDate")]
            public string EventDateAsString {
                get { return EventDate.ToString(XmlHelper.DateFormat); }
                set { EventDate = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
            }

            [XmlAttribute("eventTitle")]
            public string EventTitle { get; set; }

            [XmlAttribute("duration")]
            public int Duration { get; set; }

            [XmlAttribute("importance")]
            public bool Important { get; set; }

            [XmlAttribute("eventText")]
            public string EventText { get; set; }

            [XmlAttribute("response")]
            public EventResponse Response { get; set; }
        }
    }

    public enum EventResponse {
        Accepted,
        Declined,
        Tentative,
        Undecided
    }
}