using System;
using System.Xml.Serialization;

namespace eZet.EveLib.Modules.Models.Character {
    [Serializable]
    [XmlRoot("result")]
    public class PlanetaryColonies {
        [XmlElement("rowset")]
        public EveOnlineRowCollection<PlanetaryColony> Colonies { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class PlanetaryColony {
            [XmlAttribute("solarSystemID")]
            public int SolarSystemId { get; set; }

            [XmlAttribute("solarSystemName")]
            public string SolarSystemName { get; set; }

            [XmlAttribute("planetID")]
            public long PlanetId { get; set; }

            [XmlAttribute("planetName")]
            public string PlanetName { get; set; }

            [XmlAttribute("planetTypeID")]
            public int PlanetTypeId { get; set; }

            [XmlAttribute("ownerID")]
            public long OwnerId { get; set; }

            [XmlAttribute("ownerName")]
            public string OwnerName { get; set; }

            [XmlAttribute("lastUpdate")]
            public string LastUpdateAsString { get; set; }

            [XmlAttribute("upgradeLevel")]
            public int UpgradeLevel { get; set; }

            [XmlAttribute("numberOfPins")]
            public int NumberOfPins { get; set; }
        }
    }
}