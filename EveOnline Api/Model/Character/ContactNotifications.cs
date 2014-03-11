using System;
using System.Xml.Serialization;

namespace eZet.EveLib.EveOnline.Model.Character {
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class ContactNotifications {
        [XmlElement("rowset")]
        public RowCollection<Notification> Notifications { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class Notification {
            [XmlAttribute("notificationID")]
            public long NotificationId { get; set; }

            [XmlAttribute("senderID")]
            public long SenderId { get; set; }

            [XmlAttribute("senderName")]
            public string SenderName { get; set; }

            [XmlIgnore]
            public DateTime SentDate { get; private set; }

            [XmlAttribute("sentDate")]
            public string SentDateAsString {
                get { return SentDate.ToString(XmlHelper.DateFormat); }
                set { SentDate = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
            }

            [XmlAttribute("messageData")]
            public string MessageData { get; set; }
        }
    }
}