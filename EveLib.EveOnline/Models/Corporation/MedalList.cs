using System;
using System.Xml.Serialization;
using eZet.EveLib.Modules.Util;

namespace eZet.EveLib.Modules.Models.Corporation {
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class MedalList {
        [XmlElement("rowset")]
        public EveOnlineRowCollection<Medal> Medals { get; set; }

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
                get { return CreatedDate.ToString(XmlHelper.DateFormat); }
                set { CreatedDate = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
            }
        }
    }
}