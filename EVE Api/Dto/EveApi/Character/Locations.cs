using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace eZet.Eve.EveApi.Dto.EveApi.Character {
    public class Locations : XmlResult {

        [XmlElement("rowset")]
        public XmlRowSet<Location> Items { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class Location {
            
            [XmlAttribute("itemID")]
            public long ItemId { get; set; }

            [XmlAttribute("itemName")]
            public string ItemName { get; set; }

            [XmlAttribute("x")]
            public double X { get; set; }

            [XmlAttribute("y")]
            public double Y { get; set; }

            [XmlAttribute("z")]
            public double Z { get; set; }
        }
    }
}
