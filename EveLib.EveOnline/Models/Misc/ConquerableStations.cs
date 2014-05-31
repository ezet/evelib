using System;
using System.Xml.Serialization;

namespace eZet.EveLib.Modules.Models.Misc {
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class ConquerableStations {
        [XmlElement("rowset")]
        public EveOnlineRowCollection<StationData> Stations { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class StationData {
            [XmlAttribute("stationID")]
            public int StationId { get; set; }

            [XmlAttribute("stationName")]
            public string StationName { get; set; }

            [XmlAttribute("stationTypeID")]
            public long StationTypeId { get; set; }

            [XmlAttribute("solarSystemID")]
            public int SolarSystemId { get; set; }

            [XmlAttribute("corporationID")]
            public long CorporationId { get; set; }

            [XmlAttribute("corporationName")]
            public string CorporationName { get; set; }
        }
    }
}