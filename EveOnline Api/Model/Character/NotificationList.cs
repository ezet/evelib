using System;
using System.Xml.Serialization;

namespace eZet.EveLib.EveOnline.Model.Character {
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class NotificationList : XmlElement {
        [XmlElement("rowset")]
        public RowCollection<Notification> Notifications { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class Notification {
            [XmlAttribute("notificationID")]
            public long NotificationId { get; set; }

            [XmlAttribute("typeID")]
            public long TypeId { get; set; }

            [XmlAttribute("senderID")]
            public long SenderId { get; set; }

            [XmlIgnore]
            public DateTime SentDate { get; private set; }

            [XmlAttribute("sentDate")]
            public string SentDateAsString {
                get { return SentDate.ToString(DateFormat); }
                set { SentDate = DateTime.ParseExact(value, DateFormat, null); }
            }

            [XmlAttribute("read")]
            public bool IsRead { get; set; }
        }
    }
}