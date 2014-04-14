using System;
using System.Xml.Serialization;
using eZet.EveLib.Modules.Util;

namespace eZet.EveLib.Modules.Models {
    [Serializable]
    [XmlRoot("eveapi", IsNullable = false)]
    public class EveApiError {
        [XmlIgnore]
        public DateTime CurrentTime { get; private set; }

        [XmlElement("currentTime")]
        public string CurrentTimeAsString {
            get { return CurrentTime.ToString(XmlHelper.DateFormat); }
            set { CurrentTime = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
        }

        [XmlElement("error")]
        public ErrorData Error { get; set; }

        [XmlIgnore]
        public DateTime CachedUntil { get; set; }

        [XmlElement("cachedUntil")]
        public string CachedUntilAsString {
            get { return CachedUntil.ToString(XmlHelper.DateFormat); }
            set { CachedUntil = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
        }

        [XmlAttribute("version")]
        public int Version { get; set; }

        public class ErrorData {
            [XmlAttribute("code")]
            public int ErrorCode { get; set; }

            [XmlText]
            public string ErrorText { get; set; }
        }
    }
}