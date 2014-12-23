// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="WalletTransactions.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Xml.Serialization;
using eZet.EveLib.EveXmlModule.Util;

namespace eZet.EveLib.EveXmlModule.Models.Character {
    /// <summary>
    ///     Class WalletTransactions.
    /// </summary>
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class WalletTransactions {
        /// <summary>
        ///     Gets or sets the transactions.
        /// </summary>
        /// <value>The transactions.</value>
        [XmlElement("rowset")]
        public EveXmlRowCollection<Transaction> Transactions { get; set; }

        /// <summary>
        ///     Class Transaction.
        /// </summary>
        [Serializable]
        [XmlRoot("row")]
        public class Transaction {
            /// <summary>
            ///     Gets the transaction date.
            /// </summary>
            /// <value>The transaction date.</value>
            [XmlIgnore]
            public DateTime TransactionDate { get; private set; }

            /// <summary>
            ///     Gets or sets the transaction date as string.
            /// </summary>
            /// <value>The transaction date as string.</value>
            [XmlAttribute("transactionDateTime")]
            public string TransactionDateAsString {
                get { return TransactionDate.ToString(XmlHelper.DateFormat); }
                set { TransactionDate = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
            }

            /// <summary>
            ///     Gets or sets the transaction identifier.
            /// </summary>
            /// <value>The transaction identifier.</value>
            [XmlAttribute("transactionID")]
            public long TransactionId { get; set; }

            /// <summary>
            ///     Gets or sets the quantity.
            /// </summary>
            /// <value>The quantity.</value>
            [XmlAttribute("quantity")]
            public int Quantity { get; set; }

            /// <summary>
            ///     Gets or sets the name of the type.
            /// </summary>
            /// <value>The name of the type.</value>
            [XmlAttribute("typeName")]
            public string TypeName { get; set; }

            /// <summary>
            ///     Gets or sets the type identifier.
            /// </summary>
            /// <value>The type identifier.</value>
            [XmlAttribute("typeID")]
            public int TypeId { get; set; }

            /// <summary>
            ///     Gets or sets the price.
            /// </summary>
            /// <value>The price.</value>
            [XmlAttribute("price")]
            public decimal Price { get; set; }

            /// <summary>
            ///     Gets or sets the client identifier.
            /// </summary>
            /// <value>The client identifier.</value>
            [XmlAttribute("clientID")]
            public long ClientId { get; set; }

            /// <summary>
            ///     Gets or sets the name of the client.
            /// </summary>
            /// <value>The name of the client.</value>
            [XmlAttribute("clientName")]
            public string ClientName { get; set; }

            /// <summary>
            ///     Gets or sets the station identifier.
            /// </summary>
            /// <value>The station identifier.</value>
            [XmlAttribute("stationID")]
            public int StationId { get; set; }

            /// <summary>
            ///     Gets or sets the name of the station.
            /// </summary>
            /// <value>The name of the station.</value>
            [XmlAttribute("stationName")]
            public string StationName { get; set; }

            /// <summary>
            ///     Gets or sets the type of the transaction.
            /// </summary>
            /// <value>The type of the transaction.</value>
            [XmlAttribute("transactionType")]
            public OrderType TransactionType { get; set; }

            /// <summary>
            ///     Gets or sets the transaction for.
            /// </summary>
            /// <value>The transaction for.</value>
            [XmlAttribute("transactionFor")]
            public string TransactionFor { get; set; }

            /// <summary>
            ///     Gets or sets the journal transaction identifier.
            /// </summary>
            /// <value>The journal transaction identifier.</value>
            [XmlAttribute("journalTransactionID")]
            public long JournalTransactionId { get; set; }

            /// <summary>
            ///     Gets or sets the client type identifier.
            /// </summary>
            /// <value>The client type identifier.</value>
            [XmlAttribute("clientTypeID")]
            public int ClientTypeId { get; set; }
        }
    }
}