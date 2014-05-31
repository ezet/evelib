using System;
using System.Xml.Serialization;

namespace eZet.EveLib.Modules.Models.Character {
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class ContractItems {
        [XmlElement("rowset")]
        public EveOnlineRowCollection<ContractItem> Items { get; set; }


        [Serializable]
        [XmlRoot("row")]
        public class ContractItem {
            [XmlAttribute("recordID")]
            public long RecordId { get; set; }

            [XmlAttribute("typeID")]
            public int TypeId { get; set; }

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