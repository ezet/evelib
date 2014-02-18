using System.Xml.Serialization;

namespace eZet.Eve.EveApi.Dto.EveApi.Account {

    [System.SerializableAttribute]
    [System.Diagnostics.DebuggerStepThroughAttribute]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    public class AccountStatus : XmlResult {

        [XmlElement("paidUntil")]
        public string PaidUntil { get; set; }

        [XmlElement("createDate")]
        public string CreationDate { get; set; }

        [XmlElement("logonCount")]
        public int LogonCount { get; set; }

        [XmlElement("logonMinutes")]
        public int LogonMinutes { get; set; }


    }
}