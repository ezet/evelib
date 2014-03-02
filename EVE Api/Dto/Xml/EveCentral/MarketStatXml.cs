using System.Xml.Serialization;

namespace eZet.Eve.EveLib.Dto.Xml.EveCentral {
    /// <remarks />
    [XmlType(AnonymousType = true)]
    [XmlRoot("evec_api", IsNullable = false)]
    public class MarketStatXml {
        /// <remarks />
        [XmlArrayItem("type", IsNullable = false)]
        public Item[] marketstat { get; set; }

        /// <remarks />
        [XmlAttribute]
        public decimal version { get; set; }

        /// <remarks />
        [XmlAttribute]
        public string method { get; set; }

        /// <remarks />
        [XmlType(AnonymousType = true)]
        public class Item {
            /// <remarks />
            public ItemData buy { get; set; }

            /// <remarks />
            public ItemData sell { get; set; }

            /// <remarks />
            public ItemData all { get; set; }

            /// <remarks />
            [XmlAttribute]
            public byte id { get; set; }
        }

        /// <remarks />
        [XmlType(AnonymousType = true)]
        public class ItemData {
            /// <remarks />
            public ulong volume { get; set; }

            /// <remarks />
            public decimal avg { get; set; }

            /// <remarks />
            public decimal max { get; set; }

            /// <remarks />
            public decimal min { get; set; }

            /// <remarks />
            public decimal stddev { get; set; }

            /// <remarks />
            public decimal median { get; set; }

            /// <remarks />
            public decimal percentile { get; set; }
        }
    }
}