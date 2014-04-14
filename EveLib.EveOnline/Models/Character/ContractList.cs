using System;
using System.Xml.Serialization;
using eZet.EveLib.Modules.Util;

namespace eZet.EveLib.Modules.Models.Character {
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class ContractList {
        public enum AvailabilityType {
            Public,
            Private
        }

        public enum ContractStatus {
            Outstanding,
            Deleted,
            Completed,
            Failed,
            CompletedByIssuer,
            CompletedByContractor,
            Cancelled,
            Rejected,
            Reversed,
            InProgress
        }

        [XmlElement("rowset")]
        public EveOnlineRowCollection<Contract> Contracts { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class Contract {
            [XmlAttribute("contractID")]
            public long ContractId { get; set; }

            [XmlAttribute("issuerID")]
            public long IssuerId { get; set; }

            [XmlAttribute("issuerCorpID")]
            public long IssuerCorpId { get; set; }

            [XmlAttribute("assigneeID")]
            public long AssigneeId { get; set; }

            [XmlAttribute("acceptorID")]
            public long AcceptorId { get; set; }

            [XmlAttribute("startStationID")]
            public long StartStationId { get; set; }

            [XmlAttribute("endStationID")]
            public long EndStationId { get; set; }

            [XmlAttribute("type")]
            public string Type { get; set; }

            [XmlAttribute("status")]
            public ContractStatus Status { get; set; }

            [XmlAttribute("title")]
            public string Title { get; set; }

            [XmlAttribute("forCorp")]
            public bool IsCorporationContract { get; set; }

            [XmlAttribute("availability")]
            public AvailabilityType Availability { get; set; }

            [XmlIgnore]
            public DateTime? DateIssued { get; private set; }

            [XmlAttribute("dateIssued")]
            public string DateIssuedAsString {
                get { return DateIssued.HasValue ? ((DateTime) DateIssued).ToString(XmlHelper.DateFormat) : ""; }
                set {
                    DateIssued = value != "" ? DateTime.ParseExact(value, XmlHelper.DateFormat, null) : (DateTime?) null;
                }
            }

            [XmlIgnore]
            public DateTime? DateExpired { get; private set; }

            [XmlAttribute("dateExpired")]
            public string DateExpiredAsString {
                get { return DateExpired.HasValue ? ((DateTime) DateExpired).ToString(XmlHelper.DateFormat) : ""; }
                set {
                    DateExpired = value != "" ? DateTime.ParseExact(value, XmlHelper.DateFormat, null) : (DateTime?) null;
                }
            }

            [XmlIgnore]
            public DateTime? DateAccepted { get; private set; }

            [XmlAttribute("dateAccepted")]
            public string DateAcceptedAsString {
                get { return DateAccepted.HasValue ? ((DateTime) DateAccepted).ToString(XmlHelper.DateFormat) : ""; }
                set {
                    DateAccepted = value != ""
                        ? DateTime.ParseExact(value, XmlHelper.DateFormat, null)
                        : (DateTime?) null;
                }
            }

            [XmlAttribute("numDays")]
            public int NumDays { get; set; }

            [XmlIgnore]
            public DateTime? DateCompleted { get; private set; }

            [XmlAttribute("dateCompleted")]
            public string DateCompletedAsString {
                get { return DateCompleted.HasValue ? ((DateTime) DateCompleted).ToString(XmlHelper.DateFormat) : ""; }
                set {
                    DateCompleted = value != ""
                        ? DateTime.ParseExact(value, XmlHelper.DateFormat, null)
                        : (DateTime?) null;
                }
            }

            [XmlAttribute("price")]
            public decimal Price { get; set; }

            [XmlAttribute("reward")]
            public decimal Reward { get; set; }

            [XmlAttribute("collateral")]
            public decimal Collateral { get; set; }

            [XmlAttribute("buyout")]
            public decimal Buyout { get; set; }

            [XmlAttribute("volume")]
            public double Volume { get; set; }
        }
    }
}