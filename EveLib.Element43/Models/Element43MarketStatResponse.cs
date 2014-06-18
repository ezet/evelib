using System;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace eZet.EveLib.Modules.Models {
    [Serializable]
    [XmlType(AnonymousType = true)]
    [XmlRoot(ElementName = "e43_api", IsNullable = false)]
    public class Element43MarketStatResponse {
        [XmlArray("marketstat"), XmlArrayItem("type")]
        public Collection<Element43MarketStatItem> Result { get; set; }
    }

    public class Element43MarketStatItem {
        [XmlAttribute("id")]
        public int TypeId { get; set; }

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
        public decimal Average { get; set; }

        [XmlElement("max")]
        public decimal Max { get; set; }

        [XmlElement("min")]
        public decimal Min { get; set; }

        [XmlElement("stddev")]
        public double StdDev { get; set; }

        [XmlElement("median")]
        public decimal Median { get; set; }

        [XmlElement("percentile")]
        public decimal Percentile { get; set; }
    }
}