using System;
using System.Xml.Serialization;

namespace eZet.EveLib.Modules.Models.Character {
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class AccountBalance {
        [XmlElement("rowset")]
        public EveOnlineRowCollection<AccountBalanceRow> Accounts { get; set; }
    }

    [Serializable]
    [XmlRoot("row")]
    public class AccountBalanceRow {
        [XmlAttribute("accountID")]
        public int AccountId { get; set; }

        [XmlAttribute("accountKey")]
        public int AccountKey { get; set; }

        [XmlAttribute("balance")]
        public decimal Balance { get; set; }
    }
}