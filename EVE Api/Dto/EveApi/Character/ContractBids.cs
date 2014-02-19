using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace eZet.Eve.EveApi.Dto.EveApi.Character {
    public class ContractBids : XmlResult {

        [XmlElement("rowset")]
        public XmlRowSet<Bid> Bids { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class Bid {

            [XmlAttribute("bidID")]
            public long BidId { get; set; }

            [XmlAttribute("contractID")]
            public long ContractId { get; set; }

            [XmlAttribute("bidderID")]
            public long BidderId { get; set; }

            [XmlAttribute("dateBid")]
            public DateTime BidDate { get; set; }

            [XmlAttribute("amount")]
            public decimal Amount { get; set; }

        }
    }
}
