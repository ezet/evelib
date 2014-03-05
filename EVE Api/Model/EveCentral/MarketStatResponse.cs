using System;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace eZet.Eve.EveLib.Model.EveCentral {

    [Serializable]
    [XmlType(AnonymousType = true)]
    [XmlRoot(ElementName = "evec_api", Namespace = "", IsNullable = false)]
    public class MarketStatResponse : EveCentralResponse {

        [XmlArray("marketstat"), XmlArrayItem("type")]
        public Collection<MarketStatItem> Result { get; set; }

    }

    public class MarketStatItem {

        [XmlAttribute("id")]
        public long TypeId { get; set; }

        [XmlElement("buy")]
        public MarketStatOrderData BuyOrders { get; set; }

        [XmlElement("sell")]
        public MarketStatOrderData SellOrders { get; set; }

        [XmlElement("all")]
        public MarketStatOrderData All { get; set; }

    }

    public class MarketStatOrderData {
        
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
