using System;
using System.Xml.Serialization;

namespace eZet.Eve.EveApi.Dto.EveApi.Character {
    public class MailMessages : XmlResult {

        [XmlElement("rowset")]
        public XmlRowSet<Message> Messages { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class Message {
            [XmlAttribute("messageID")]
            public long MessageId { get; set; }

            [XmlAttribute("senderID")]
            public long SenderId { get; set; }

            [XmlAttribute("sentDate")]
            public DateTime SentDate { get; set; }

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
