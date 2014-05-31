using System;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace eZet.EveLib.Modules.Models {
    [Serializable]
    [XmlType(AnonymousType = true)]
    [XmlRoot(ElementName = "evec_api", Namespace = "", IsNullable = false)]
    public class EveCentralQuickLookResponse : EveCentralResponse {
        [XmlElement("quicklook")]
        public QuicklookResult Result { get; set; }
    }

    public class QuicklookResult {
        [XmlElement("item")]
        public int TypeId { get; set; }

        [XmlElement("itemname")]
        public string TypeName { get; set; }

        [XmlElement("hours")]
        public int HourLimit { get; set; }

        [XmlElement("minqty")]
        public int MinQuantity { get; set; }

        [XmlArray("regions"), XmlArrayItem("region")]
        public Collection<string> Regions { get; set; }

        [XmlArray("sell_orders"), XmlArrayItem("order")]
        public Collection<EveCentralQuicklookOrder> SellOrders { get; set; }

        [XmlArray("buy_orders"), XmlArrayItem("order")]
        public Collection<EveCentralQuicklookOrder> BuyOrders { get; set; }
    }

    public class EveCentralQuicklookOrder {
        [XmlAttribute("id")]
        public long OrderId { get; set; }

        [XmlElement("region")]
        public int RegionId { get; set; }

        [XmlElement("station")]
        public int StationId { get; set; }

        [XmlElement("station_name")]
        public string StationName { get; set; }

        [XmlElement("security")]
        public double SecurityRating { get; set; }

        [XmlElement("range")]
        public int Range { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }

        [XmlElement("vol_remain")]
        public int VolRemaining { get; set; }

        [XmlElement("min_volume")]
        public int MinVolume { get; set; }

        [XmlElement("expires")]
        public DateTime Expires { get; set; }

        [XmlElement("reported_time")]
        public string ReportedTime { get; set; }
    }
}