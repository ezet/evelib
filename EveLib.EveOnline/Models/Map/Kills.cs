using System;
using System.Xml.Serialization;

namespace eZet.EveLib.Modules.Models.Map {
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class Kills {
        [XmlElement("rowset")]
        public EveOnlineRowCollection<SolarSystem> SolarSystems { get; set; }


        [Serializable]
        [XmlRoot("row")]
        public class SolarSystem {
            [XmlAttribute("solarSystemID")]
            public int SolarSystemId { get; set; }

            [XmlAttribute("shipKills")]
            public int ShipKills { get; set; }

            [XmlAttribute("factionKills")]
            public int FactionKills { get; set; }

            [XmlAttribute("podKills")]
            public int PodKills { get; set; }
        }
    }
}