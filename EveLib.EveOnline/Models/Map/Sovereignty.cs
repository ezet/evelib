using System;
using System.Xml.Serialization;

namespace eZet.EveLib.Modules.Models.Map {
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class Sovereignty {
        [XmlElement("rowset")]
        public EveOnlineRowCollection<SolarSystem> SolarSystems { get; set; }


        [Serializable]
        [XmlRoot("row")]
        public class SolarSystem {
            [XmlAttribute("solarSystemID")]
            public int SolarSystemId { get; set; }

            [XmlAttribute("allianceID")]
            public long AllianceId { get; set; }

            [XmlAttribute("factionID")]
            public long FactionId { get; set; }

            [XmlAttribute("solarSystemName")]
            public string SolarSystemName { get; set; }

            [XmlAttribute("corporationID")]
            public long CorporationId { get; set; }
        }
    }
}