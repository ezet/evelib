using System;
using System.Linq;
using System.Xml.Serialization;

namespace eZet.Eve.EveLib.Model.EveApi.Character {

    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class WalletTransactions : XmlElement {

        internal delegate XmlResponse<WalletTransactions> CorpWalletTransactionWalker(int division = 1000, int count = 1000, long fromId = 0);

        internal CorpWalletTransactionWalker CorpWalker;

        internal delegate XmlResponse<WalletTransactions> CharWalletTransactionWalker(int count = 1000, long fromId = 0);

        internal CharWalletTransactionWalker CharWalker;

        internal int Division;

        [XmlElement("rowset")]
        public XmlRowSet<Transaction> Transactions { get; set; }

        public XmlResponse<WalletTransactions> GetOlder(int count = 1000) {
            var lastId = Transactions.OrderBy(t => t.TransactionId).First().TransactionId;
            return CharWalker != null ? CharWalker.Invoke(count, lastId) : CorpWalker.Invoke(Division, count, lastId);
        }

        [Serializable]
        [XmlRoot("row")]
        public class Transaction {


            [XmlIgnore]
            public DateTime TransactionDate { get; private set; }

            [XmlAttribute("transactionDateTime")]
            public string TransactionDateAsString {
                get { return TransactionDate.ToString(DateFormat); }
                set { TransactionDate = DateTime.ParseExact(value, DateFormat, null); }
            }

            [XmlAttribute("transactionID")]
            public long TransactionId { get; set; }

            [XmlAttribute("quantity")]
            public int Quantity { get; set; }

            [XmlAttribute("typeName")]
            public string TypeName { get; set; }

            [XmlAttribute("typeID")]
            public long TypeId { get; set; }

            [XmlAttribute("price")]
            public decimal Price { get; set; }

            [XmlAttribute("cliendID")]
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

        }

    }


}