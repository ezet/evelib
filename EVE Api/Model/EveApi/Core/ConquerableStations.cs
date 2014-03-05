using System;
using System.Xml.Serialization;

namespace eZet.Eve.EveLib.Model.EveApi.Core {
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class ConquerableStations : XmlElement {
        [XmlElement("rowset")]
        public XmlRowSet<StationData> Stations { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class StationData {
            [XmlAttribute("stationID")]
            public long StationId { get; set; }

            [XmlAttribute("stationName")]
            public string StationName { get; set; }

            [XmlAttribute("stationTypeID")]
            public long StationTypeId { get; set; }

            [XmlAttribute("solarSystemID")]
            public long SolarSystemId { get; set; }

            [XmlAttribute("corporationID")]
            public long CorporationId { get; set; }

            [XmlAttribute("corporationName")]
            public string CorporationName { get; set; }
        }
    }
}