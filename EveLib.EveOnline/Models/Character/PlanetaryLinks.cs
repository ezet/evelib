using System;
using System.Xml.Serialization;

namespace eZet.EveLib.Modules.Models.Character {
    [Serializable]
    [XmlRoot("result")]
    public class PlanetaryLinks {
        [XmlElement("rowset")]
        public EveOnlineRowCollection<PlanetaryLink> Links { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class PlanetaryLink {
            [XmlAttribute("sourcePinID")]
            public long SourcePinId { get; set; }

            [XmlAttribute("destinationPinID")]
            public long DestinationPinId { get; set; }

            [XmlAttribute("linkLevel")]
            public int LinkLevel { get; set; }
        }
    }
}