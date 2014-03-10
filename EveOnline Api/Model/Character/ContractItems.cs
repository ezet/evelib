using System;
using System.Xml.Serialization;

namespace eZet.EveLib.EveOnline.Model.Character {
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class ContractItems : XmlElement {
        [XmlElement("rowset")]
        public RowCollection<ContractItem> Items { get; set; }


        [Serializable]
        [XmlRoot("row")]
        public class ContractItem {
            [XmlAttribute("recordID")]
            public long RecordId { get; set; }

            [XmlAttribute("typeID")]
            public long TypeId { get; set; }

            [XmlAttribute("quantity")]
            public long Quantity { get; set; }

            [XmlAttribute("rawQuantity")]
            public long RawQuantity { get; set; }

            [XmlAttribute("singleton")]
            public bool Singleton { get; set; }

            [XmlAttribute("included")]
            public bool Included { get; set; }
        }
    }
}