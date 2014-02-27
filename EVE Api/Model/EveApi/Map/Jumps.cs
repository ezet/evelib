using System;
using System.Xml.Serialization;

namespace eZet.Eve.EveLib.Model.EveApi.Map {

    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class Jumps : XmlElement {

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
