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
        public long TypeId { get; set; }

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