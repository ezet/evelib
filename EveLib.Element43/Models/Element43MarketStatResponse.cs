using System;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace eZet.EveLib.Modules.Models {
    [Serializable]
    [XmlType(AnonymousType = true)]
    [XmlRoot(ElementName = "e43_api", IsNullable = false)]
    public class Element43MarketStatResponse : Element43Response {
        [XmlArray("marketstat"), XmlArrayItem("type")]
        public Collection<Element43MarketStatItem> Result { get; set; }

    }

    public class Element43MarketStatItem {
        [XmlAttribute("id")]
        public long TypeId { get; set; }

        [XmlElement("buy")]
        public Element43MarketStatOrderData BuyOrders { get; set; }

        [XmlElement("sell")]
        public Element43MarketStatOrderData SellOrders { get; set; }

        [XmlElement("lastupdate")]
        public DateTime LastUpdate { get; set; }

        [XmlElement("traded_last_7")]
        public long VolumeLastWeek { get; set; }

    }

    public class Element43MarketStatOrderData {
        [XmlElement("volume")]
        public long Volume { get; set; }

        [XmlElement("avg")]
        public double Average { get; set; }

        [XmlElement("max")]
        public double Max { get; set; }

        [XmlElement("min")]
        public double Min { get; set; }

        [XmlElement("stddev")]
        public double StdDev { get; set; }

        [XmlElement("median")]
        public double Median { get; set; }

        [XmlElement("percentile")]
        public double Percentile { get; set; }
    }
}