using System;
using System.Xml.Serialization;

namespace eZet.Eve.EoLib.Dto.EveApi.Character {
    public class MailMessages : XmlElement {

        [XmlElement("rowset")]
        public XmlRowSet<Message> Messages { get; set; }

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
                get { return SentDate.ToString(DateFormat); }
                set { SentDate = DateTime.ParseExact(value, DateFormat, null); }
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
