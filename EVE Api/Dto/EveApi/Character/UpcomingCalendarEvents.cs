using System;
using System.Xml.Serialization;

namespace eZet.Eve.EveApi.Dto.EveApi.Character {
    public class UpcomingCalendarEvents : XmlResult {

        [XmlElement("rowset")]
        public XmlRowSet<Event> Events { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class Event {
            [XmlAttribute("eventID")]
            public long EventId { get; set; }

            [XmlAttribute("ownerID")]
            public long OwnerId { get; set; }

            [XmlAttribute("ownerName")]
            public string OwnerName { get; set; }

            // TODO Convert to DateTime
            [XmlAttribute("eventDate")]
            public string EventDate { get; set; }

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
