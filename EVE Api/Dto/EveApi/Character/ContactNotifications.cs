using System;
using System.Xml.Serialization;

namespace eZet.Eve.EveApi.Dto.EveApi.Character {
    public class ContactNotifications : XmlResult {

        [XmlElement("rowset")]
        public XmlRowSet<Notification> Notifications { get; set; }
            
        [Serializable]
        [XmlRoot("row")]
        public class Notification {

            [XmlAttribute("notificationID")]
            public long NotificationId { get; set; }

            [XmlAttribute("senderID")]
            public long SenderId { get; set; }

            [XmlAttribute("senderName")]
            public string SenderName { get; set; }

            [XmlAttribute("sentDate")]
            public DateTime SentDate { get; set; }

            [XmlAttribute("messageData")]
            public string MessageData { get; set; }
        }
    }
}
