using System;
using System.Xml.Serialization;

namespace eZet.EveLib.EveOnline.Model.Corporation {
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class MemberMedals {
        [XmlElement("rowset")]
        public RowCollection<Medal> Medals { get; set; }


        [Serializable]
        [XmlRoot("row")]
        public class Medal {
            [XmlAttribute("medalID")]
            public long MedalId { get; set; }

            [XmlAttribute("characterID")]
            public long CharacterId { get; set; }

            [XmlAttribute("reason")]
            public string Reason { get; set; }

            [XmlAttribute("status")]
            public string Status { get; set; }

            [XmlAttribute("issuerID")]
            public long IssuerId { get; set; }

            [XmlIgnore]
            public DateTime IssuedDate { get; set; }

            [XmlAttribute("issued")]
            public string IssuedDateAsString {
                get { return IssuedDate.ToString(XmlHelper.DateFormat); }
                set { IssuedDate = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
            }
        }
    }
}