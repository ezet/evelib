using System;
using System.Xml.Serialization;

namespace eZet.EveLib.Modules.Models.Corporation {
    [Serializable]
    [XmlRoot("result")]
    public class Facilities {
        [XmlElement("rowset")]
        public EveOnlineRowCollection<Facility> FacilityEntries { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class Facility {
            [XmlAttribute("facilityID")]
            public long FacilityId { get; set; }

            [XmlAttribute("typeID")]
            public int TypeId { get; set; }

            [XmlAttribute("solarSystemID")]
            public int SolarSystemId { get; set; }

            [XmlAttribute("solarSystemName")]
            public string SolarSystemName { get; set; }

            [XmlAttribute("regionID")]
            public int RegionId { get; set; }

            [XmlAttribute("regionName")]
            public string RegionName { get; set; }

            [XmlAttribute("starbaseModifier")]
            public float StartbaseModifier { get; set; }

            [XmlAttribute("tax")]
            public float Tax { get; set; }
        }
    }
}