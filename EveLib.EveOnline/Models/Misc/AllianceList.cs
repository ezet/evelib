using System;
using System.Xml.Serialization;
using eZet.EveLib.Modules.Util;

namespace eZet.EveLib.Modules.Models.Misc {
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class AllianceList {
        [XmlElement("rowset")]
        public EveOnlineRowCollection<AllianceData> Alliances { get; set; }

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
            public EveOnlineRowCollection<CorporationData> Corporations { get; set; }
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