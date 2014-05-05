using System.Xml.Serialization;

namespace eZet.EveLib.Modules.Models.Character {

    [XmlRoot("result")]
    public class PlanetaryLinks {

        [XmlElement("rowset")]
        public EveOnlineRowCollection<PlanetaryLink> Links { get; set; }

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
