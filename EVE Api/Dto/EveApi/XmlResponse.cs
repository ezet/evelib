using System;
using System.Xml.Serialization;
using eZet.Eve.EoLib.Dto.EveApi.Core;
using eZet.Eve.EoLib.Entity;

namespace eZet.Eve.EoLib.Dto.EveApi {

    [Serializable]
    [System.Diagnostics.DebuggerStepThroughAttribute]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot("eveapi", IsNullable = false)]
    public class XmlResponse<T> where T : XmlElement {

        [XmlIgnore]
        public DateTime CurrentTime { get; private set; }

        [XmlElement("currentTime")]
        public string CurrentTimeAsString {
            get { return CurrentTime.ToString(XmlElement.DateFormat); }
            set { CurrentTime = DateTime.ParseExact(value, XmlElement.DateFormat, null); }
        }

        [XmlElement("result")]
        public T Result { get; set; }

        [XmlIgnore]
        public DateTime CachedUntil { get; private set; }

        [XmlElement("cachedUntil")]
        public string CachedUntilAsString {
            get { return CachedUntil.ToString(XmlElement.DateFormat); }
            set { CachedUntil = DateTime.ParseExact(value, XmlElement.DateFormat, null); }
        }

        [XmlAttribute("version")]
        public int Version { get; set; }

        [XmlElement("error")]
        public Error Error { get; set; }
    }

    public class Error {
        
        [XmlAttribute("code")]
        public int ErrorCode { get; set; }

        [XmlText]
        public string ErrorText { get; set; }
        
    }


}