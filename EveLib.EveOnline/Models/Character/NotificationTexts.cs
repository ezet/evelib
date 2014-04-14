using System;
using System.Xml.Serialization;

namespace eZet.EveLib.Modules.Models.Character {
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class NotificationTexts {
        [XmlElement("rowset")]
        public EveOnlineRowCollection<Notification> Notifications { get; set; }

        [XmlElement("MissingIDs")]
        public string MissingIds { get; set; }


        [Serializable]
        [XmlRoot("row")]
        public class Notification {
            [XmlAttribute("notificationID")]
            public long NotificationId { get; set; }

            [XmlText]
            public string Content { get; set; }
        }
    }
}