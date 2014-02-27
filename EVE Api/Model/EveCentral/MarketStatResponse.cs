using System;
using System.Xml.Serialization;

namespace eZet.Eve.EveLib.Model.EveCentral {

    [Serializable]
    [System.Diagnostics.DebuggerStepThroughAttribute]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(ElementName = "evec_api", Namespace = "", IsNullable = false)]
    public class MarketStatResponse : XmlResponse {

        [XmlElement("marketstat")]
        public MarketStatsResult Result { get; set; }

    }

    public class MarketStatsResult {
        
        [XmlElement("type")]
        public MarketStatItem[] Items { get; set; }
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
