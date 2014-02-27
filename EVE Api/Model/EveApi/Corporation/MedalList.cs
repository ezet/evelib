using System;
using System.Xml.Serialization;

namespace eZet.Eve.EveLib.Model.EveApi.Corporation {

    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class MedalList : XmlElement {

        [XmlElement("rowset")]
        public XmlRowSet<Medal> Medals { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class Medal {
            [XmlAttribute("medalID")]
            public long MedalId { get; set; }

            [XmlAttribute("title")]
            public string Title { get; set; }

            [XmlAttribute("description")]
            public string Description { get; set; }

            [XmlAttribute("creatorID")]
            public long CreatorId { get; set; }

            [XmlIgnore]
            public DateTime CreatedDate { get; set; }

            [XmlAttribute("created")]
            public string CreatedDateAsString {
                get { return CreatedDate.ToString(DateFormat); }
                set { CreatedDate = DateTime.ParseExact(value, DateFormat, null); }
            }
        }

    }
}
