using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace eZet.Eve.EveApi.Dto {

    [Serializable]
    [XmlRoot("row")]
    public class TransactionDto {

        [XmlAttribute("transactionDateTime")]
        public string DateTime { get; set; }

        [XmlAttribute("transactionID")]
        public long TransactionId { get; set; }

        [XmlAttribute("quantity")]
        public int Quantity { get; set; }

        [XmlAttribute("typeName")]
        public string Name { get; set; }

        [XmlAttribute("price")]
        public double Price { get; set; }

        [XmlAttribute("clientID")]
        public long ClientId { get; set; }

        [XmlAttribute("clientName")]
        public string ClientName { get; set; }

        [XmlAttribute("stationID")]
        public long StationId { get; set; }

        [XmlAttribute("stationName")]
        public string StationName { get; set; }

        [XmlAttribute("transactionType")]
        public string TransactionType { get; set; }

        [XmlAttribute("transactionFor")]
        public string TransactionFor { get; set; }

        [XmlAttribute("journalTransactionID")]
        public string JournalTransactionId { get; set; }

    }
}
