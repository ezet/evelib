using System.Xml.Serialization;



namespace eZet.Eve.EveApi.Dto.EveApi {


    [System.SerializableAttribute]
    [System.Diagnostics.DebuggerStepThroughAttribute]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    public class AccountBalance : XmlResult {

        [XmlElement("rowset")]
        public XmlRowSet<AccountBalanceRow> Accounts { get; set; }

    }


    [System.SerializableAttribute]
    [System.Diagnostics.DebuggerStepThroughAttribute]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    public class AccountBalanceRow {

        [XmlAttribute("accountID")]
        public long AccountId { get; set; }

        [XmlAttribute("accountKey")]
        public int AccountKey { get; set; }

        [XmlAttribute("balance")]
        public decimal Balance { get; set; }
    }
}