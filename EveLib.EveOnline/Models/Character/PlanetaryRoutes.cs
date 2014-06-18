using System;
using System.Xml.Serialization;

namespace eZet.EveLib.Modules.Models.Character {
    [Serializable]
    [XmlRoot("result")]
    public class PlanetaryRoutes {
        [XmlElement("rowset")]
        public EveOnlineRowCollection<PlanetaryRoute> Routes { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class PlanetaryRoute {
            [XmlAttribute("routeID")]
            public long RouteId { get; set; }

            [XmlAttribute("sourcePinID")]
            public long SourcePinId { get; set; }

            [XmlAttribute("destinationPinID")]
            public long DestinationPinId { get; set; }

            [XmlAttribute("contentTypeID")]
            public int ContentTypeId { get; set; }

            [XmlAttribute("contentTypeName")]
            public string ContentTypeName { get; set; }

            [XmlAttribute("quantity")]
            public int Quantity { get; set; }

            [XmlAttribute("waypoint1")]
            public long Waypoint { get; set; }

            [XmlAttribute("waypoint2")]
            public long Waypoint2 { get; set; }

            [XmlAttribute("waypoint3")]
            public long Waypoint3 { get; set; }

            [XmlAttribute("waypoint4")]
            public long Waypoint4 { get; set; }

            [XmlAttribute("waypoint5")]
            public long Waypoint5 { get; set; }
        }
    }
}