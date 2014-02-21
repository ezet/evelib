using System;
using System.Xml.Serialization;

namespace eZet.Eve.EolNet.Dto.EveApi.Character {
    public class WalletJournal : XmlResult {

        [XmlElement("rowset")]
        public XmlRowSet<JournalEntry> Journal { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class JournalEntry {

            [XmlIgnore]
            public DateTime Date { get; private set; }
            
            [XmlAttribute("date")]
            public string DateAsString {
                get { return Date.ToString(DateFormat); }
                set { Date = DateTime.ParseExact(value, DateFormat, null); }
            }

            [XmlAttribute("refID")]
            public long RefId { get; set; }

            [XmlAttribute("refTypeID")]
            public long refTypeId { get; set; }

            [XmlAttribute("ownerName1")]
            public string OwnerName { get; set; }

            [XmlAttribute("ownerID1")]
            public long OwnerId { get; set; }

            [XmlAttribute("ownerName2")]
            public string ParticipantName { get; set; }

            [XmlAttribute("ownerID2")]
            public long ParticipantId { get; set; }

            [XmlAttribute("argName1")]
            public string ArgumentName { get; set; }

            [XmlAttribute("argID1")]
            public long ArgumentId { get; set; }

            [XmlAttribute("amount")]
            public decimal Amount { get; set; }

            [XmlAttribute("balance")]
            public decimal BalanceAfter { get; set; }
            
            [XmlAttribute("reason")]
            public string Reason { get; set; }
           
            // TODO Convert to long
            [XmlAttribute("taxReceiverID")]
            public string TaxReceiverId { get; set; }

            // TODO Convert to decimal
            [XmlAttribute("taxAmount")]
            public string TaxAmount { get; set; }

        }

    }
}
