using System;
using System.Xml.Serialization;

namespace eZet.EveLib.Modules.Models.Map {
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class FactionWarfareSystems {
        [XmlElement("rowset")]
        public EveOnlineRowCollection<SolarSystem> SolarSystems { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class SolarSystem {
            [XmlAttribute("solarSystemID")]
            public int SolarSystemId { get; set; }

            [XmlAttribute("solarSystemName")]
            public string SolarSystemName { get; set; }

            [XmlAttribute("occupyingFactionID")]
            public long OccupyingFactionId { get; set; }

            [XmlAttribute("occupyingFactionName")]
            public string OccupyingFactionName { get; set; }

            [XmlIgnore]
            public bool Contested { get; private set; }

            [XmlAttribute("contested")]
            public string ContestedAsString {
                get { return Contested.ToString(); }
                set { Contested = value == "True".ToLower(); }
            }
        }
    }
}