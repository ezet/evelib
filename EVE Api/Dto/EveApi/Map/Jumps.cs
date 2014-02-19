using System;
using System.Xml.Serialization;

namespace eZet.Eve.EveApi.Dto.EveApi.Map {
    public class Jumps : XmlResult {

        [XmlElement("rowset")]
        public XmlRowSet<SolarSystem> SolarSystems { get; set; }
        
        [Serializable]
        [XmlRoot("row")]
        public class SolarSystem {

            [XmlAttribute("solarSystemID")]
            public long SolarSystemId { get; set; }

            [XmlAttribute("shipJumps")]
            public int ShipJumps { get; set; }
            
        }
    }
}
