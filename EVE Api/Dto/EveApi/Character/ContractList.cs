using System;
using System.Xml.Serialization;

namespace eZet.Eve.EveApi.Dto.EveApi.Character {
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

            // TODO Convert to DateTime
            [XmlAttribute("dateIssued")]
            public string DateIssued { get; set; }
            
            [XmlAttribute("dateExpired")]
            public string DateExpired { get; set; }

            [XmlAttribute("dateAccepted")]
            public string DateAccepted { get; set; }

            [XmlAttribute("numDays")]
            public int NumDays { get; set; }

            [XmlAttribute("dateCompleted")]
            public string DateCompleted { get; set; }

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
