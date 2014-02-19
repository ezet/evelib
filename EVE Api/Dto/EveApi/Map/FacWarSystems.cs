using System;
using System.Xml.Serialization;

namespace eZet.Eve.EveApi.Dto.EveApi.Map {
    public class FacWarSystems : XmlResult {

        [XmlElement("rowset")]
        public XmlRowSet<SolarSystem> SolarSystems { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class SolarSystem {

            [XmlAttribute("solarSystemID")]
            public long SolarSystemId { get; set; }

            [XmlAttribute("solarSystemName")]
            public string SolarSystemName { get; set; }

            [XmlAttribute("occupyingFactionID")]
            public long OccupyingFactionId { get; set; }

            [XmlAttribute("occupyingFactionName")]
            public string OccupyingFactionName { get; set; }

            [XmlAttribute("contested")]
            public string Contested { get; set; }
            
        }
    }


}
