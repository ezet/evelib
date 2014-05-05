using System.Xml.Serialization;

namespace eZet.EveLib.Modules.Models.Character {

    [XmlRoot("result")]
    public class PlanetaryRoutes {

        [XmlElement("rowset")]
        public EveOnlineRowCollection<PlanetaryRoute> Routes { get; set; }

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
            public string Waypoint { get; set; }

            [XmlAttribute("waypoint2")]
            public string Waypoint2 { get; set; }

            [XmlAttribute("waypoint3")]
            public string Waypoint3 { get; set; }

            [XmlAttribute("waypoint4")]
            public string Waypoint4 { get; set; }

            [XmlAttribute("waypoint5")]
            public string Waypoint5 { get; set; }
        }
    }
}
