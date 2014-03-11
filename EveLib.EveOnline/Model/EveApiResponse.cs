using System;
using System.Xml.Serialization;

namespace eZet.EveLib.EveOnline.Model {
    [Serializable]
    [XmlRoot("eveapi", IsNullable = false)]
    public class EveApiResponse<T> {
        [XmlIgnore]
        public DateTime CurrentTime { get; private set; }

        [XmlElement("currentTime")]
        public string CurrentTimeAsString {
            get { return CurrentTime.ToString(XmlHelper.DateFormat); }
            set { CurrentTime = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
        }

        [XmlElement("result")]
        public T Result { get; set; }

        [XmlIgnore]
        public DateTime CachedUntil { get; set; }

        [XmlElement("cachedUntil")]
        public string CachedUntilAsString {
            get { return CachedUntil.ToString(XmlHelper.DateFormat); }
            set { CachedUntil = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
        }

        [XmlAttribute("version")]
        public int Version { get; set; }
    }
}