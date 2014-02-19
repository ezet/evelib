using System;
using System.Xml.Serialization;

namespace eZet.Eve.EveApi.Dto.EveApi.Character {


    [Serializable]
    [System.Diagnostics.DebuggerStepThroughAttribute]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    public class WalletTransactions : XmlResult {

        [XmlElement("rowset")]
        public XmlRowSet<Transaction> Transactions { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class Transaction {
            [XmlAttribute("transactionDateTime")]
            public string TransactionDateTime { get; set; }

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
            public string TransactioType { get; set; }

            [XmlAttribute("transactionFor")]
            public string TransactionFor { get; set; }

        }

    }


}