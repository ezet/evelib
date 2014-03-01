using System;
using System.Xml.Serialization;

namespace eZet.Eve.EveLib.Model.EveMarketData {

    [Serializable]
    [XmlType(AnonymousType = true)]
    public class ItemOrder {

        [XmlElement("rowset")]
        public XmlRowSet<ItemOrderEntry> RecentUploads { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class ItemOrderEntry {

            [XmlAttribute("buysell")]
            public string OrderType { get; set; }

            [XmlAttribute("typeID")]
            public long TypeId { get; set; }

            [XmlAttribute("regionID")]
            public long RegionID { get; set; }

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
            public string Issued { get; set; }

            [XmlAttribute("expires")]
            public string Expires { get; set; }

            [XmlAttribute("created")]
            public string Created { get; set; }
        }

    }
}
