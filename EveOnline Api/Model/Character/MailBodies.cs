using System;
using System.Xml.Serialization;

namespace eZet.EveLib.EveOnline.Model.Character {
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class MailBodies : XmlElement {
        [XmlElement("rowset")]
        public RowCollection<Message> Messages { get; set; }

        [XmlElement("missingMessageIDs")]
        public string MissingMessageIds { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class Message {
            [XmlAttribute("messageID")]
            public long MessageId { get; set; }

            [XmlText]
            public string MessageData { get; set; }
        }
    }
}