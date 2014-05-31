using System;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace eZet.EveLib.Modules.Models {
    [Serializable]
    [XmlType(AnonymousType = true)]
    [XmlRoot(ElementName = "evec_api", Namespace = "", IsNullable = false)]
    public class EveCentralMarketStatResponse : EveCentralResponse {
        [XmlArray("marketstat"), XmlArrayItem("type")]
        public Collection<EveCentralMarketStatItem> Result { get; set; }
    }

    public class EveCentralMarketStatItem {
        [XmlAttribute("id")]
        public int TypeId { get; set; }

        [XmlElement("buy")]
        public EveCentralMarketStatOrderData BuyOrders { get; set; }

        [XmlElement("sell")]
        public EveCentralMarketStatOrderData SellOrders { get; set; }

        [XmlElement("all")]
        public EveCentralMarketStatOrderData All { get; set; }
    }

    public class EveCentralMarketStatOrderData {
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