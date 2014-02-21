using System;
using System.Xml.Serialization;

namespace eZet.Eve.EolNet.Dto.EveApi.Character {
    public class ContractList : XmlResult {

        [XmlElement("rowset")]
        public XmlRowSet<Contract> Contracts { get; set; }

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
            public DateTime DateIssued { get; private set; }

            [XmlAttribute("dateIssued")]
            public string DateIssuedAsString {
                get { return DateIssued.ToString(DateFormat); }
                set { DateIssued = DateTime.ParseExact(value, DateFormat, null); }
            }

            [XmlIgnore]
            public DateTime DateExpired { get; private set; }
            
            [XmlAttribute("dateExpired")]
            public string DateExpiredAsString {
                get { return DateExpired.ToString(DateFormat); }
                set { DateExpired = DateTime.ParseExact(value, DateFormat, null); }
            }

            [XmlIgnore]
            public DateTime DateAccepted { get; private set; }

            [XmlAttribute("dateAccepted")]
            public string DateAcceptedAsString {
                get { return DateAccepted.ToString(DateFormat); }
                set { DateAccepted = DateTime.ParseExact(value, DateFormat, null); }
            }

            [XmlAttribute("numDays")]
            public int NumDays { get; set; }

            [XmlIgnore]
            public DateTime DateCompleted { get; private set; }

            [XmlAttribute("dateCompleted")]
            public string DateCompletedAsString {
                get { return DateCompleted.ToString(DateFormat); }
                set { DateCompleted = DateTime.ParseExact(value, DateFormat, null); }
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

        public enum AvailabilityType {
            Public, Private
        }
    }
}
