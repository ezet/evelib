using System;
using System.Linq;
using System.Xml.Serialization;

namespace eZet.EveLib.EveOnlineLib.Model.Character {
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class WalletJournal : XmlElement {
        internal CharWalletJournalWalker CharWalker;

        internal CorpWalletJournalWalker CorpWalker;


        internal int Division;

        [XmlElement("rowset")]
        public XmlRowSet<JournalEntry> Journal { get; set; }

        public EveApiResponse<WalletJournal> GetOlder(int count = 1000) {
            long lastId = Journal.OrderBy(t => t.RefId).First().RefId;
            return CharWalker != null ? CharWalker.Invoke(count, lastId) : CorpWalker.Invoke(Division, count, lastId);
        }

        internal delegate EveApiResponse<WalletJournal> CharWalletJournalWalker(int count, long fromId);

        internal delegate EveApiResponse<WalletJournal> CorpWalletJournalWalker(int division, int count, long fromId);

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