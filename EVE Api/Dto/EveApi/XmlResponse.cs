
using System.Xml.Serialization;
using eZet.Eve.EveApi;

namespace eZet.Eve.EveApi.Dto.EveApi {


    [System.SerializableAttribute]
    [System.Diagnostics.DebuggerStepThroughAttribute]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot("eveapi", Namespace = "", IsNullable = false)]
    public class XmlResponse<T> where T : XmlResult {

        [XmlElement("currentTime")]
        public string CurrentTime { get; set; }

        [XmlElement("result")]
        public T Result { get; set; }

        [XmlElement("cachedUntil")]
        public string CachedUntil { get; set; }

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