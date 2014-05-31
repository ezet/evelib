using System;
using System.Linq;
using System.Xml.Serialization;
using eZet.EveLib.Modules.Util;

namespace eZet.EveLib.Modules.Models.Character {
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class WalletTransactions {
        internal CharWalletTransactionWalker CharWalker;
        internal CorpWalletTransactionWalker CorpWalker;

        internal int Division;

        [XmlElement("rowset")]
        public EveOnlineRowCollection<Transaction> Transactions { get; set; }

        public EveApiResponse<WalletTransactions> GetOlder(int count = 1000) {
            var transaction = Transactions.OrderBy(t => t.TransactionId).FirstOrDefault();
            long lastId = transaction != null ? transaction.TransactionId : 0;
            return CharWalker != null ? CharWalker.Invoke(count, lastId) : CorpWalker.Invoke(Division, count, lastId);
        }

        internal delegate EveApiResponse<WalletTransactions> CharWalletTransactionWalker(
            int count = 1000, long fromId = 0);

        internal delegate EveApiResponse<WalletTransactions> CorpWalletTransactionWalker(
            int division = 1000, int count = 1000, long fromId = 0);

        [Serializable]
        [XmlRoot("row")]
        public class Transaction {
            [XmlIgnore]
            public DateTime TransactionDate { get; private set; }

            [XmlAttribute("transactionDateTime")]
            public string TransactionDateAsString {
                get { return TransactionDate.ToString(XmlHelper.DateFormat); }
                set { TransactionDate = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
            }

            [XmlAttribute("transactionID")]
            public long TransactionId { get; set; }

            [XmlAttribute("quantity")]
            public int Quantity { get; set; }

            [XmlAttribute("typeName")]
            public string TypeName { get; set; }

            [XmlAttribute("typeID")]
            public int TypeId { get; set; }

            [XmlAttribute("price")]
            public decimal Price { get; set; }

            [XmlAttribute("clientID")]
            public long ClientId { get; set; }

            [XmlAttribute("clientName")]
            public string ClientName { get; set; }

            [XmlAttribute("stationID")]
            public int StationId { get; set; }

            [XmlAttribute("stationName")]
            public string StationName { get; set; }

            [XmlAttribute("transactionType")]
            public OrderType TransactionType { get; set; }

            [XmlAttribute("transactionFor")]
            public string TransactionFor { get; set; }

            [XmlAttribute("journalTransactionID")]
            public long JournalTransactionId { get; set; }

            [XmlAttribute("clientTypeID")]
            public int ClientTypeId { get; set; }


        }
    }
}