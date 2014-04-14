using System;
using System.Xml.Serialization;
using eZet.EveLib.Modules.Util;

namespace eZet.EveLib.Modules.Models.Account {
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class AccountStatus {
        [XmlIgnore]
        public DateTime PaidUntil { get; private set; }

        [XmlElement("paidUntil")]
        public string PaidUntilAsString {
            get { return PaidUntil.ToString(XmlHelper.DateFormat); }
            set { PaidUntil = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
        }

        [XmlIgnore]
        public DateTime CreationDate { get; private set; }

        [XmlElement("createDate")]
        public string CreationDateAsString {
            get { return CreationDate.ToString(XmlHelper.DateFormat); }
            set { CreationDate = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
        }

        [XmlElement("logonCount")]
        public int LogonCount { get; set; }

        [XmlElement("logonMinutes")]
        public int LogonMinutes { get; set; }
    }
}