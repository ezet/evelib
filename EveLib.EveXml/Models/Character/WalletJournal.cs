// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="WalletJournal.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Xml.Serialization;
using eZet.EveLib.EveXmlModule.Util;

namespace eZet.EveLib.EveXmlModule.Models.Character {
    /// <summary>
    ///     Class WalletJournal.
    /// </summary>
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class WalletJournal {
        /// <summary>
        ///     Gets or sets the journal.
        /// </summary>
        /// <value>The journal.</value>
        [XmlElement("rowset")]
        public EveXmlRowCollection<JournalEntry> Journal { get; set; }

        /// <summary>
        ///     Class JournalEntry.
        /// </summary>
        [Serializable]
        [XmlRoot("row")]
        public class JournalEntry {
            /// <summary>
            ///     Gets the date.
            /// </summary>
            /// <value>The date.</value>
            [XmlIgnore]
            public DateTime Date { get; private set; }

            /// <summary>
            ///     Gets or sets the date as string.
            /// </summary>
            /// <value>The date as string.</value>
            [XmlAttribute("date")]
            public string DateAsString {
                get { return Date.ToString(XmlHelper.DateFormat); }
                set { Date = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
            }

            /// <summary>
            ///     Gets or sets the reference identifier.
            /// </summary>
            /// <value>The reference identifier.</value>
            [XmlAttribute("refID")]
            public long RefId { get; set; }

            /// <summary>
            ///     Gets or sets the reference type identifier.
            /// </summary>
            /// <value>The reference type identifier.</value>
            [XmlAttribute("refTypeID")]
            public int RefTypeId { get; set; }

            /// <summary>
            ///     Gets or sets the name of the owner.
            /// </summary>
            /// <value>The name of the owner.</value>
            [XmlAttribute("ownerName1")]
            public string OwnerName { get; set; }

            /// <summary>
            ///     Gets or sets the owner identifier.
            /// </summary>
            /// <value>The owner identifier.</value>
            [XmlAttribute("ownerID1")]
            public long OwnerId { get; set; }

            /// <summary>
            ///     Gets or sets the name of the participant.
            /// </summary>
            /// <value>The name of the participant.</value>
            [XmlAttribute("ownerName2")]
            public string ParticipantName { get; set; }

            /// <summary>
            ///     Gets or sets the participant identifier.
            /// </summary>
            /// <value>The participant identifier.</value>
            [XmlAttribute("ownerID2")]
            public long ParticipantId { get; set; }

            /// <summary>
            ///     Gets or sets the name of the argument.
            /// </summary>
            /// <value>The name of the argument.</value>
            [XmlAttribute("argName1")]
            public string ArgumentName { get; set; }

            /// <summary>
            ///     Gets or sets the argument identifier.
            /// </summary>
            /// <value>The argument identifier.</value>
            [XmlAttribute("argID1")]
            public long ArgumentId { get; set; }

            /// <summary>
            ///     Gets or sets the amount.
            /// </summary>
            /// <value>The amount.</value>
            [XmlAttribute("amount")]
            public decimal Amount { get; set; }

            /// <summary>
            ///     Gets or sets the balance after.
            /// </summary>
            /// <value>The balance after.</value>
            [XmlAttribute("balance")]
            public decimal BalanceAfter { get; set; }

            /// <summary>
            ///     Gets or sets the reason.
            /// </summary>
            /// <value>The reason.</value>
            [XmlAttribute("reason")]
            public string Reason { get; set; }

            /// <summary>
            ///     Gets or sets the tax receiver identifier.
            /// </summary>
            /// <value>The tax receiver identifier.</value>
            [XmlAttribute("taxReceiverID")]
            public string TaxReceiverId { get; set; }

            /// <summary>
            ///     Gets or sets the tax amount.
            /// </summary>
            /// <value>The tax amount.</value>
            [XmlAttribute("taxAmount")]
            public string TaxAmount { get; set; }

            /// <summary>
            ///     Gets or sets the owner type identifier.
            /// </summary>
            /// <value>The owner type identifier.</value>
            [XmlAttribute("owner1TypeID")]
            public int OwnerTypeId { get; set; }

            /// <summary>
            ///     Gets or sets the participant type identifier.
            /// </summary>
            /// <value>The participant type identifier.</value>
            [XmlAttribute("owner2TypeID")]
            public int ParticipantTypeId { get; set; }
        }
    }
}