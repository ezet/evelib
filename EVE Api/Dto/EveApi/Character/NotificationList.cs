using System;
using System.Xml.Serialization;

namespace eZet.Eve.EveApi.Dto.EveApi.Character {
    public class NotificationList : XmlResult {

        [XmlElement("rowset")]
        public XmlRowSet<Notification> Notifications { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class Notification {
            
            [XmlAttribute("notificationID")]
            public long NotificationId { get; set; }

            [XmlAttribute("typeID")]
            public long TypeId { get; set; }

            [XmlAttribute("senderID")]
            public long SenderId { get; set; }

            // TODO DateTime
            [XmlAttribute("sentDate")]
            public string SentDate { get; set; }

            [XmlAttribute("read")]
            public bool IsRead { get; set; }
        }
    }
}
