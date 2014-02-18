using System;
using System.Xml.Serialization;

namespace eZet.Eve.EveApi.Dto.EveApi.Core {
    public class AllianceList : XmlResult {

        [XmlElement("rowset")]
        public XmlRowSet<AllianceListData> Alliances { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class AllianceListData : Account.AllianceData {

            [XmlElement("rowset")]
            public XmlRowSet<CorporationData> Corporations { get; set; }

        }
        [Serializable]
        [XmlRoot("row")]
        public class CorporationData {

            [XmlAttribute("corporationID")]
            public long CorporationId { get; set; }

            [XmlAttribute("startDate")]
            public string StartDate { get; set; }

        }
    }

}
