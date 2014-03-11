using System;
using System.Xml.Serialization;

namespace eZet.EveLib.EveOnline.Model.Character {
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class MailMessages {
        [XmlElement("rowset")]
        public RowCollection<Message> Messages { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class Message {
            [XmlAttribute("messageID")]
            public long MessageId { get; set; }

            [XmlAttribute("senderID")]
            public long SenderId { get; set; }

            [XmlIgnore]
            public DateTime SentDate { get; private set; }

            [XmlAttribute("sentDate")]
            public string SentDateAsString {
                get { return SentDate.ToString(XmlHelper.DateFormat); }
                set { SentDate = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
            }

            [XmlAttribute("title")]
            public string Title { get; set; }

            [XmlAttribute("toCorpOrAllianceID")]
            public string ToOrganizationIds { get; set; }

            [XmlAttribute("toCharacterIDs")]
            public string ToCharacterIds { get; set; }

            [XmlAttribute("toListID")]
            public string ToListIds { get; set; }
        }
    }
}