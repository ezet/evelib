// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="AccountBalance.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Xml.Serialization;

namespace eZet.EveLib.Modules.Models.Character {
    /// <summary>
    /// Class AccountBalance.
    /// </summary>
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class AccountBalance {
        /// <summary>
        /// Gets or sets the accounts.
        /// </summary>
        /// <value>The accounts.</value>
        [XmlElement("rowset")]
        public EveOnlineRowCollection<AccountBalanceRow> Accounts { get; set; }
    }

    /// <summary>
    /// Class AccountBalanceRow.
    /// </summary>
    [Serializable]
    [XmlRoot("row")]
    public class AccountBalanceRow {
        /// <summary>
        /// Gets or sets the account identifier.
        /// </summary>
        /// <value>The account identifier.</value>
        [XmlAttribute("accountID")]
        public int AccountId { get; set; }

        /// <summary>
        /// Gets or sets the account key.
        /// </summary>
        /// <value>The account key.</value>
        [XmlAttribute("accountKey")]
        public int AccountKey { get; set; }

        /// <summary>
        /// Gets or sets the balance.
        /// </summary>
        /// <value>The balance.</value>
        [XmlAttribute("balance")]
        public decimal Balance { get; set; }
    }
}