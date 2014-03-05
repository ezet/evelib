using System;
using System.Xml.Serialization;

namespace eZet.Eve.EveLib.Model.EveApi {
    [Serializable]
    [XmlRoot("eveapi", IsNullable = false)]
    public class EveApiResponse<T> : XmlElement {
        [XmlIgnore]
        public DateTime CurrentTime { get; private set; }

        [XmlElement("currentTime")]
        public string CurrentTimeAsString {
            get { return CurrentTime.ToString(DateFormat); }
            set { CurrentTime = DateTime.ParseExact(value, DateFormat, null); }
        }

        [XmlElement("result")]
        public T Result { get; set; }

        [XmlIgnore]
        public DateTime CachedUntil { get; set; }

        [XmlElement("cachedUntil")]
        public string CachedUntilAsString {
            get { return CachedUntil.ToString(DateFormat); }
            set { CachedUntil = DateTime.ParseExact(value, DateFormat, null); }
        }

        [XmlAttribute("version")]
        public int Version { get; set; }
    }
}