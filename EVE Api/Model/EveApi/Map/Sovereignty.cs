using System;
using System.Xml.Serialization;

namespace eZet.Eve.EoLib.Model.EveApi.Map {

    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class Sovereignty : XmlElement {

        [XmlElement("rowset")]
        public XmlRowSet<SolarSystem> SolarSystems { get; set; }


        [Serializable]
        [XmlRoot("row")]
        public class SolarSystem {
            
            [XmlAttribute("solarSystemID")]
            public long SolarSystemId { get; set; }

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
