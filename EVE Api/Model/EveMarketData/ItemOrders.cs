using System;
using System.Xml.Serialization;
using eZet.Eve.EveLib.Entity.EveMarketData;

namespace eZet.Eve.EveLib.Model.EveMarketData {
    [Serializable]
    [XmlType(AnonymousType = true)]
    public class ItemOrders {
        [XmlElement("rowset")]
        public XmlRowSet<ItemOrderEntry> Orders { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class ItemOrderEntry {
            [XmlAttribute("buysell")]
            public OrderType OrderType { get; set; }

            [XmlAttribute("typeID")]
            public long TypeId { get; set; }


            [XmlAttribute("stationID")]
            public long StationId { get; set; }

            [XmlAttribute("solarsystemID")]
            public long SolarSystemId { get; set; }

            [XmlAttribute("regionID")]
            public long RegionId { get; set; }

            [XmlAttribute("price")]
            public decimal Price { get; set; }

            [XmlAttribute("orderID")]
            public long OrderId { get; set; }

            [XmlAttribute("volEntered")]
            public int VolEntered { get; set; }

            [XmlAttribute("volRemaining")]
            public int VolRemaining { get; set; }

            [XmlAttribute("minVolume")]
            public int MinVolume { get; set; }

            [XmlAttribute("range")]
            public int Range { get; set; }

            [XmlAttribute("issued")]
            public string IssuedDate { get; set; }

            [XmlAttribute("expires")]
            public string ExpiresDate { get; set; }

            [XmlAttribute("created")]
            public string CreatedDate { get; set; }
        }
    }
}