using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace eZet.Eve.EveLib.Model.EveApi {

    [Serializable]
    [XmlRoot("eveapi", IsNullable = false)]
    public class XmlResponse<T> : XmlElement, IXmlSerializable where T : new() {

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

        [XmlElement("error")]
        public Error Error { get; set; }

        public XmlSchema GetSchema() {
            throw new NotImplementedException();
        }

        public void ReadXml(XmlReader reader) {
            setRoot(reader);
            Version = getIntAttribute("version");
            CurrentTimeAsString = getString("currentTime");
            CachedUntilAsString = getString("cachedUntil");
            Result = deserialize(getReader("result"), new T());
            Error = deserialize(getReader("error"), new Error());
        }

        public void WriteXml(XmlWriter writer) {
            throw new NotImplementedException();
        }
    }

    [Serializable]
    [XmlRoot("error", IsNullable = false)]
    public class Error {
        
        [XmlAttribute("code")]
        public int ErrorCode { get; set; }

        [XmlText]
        public string ErrorText { get; set; }
        
    }
}