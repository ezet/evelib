using System;
using System.Xml.Serialization;

namespace eZet.Eve.EolNet.Dto.EveApi.Character {
    public class AssetList : XmlResult {

        [XmlElement("rowset")]
        public XmlRowSet<Asset> Assets { get; set; }
        
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
            public XmlRowSet<Item> Items { get; set; }

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
            public XmlRowSet<Item> Items { get; set; }

        }
    }
}
