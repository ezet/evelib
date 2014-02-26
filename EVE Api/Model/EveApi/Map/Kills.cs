using System;
using System.Xml.Serialization;

namespace eZet.Eve.EoLib.Model.EveApi.Map {

    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class Kills : XmlElement {

        [XmlElement("rowset")]
        public XmlRowSet<SolarSystem> SolarSystems { get; set; }

            
        [Serializable]
        [XmlRoot("row")]
        public class SolarSystem {

            [XmlAttribute("solarSystemID")]
            public long SolarSystemId { get; set; }

            [XmlAttribute("shipKills")]
            public int ShipKills { get; set; }

            [XmlAttribute("factionKills")]
            public int FactionKills { get; set; }

            [XmlAttribute("podKills")]
            public int PodKills { get; set; }
            
        }
    }
}
