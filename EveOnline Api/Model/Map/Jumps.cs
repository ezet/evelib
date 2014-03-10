using System;
using System.Xml.Serialization;

namespace eZet.EveLib.EveOnline.Model.Map {
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class Jumps : XmlElement {
        [XmlElement("rowset")]
        public RowCollection<SolarSystem> SolarSystems { get; set; }

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