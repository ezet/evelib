using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace eZet.Eve.EoLib.Dto.EveApi {

    [Serializable]
    [XmlRoot("eveapi", IsNullable = false)]
    public class XmlResponse<T> : XmlElement, IXmlSerializable where T : new() {

        [XmlIgnore]
        public DateTime CurrentTime { get; private set; }

        [XmlElement("currentTime")]
        public string CurrentTimeAsString {
            get { return CurrentTime.ToString(XmlElement.DateFormat); }
            set { CurrentTime = DateTime.ParseExact(value, XmlElement.DateFormat, null); }
        }

        //[XmlIgnore]
        [XmlElement("result")]
        public T Result { get; set; }

        [XmlIgnore]
        public DateTime CachedUntil { get; set; }

        [XmlElement("cachedUntil")]
        public string CachedUntilAsString {
            get { return CachedUntil.ToString(XmlElement.DateFormat); }
            set { CachedUntil = DateTime.ParseExact(value, XmlElement.DateFormat, null); }
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

            //throw new NotImplementedException();
        }

        public void WriteXml(XmlWriter writer) {
            throw new NotImplementedException();
        }
    }

    public class Error {
        
        [XmlAttribute("code")]
        public int ErrorCode { get; set; }

        [XmlText]
        public string ErrorText { get; set; }
        
    }
}