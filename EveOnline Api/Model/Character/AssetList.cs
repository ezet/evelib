using System;
using System.Xml.Serialization;

namespace eZet.EveLib.EveOnline.Model.Character {
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class AssetList : XmlElement {
        [XmlElement("rowset")]
        public RowCollection<Asset> Assets { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class Asset {
            [XmlAttribute("itemID")]
            public long ItemId { get; set; }

            [XmlAttribute("locationID")]
            public long LocationId { get; set; }

            [XmlAttribute("typeID")]
            public long TypeId { get; set; }

            [XmlAttribute("quantity")]
            public int Quantity { get; set; }

            [XmlAttribute("flag")]
            public int Flag { get; set; }

            [XmlAttribute("singleton")]
            public bool Singleton { get; set; }

            [XmlElement("rowset")]
            public RowCollection<Item> Items { get; set; }
        }

        [Serializable]
        [XmlRoot("row")]
        public class Item {
            [XmlAttribute("itemID")]
            public long ItemId { get; set; }

            [XmlAttribute("typeID")]
            public long TypeId { get; set; }

            [XmlAttribute("quantity")]
            public int Quantity { get; set; }

            [XmlAttribute("flag")]
            public int Flag { get; set; }

            [XmlAttribute("singleton")]
            public bool Singleton { get; set; }

            [XmlElement("rowset")]
            public RowCollection<Item> Items { get; set; }
        }
    }
}