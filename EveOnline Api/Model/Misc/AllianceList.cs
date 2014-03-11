using System;
using System.Xml.Serialization;

namespace eZet.EveLib.EveOnline.Model.Misc {
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class AllianceList {
        [XmlElement("rowset")]
        public RowCollection<AllianceData> Alliances { get; set; }

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
                get { return StartDate.ToString(XmlHelper.DateFormat); }
                set { StartDate = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
            }

            [XmlElement("rowset")]
            public RowCollection<CorporationData> Corporations { get; set; }
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
                get { return StartDate.ToString(XmlHelper.DateFormat); }
                set { StartDate = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
            }
        }
    }
}