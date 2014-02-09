using System.Xml.Serialization;

namespace eZet.Eve.EveApi.Dto {

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class MarketOrder {

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
        public string Issued { get; set; }

    }
}
