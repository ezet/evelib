using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using eZet.EveLib.Modules.Util;

namespace eZet.EveLib.Modules.Models {
    [Serializable]
    [XmlRoot("eveapi", IsNullable = false)]
    public class EveApiResponse<T> : IXmlSerializable {
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

        public XmlSchema GetSchema() {
            throw new NotImplementedException();
        }

        public void ReadXml(XmlReader reader) {
            var xml = new XmlHelper(reader);
            CurrentTimeAsString = xml.getString("currentTime");
            Result = xml.deserialize<T>("result");
            Version = xml.getIntAttribute("version");
            CachedUntilAsString = xml.getString("cachedUntil");
        }

        public void WriteXml(XmlWriter writer) {
            throw new NotImplementedException();
        }
    }
}