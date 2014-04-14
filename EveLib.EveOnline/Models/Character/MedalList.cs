using System;
using System.Xml.Serialization;
using eZet.EveLib.Modules.Util;

namespace eZet.EveLib.Modules.Models.Character {
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

            [XmlAttribute("reason")]
            public string Reason { get; set; }

            [XmlAttribute("status")]
            public string Status { get; set; }

            [XmlAttribute("issuerID")]
            public long IssuerId { get; set; }

            [XmlIgnore]
            public DateTime IssuedDate { get; private set; }

            [XmlAttribute("issued")]
            public string IssuedDateAsString {
                get { return IssuedDate.ToString(XmlHelper.DateFormat); }
                set { IssuedDate = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
            }

            [XmlAttribute("corporationID")]
            public long CorporationId { get; set; }

            [XmlAttribute("title")]
            public string Title { get; set; }

            [XmlAttribute("description")]
            public string Description { get; set; }
        }
    }
}