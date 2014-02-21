using System;
using System.Xml.Serialization;

namespace eZet.Eve.EolNet.Dto.EveApi.Account {

    [Serializable]
    [System.Diagnostics.DebuggerStepThroughAttribute]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    public class AccountStatus : XmlResult {

        [XmlIgnore]
        public DateTime PaidUntil { get; private set; }

        [XmlElement("paidUntil")]
        public string PaidUntilAsString {
            get { return PaidUntil.ToString(DateFormat); }
            set { PaidUntil = DateTime.ParseExact(value, DateFormat, null); }
        }

        [XmlIgnore]
        public DateTime CreationDate { get; private set; }

        [XmlElement("createDate")]
        public string CreationDateAsString {
            get { return CreationDate.ToString(DateFormat); }
            set { CreationDate = DateTime.ParseExact(value, DateFormat, null); }
        }

        [XmlElement("logonCount")]
        public int LogonCount { get; set; }

        [XmlElement("logonMinutes")]
        public int LogonMinutes { get; set; }


    }
}