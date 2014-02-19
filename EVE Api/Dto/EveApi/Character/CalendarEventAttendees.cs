using System;
using System.Xml.Serialization;

namespace eZet.Eve.EveApi.Dto.EveApi.Character {
    public class CalendarEventAttendees : XmlResult {


        [Serializable]
        [XmlRoot("row")]
        public class Attendee {
            
            [XmlAttribute("characterID")]
            public long CharacterId { get; set; }

            [XmlAttribute("characterName")]
            public string CharacterName { get; set; }

            [XmlAttribute("response")]
            public EventResponse EventResponse { get; set; }
        }


    }
}
