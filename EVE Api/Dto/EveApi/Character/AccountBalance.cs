using System;
using System.Xml.Serialization;

namespace eZet.Eve.EveApi.Dto.EveApi.Character {

    public class AccountBalance : XmlResult {

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