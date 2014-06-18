using System;
using System.Xml.Serialization;

namespace eZet.EveLib.Modules.Models.Character {
    [Serializable]
    [XmlRoot("result")]
    public class PlanetaryPins {
        [XmlElement("rowset")]
        public EveOnlineRowCollection<PlanetaryPin> Pins { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class PlanetaryPin {
            [XmlAttribute("pinID")]
            public long PinId { get; set; }

            [XmlAttribute("typeID")]
            public int TypeId { get; set; }

            [XmlAttribute("typeName")]
            public string TypeName { get; set; }

            [XmlAttribute("schematicID")]
            public int SchematicId { get; set; }

            [XmlAttribute("lastLaunchTime")]
            public string LastLaunchTimeAsString {
                set { LastLaunchTime = DateTime.Parse(value); }
            }

            [XmlIgnore]
            public DateTime LastLaunchTime { get; set; }

            [XmlAttribute("cycleTime")]
            public int CycleTime { get; set; }

            [XmlAttribute("quantityperCycle")]
            public int QuantityPerCycle { get; set; }

            [XmlAttribute("installTime")]
            public string InstallTimeAsString {
                set { InstallTime = DateTime.Parse(value); }
            }

            [XmlIgnore]
            public DateTime InstallTime { get; set; }

            [XmlAttribute("expiryTime")]
            public string ExpiryTimeAsString {
                set { ExpiryTime = DateTime.Parse(value); }
            }

            [XmlIgnore]
            public DateTime ExpiryTime { get; set; }

            [XmlAttribute("contentTypeID")]
            public int ContentTypeId { get; set; }

            [XmlAttribute("contentTypeName")]
            public string ContentTypeName { get; set; }

            [XmlAttribute("contentQuantity")]
            public int ContentQuantity { get; set; }

            [XmlAttribute("longitude")]
            public double Longitude { get; set; }

            [XmlAttribute("latitude")]
            public double Latitude { get; set; }
        }
    }
}