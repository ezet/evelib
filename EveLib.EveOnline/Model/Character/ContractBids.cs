using System;
using System.Xml.Serialization;

namespace eZet.EveLib.EveOnline.Model.Character {
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class ContractBids {
        [XmlElement("rowset")]
        public RowCollection<Bid> Bids { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class Bid {
            [XmlAttribute("bidID")]
            public long BidId { get; set; }

            [XmlAttribute("contractID")]
            public long ContractId { get; set; }

            [XmlAttribute("bidderID")]
            public long BidderId { get; set; }

            [XmlIgnore]
            public DateTime BidDate { get; private set; }

            [XmlAttribute("dateBid")]
            public string BidDateAsString {
                get { return BidDate.ToString(XmlHelper.DateFormat); }
                set { BidDate = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
            }

            [XmlAttribute("amount")]
            public decimal Amount { get; set; }
        }
    }
}