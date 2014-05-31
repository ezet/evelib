using System;
using System.Xml.Serialization;

namespace eZet.EveLib.Modules.Models.Map {
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class Jumps {
        [XmlElement("rowset")]
        public EveOnlineRowCollection<SolarSystem> SolarSystems { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class SolarSystem {
            [XmlAttribute("solarSystemID")]
            public int SolarSystemId { get; set; }

            [XmlAttribute("shipJumps")]
            public int ShipJumps { get; set; }
        }
    }
}