using System;
using System.Xml.Serialization;

namespace eZet.Eve.EveApi.Dto.EveApi.Character {

    [SerializableAttribute]
    [System.Diagnostics.DebuggerStepThroughAttribute]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    public class MarketOrders : XmlResult {

        [XmlElement("rowset")]
        public XmlRowSet<MarketOrder> Orders { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class MarketOrder {

            [XmlElement("orderID")]
            public long OrderId { get; set; }

            [XmlElement("charID")]
            public long CharacterId { get; set; }

            [XmlElement("stationID")]
            public long StationId { get; set; }

            [XmlElement("volEntered")]
            public int VolumeEntered { get; set; }

            [XmlElement("volRemaining")]
            public int VolumeRemaining { get; set; }

            [XmlElement("minVolume")]
            public int MinVolume { get; set; }

            [XmlElement("orderState")]
            public int OrderState { get; set; }

            [XmlElement("typeID")]
            public long TypeId { get; set; }

            [XmlElement("range")]
            public int Range { get; set; }

            [XmlElement("accountKey")]
            public int AccountKey { get; set; }

            [XmlElement("duration")]
            public int Duration { get; set; }

            [XmlElement("escrow")]
            public decimal Escrow { get; set; }

            [XmlElement("price")]
            public decimal Price { get; set; }

            [XmlElement("bid")]
            public int Bid { get; set; }

            [XmlElement("issued")]
            public DateTime Issued { get; set; }

        }
    }
}