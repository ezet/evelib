using System;
using System.Xml.Serialization;

namespace eZet.EveLib.EveOnlineLib.Model.Character {
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class AccountBalance : XmlElement {
        [XmlElement("rowset")]
        public XmlRowSet<AccountBalanceRow> Accounts { get; set; }
    }

    [Serializable]
    [XmlRoot("row")]
    public class AccountBalanceRow {
        [XmlAttribute("accountID")]
        public long AccountId { get; set; }

        [XmlAttribute("accountKey")]
        public int AccountKey { get; set; }

        [XmlAttribute("balance")]
        public decimal Balance { get; set; }
    }
}