using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace eZet.Eve.EoLib.Dto.EveCentral {

    [Serializable]
    [System.Diagnostics.DebuggerStepThroughAttribute]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(ElementName = "evec_api", Namespace = "", IsNullable = false)]
    public class QuicklookResponse : XmlResponse {

        [XmlElement("quicklook")]
        public QuicklookResult Result { get; set; }

    }

    public class QuicklookResult {

        [XmlElement("item")]
        public long TypeId { get; set; }

        [XmlElement("itemname")]
        public string TypeName { get; set; }

        [XmlElement("regions")]
        public string Regions { get; set; }

        [XmlElement("hours")]
        public int Hours { get; set; }

        [XmlElement("minqty")]
        public int MinQuantity { get; set; }

        [XmlElement("sell_orders")]
        public QuicklookData SellOrders { get; set; }

        [XmlElement("buy_orders")]
        public QuicklookData BuyOrders { get; set; }

    }

    public class QuicklookData {

        [XmlElement("order")]
        public List<QuicklookOrder> Orders { get; set; }

    }

    public class QuicklookOrder {
        [XmlAttribute("id")]
        public long OrderId { get; set; }

        [XmlElement("region")]
        public long RegionId { get; set; }

        [XmlElement("station")]
        public long StationId { get; set; }

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
