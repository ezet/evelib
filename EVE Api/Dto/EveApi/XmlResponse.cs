using System;
using System.Xml.Serialization;
using eZet.Eve.EoLib.Entity;

namespace eZet.Eve.EoLib.Dto.EveApi {

    [Serializable]
    [System.Diagnostics.DebuggerStepThroughAttribute]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot("eveapi", IsNullable = false)]
    public class XmlResponse<T> where T : XmlResult {

        [XmlIgnore]
        public DateTime CurrentTime { get; private set; }

        [XmlElement("currentTime")]
        public string CurrentTimeAsString {
            get { return CurrentTime.ToString(XmlResult.DateFormat); }
            set { CurrentTime = DateTime.ParseExact(value, XmlResult.DateFormat, null); }
        }

        [XmlElement("result")]
        public T Result { get; set; }

        [XmlIgnore]
        public DateTime CachedUntil { get; private set; }

        [XmlElement("cachedUntil")]
        public string CachedUntilAsString {
            get { return CachedUntil.ToString(XmlResult.DateFormat); }
            set { CachedUntil = DateTime.ParseExact(value, XmlResult.DateFormat, null); }
        }

        [XmlAttribute("version")]
        public int Version { get; set; }

        private ApiKey apiKeyField;

        [XmlIgnore]
        public ApiKey ApiKey {
            get {
                return apiKeyField;
            }
            set {
                apiKeyField = value;
                Result.SetApiKey(value);
            }
        }

    }


}