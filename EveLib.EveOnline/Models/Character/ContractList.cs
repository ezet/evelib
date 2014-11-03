// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 11-02-2014
// ***********************************************************************
// <copyright file="ContractList.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Xml.Serialization;
using eZet.EveLib.Modules.Util;

namespace eZet.EveLib.Modules.Models.Character {
    /// <summary>
    /// Class ContractList.
    /// </summary>
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class ContractList {
        /// <summary>
        /// Enum AvailabilityType
        /// </summary>
        public enum AvailabilityType {
            /// <summary>
            /// The public
            /// </summary>
            Public,
            /// <summary>
            /// The private
            /// </summary>
            Private
        }

        /// <summary>
        /// Enum ContractStatus
        /// </summary>
        public enum ContractStatus {
            /// <summary>
            /// The outstanding
            /// </summary>
            Outstanding,
            /// <summary>
            /// The deleted
            /// </summary>
            Deleted,
            /// <summary>
            /// The completed
            /// </summary>
            Completed,
            /// <summary>
            /// The failed
            /// </summary>
            Failed,
            /// <summary>
            /// The completed by issuer
            /// </summary>
            CompletedByIssuer,
            /// <summary>
            /// The completed by contractor
            /// </summary>
            CompletedByContractor,
            /// <summary>
            /// The canceled
            /// </summary>
            Canceled,
            /// <summary>
            /// The rejected
            /// </summary>
            Rejected,
            /// <summary>
            /// The reversed
            /// </summary>
            Reversed,
            /// <summary>
            /// The in progress
            /// </summary>
            InProgress
        }

        /// <summary>
        /// Gets or sets the contracts.
        /// </summary>
        /// <value>The contracts.</value>
        [XmlElement("rowset")]
        public EveOnlineRowCollection<Contract> Contracts { get; set; }

        /// <summary>
        /// Class Contract.
        /// </summary>
        [Serializable]
        [XmlRoot("row")]
        public class Contract {
            /// <summary>
            /// Gets or sets the contract identifier.
            /// </summary>
            /// <value>The contract identifier.</value>
            [XmlAttribute("contractID")]
            public long ContractId { get; set; }

            /// <summary>
            /// Gets or sets the issuer identifier.
            /// </summary>
            /// <value>The issuer identifier.</value>
            [XmlAttribute("issuerID")]
            public long IssuerId { get; set; }

            /// <summary>
            /// Gets or sets the issuer corp identifier.
            /// </summary>
            /// <value>The issuer corp identifier.</value>
            [XmlAttribute("issuerCorpID")]
            public long IssuerCorpId { get; set; }

            /// <summary>
            /// Gets or sets the assignee identifier.
            /// </summary>
            /// <value>The assignee identifier.</value>
            [XmlAttribute("assigneeID")]
            public long AssigneeId { get; set; }

            /// <summary>
            /// Gets or sets the acceptor identifier.
            /// </summary>
            /// <value>The acceptor identifier.</value>
            [XmlAttribute("acceptorID")]
            public long AcceptorId { get; set; }

            /// <summary>
            /// Gets or sets the start station identifier.
            /// </summary>
            /// <value>The start station identifier.</value>
            [XmlAttribute("startStationID")]
            public long StartStationId { get; set; }

            /// <summary>
            /// Gets or sets the end station identifier.
            /// </summary>
            /// <value>The end station identifier.</value>
            [XmlAttribute("endStationID")]
            public long EndStationId { get; set; }

            /// <summary>
            /// Gets or sets the type.
            /// </summary>
            /// <value>The type.</value>
            [XmlAttribute("type")]
            public string Type { get; set; }

            /// <summary>
            /// Gets or sets the status.
            /// </summary>
            /// <value>The status.</value>
            [XmlAttribute("status")]
            public ContractStatus Status { get; set; }

            /// <summary>
            /// Gets or sets the title.
            /// </summary>
            /// <value>The title.</value>
            [XmlAttribute("title")]
            public string Title { get; set; }

            /// <summary>
            /// Gets or sets a value indicating whether this instance is corporation contract.
            /// </summary>
            /// <value><c>true</c> if this instance is corporation contract; otherwise, <c>false</c>.</value>
            [XmlAttribute("forCorp")]
            public bool IsCorporationContract { get; set; }

            /// <summary>
            /// Gets or sets the availability.
            /// </summary>
            /// <value>The availability.</value>
            [XmlAttribute("availability")]
            public AvailabilityType Availability { get; set; }

            /// <summary>
            /// Gets the date issued.
            /// </summary>
            /// <value>The date issued.</value>
            [XmlIgnore]
            public DateTime? DateIssued { get; private set; }

            /// <summary>
            /// Gets or sets the date issued as string.
            /// </summary>
            /// <value>The date issued as string.</value>
            [XmlAttribute("dateIssued")]
            public string DateIssuedAsString {
                get { return DateIssued.HasValue ? ((DateTime) DateIssued).ToString(XmlHelper.DateFormat) : ""; }
                set {
                    DateIssued = value != "" ? DateTime.ParseExact(value, XmlHelper.DateFormat, null) : (DateTime?) null;
                }
            }

            /// <summary>
            /// Gets the date expired.
            /// </summary>
            /// <value>The date expired.</value>
            [XmlIgnore]
            public DateTime? DateExpired { get; private set; }

            /// <summary>
            /// Gets or sets the date expired as string.
            /// </summary>
            /// <value>The date expired as string.</value>
            [XmlAttribute("dateExpired")]
            public string DateExpiredAsString {
                get { return DateExpired.HasValue ? ((DateTime) DateExpired).ToString(XmlHelper.DateFormat) : ""; }
                set {
                    DateExpired = value != "" ? DateTime.ParseExact(value, XmlHelper.DateFormat, null) : (DateTime?) null;
                }
            }

            /// <summary>
            /// Gets the date accepted.
            /// </summary>
            /// <value>The date accepted.</value>
            [XmlIgnore]
            public DateTime? DateAccepted { get; private set; }

            /// <summary>
            /// Gets or sets the date accepted as string.
            /// </summary>
            /// <value>The date accepted as string.</value>
            [XmlAttribute("dateAccepted")]
            public string DateAcceptedAsString {
                get { return DateAccepted.HasValue ? ((DateTime) DateAccepted).ToString(XmlHelper.DateFormat) : ""; }
                set {
                    DateAccepted = value != ""
                        ? DateTime.ParseExact(value, XmlHelper.DateFormat, null)
                        : (DateTime?) null;
                }
            }

            /// <summary>
            /// Gets or sets the number days.
            /// </summary>
            /// <value>The number days.</value>
            [XmlAttribute("numDays")]
            public int NumDays { get; set; }

            /// <summary>
            /// Gets the date completed.
            /// </summary>
            /// <value>The date completed.</value>
            [XmlIgnore]
            public DateTime? DateCompleted { get; private set; }

            /// <summary>
            /// Gets or sets the date completed as string.
            /// </summary>
            /// <value>The date completed as string.</value>
            [XmlAttribute("dateCompleted")]
            public string DateCompletedAsString {
                get { return DateCompleted.HasValue ? ((DateTime) DateCompleted).ToString(XmlHelper.DateFormat) : ""; }
                set {
                    DateCompleted = value != ""
                        ? DateTime.ParseExact(value, XmlHelper.DateFormat, null)
                        : (DateTime?) null;
                }
            }

            /// <summary>
            /// Gets or sets the price.
            /// </summary>
            /// <value>The price.</value>
            [XmlAttribute("price")]
            public decimal Price { get; set; }

            /// <summary>
            /// Gets or sets the reward.
            /// </summary>
            /// <value>The reward.</value>
            [XmlAttribute("reward")]
            public decimal Reward { get; set; }

            /// <summary>
            /// Gets or sets the collateral.
            /// </summary>
            /// <value>The collateral.</value>
            [XmlAttribute("collateral")]
            public decimal Collateral { get; set; }

            /// <summary>
            /// Gets or sets the buyout.
            /// </summary>
            /// <value>The buyout.</value>
            [XmlAttribute("buyout")]
            public decimal Buyout { get; set; }

            /// <summary>
            /// Gets or sets the volume.
            /// </summary>
            /// <value>The volume.</value>
            [XmlAttribute("volume")]
            public double Volume { get; set; }
        }
    }
}