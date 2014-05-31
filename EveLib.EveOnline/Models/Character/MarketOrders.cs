using System;
using System.Xml.Serialization;
using eZet.EveLib.Modules.Util;

namespace eZet.EveLib.Modules.Models.Character {
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class MarketOrders {
        [XmlElement("rowset")]
        public EveOnlineRowCollection<MarketOrder> Orders { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class MarketOrder {
            [XmlAttribute("orderID")]
            public long OrderId { get; set; }

            [XmlAttribute("charID")]
            public long CharacterId { get; set; }

            [XmlAttribute("stationID")]
            public int StationId { get; set; }

            [XmlAttribute("volEntered")]
            public int VolumeEntered { get; set; }

            [XmlAttribute("volRemaining")]
            public int VolumeRemaining { get; set; }

            [XmlAttribute("minVolume")]
            public int MinVolume { get; set; }

            [XmlAttribute("orderState")]
            public int OrderState { get; set; }

            [XmlAttribute("typeID")]
            public int TypeId { get; set; }

            [XmlAttribute("range")]
            public int Range { get; set; }

            [XmlAttribute("accountKey")]
            public int AccountKey { get; set; }

            [XmlAttribute("duration")]
            public int Duration { get; set; }

            [XmlAttribute("escrow")]
            public decimal Escrow { get; set; }

            [XmlAttribute("price")]
            public decimal Price { get; set; }

            [XmlAttribute("bid")]
            public int Bid { get; set; }

            [XmlIgnore]
            public DateTime IssuedDate { get; private set; }

            [XmlAttribute("issued")]
            public string IssuedDateAsString {
                get { return IssuedDate.ToString(XmlHelper.DateFormat); }
                set { IssuedDate = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
            }
        }
    }
}