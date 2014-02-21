using System;
using System.Xml.Serialization;

namespace eZet.Eve.EolNet.Dto.EveApi.Character {
    public class NotificationTexts : XmlResult {

        [XmlElement("rowset")]
        public XmlRowSet<Notification> Notifications { get; set; }

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
