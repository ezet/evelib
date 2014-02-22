using System;
using System.Xml.Serialization;

namespace eZet.Eve.EoLib.Dto.EveApi.Core {
    public class AllianceList : XmlElement {

        [XmlElement("rowset")]
        public XmlRowSet<AllianceData> Alliances { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class AllianceData {

            [XmlAttribute("name")]
            public string AllianceName { get; set; }

            [XmlAttribute("shortName")]
            public string AllianceTag { get; set; }

            [XmlAttribute("allianceID")]
            public long AllianceId { get; set; }

            [XmlAttribute("executorCorpID")]
            public long ExecutorCorpId { get; set; }

            [XmlAttribute("memberCount")]
            public int MemberCount { get; set; }

            [XmlIgnore]
            public DateTime StartDate { get; private set; }

            [XmlAttribute("startDate")]
            public string StartDateAsString {
                get { return StartDate.ToString(DateFormat); }
                set { StartDate = DateTime.ParseExact(value, DateFormat, null); }
            }

            [XmlElement("rowset")]
            public XmlRowSet<CorporationData> Corporations { get; set; }

        }

        [Serializable]
        [XmlRoot("row")]
        public class CorporationData {

            [XmlAttribute("corporationID")]
            public long CorporationId { get; set; }

            [XmlIgnore]
            public DateTime StartDate { get; private set; }

            [XmlAttribute("startDate")]
            public string StartDateAsString {
                get { return StartDate.ToString(DateFormat); }
                set { StartDate = DateTime.ParseExact(value, DateFormat, null); }
            }

        }
    }
}
