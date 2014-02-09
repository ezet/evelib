using eZet.Eve.EveApi.Dto;
using System.Collections.Generic;
using System.Xml;
/// <remarks/>
using System.Xml.Serialization;

namespace eZet.Eve.EveApi.Dto {

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute("eveapi", Namespace = "", IsNullable = false)]


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

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class EveApiRowset<T> {

        [XmlElementAttribute("row")]
        public List<T> RowData { get; set; }

        [XmlAnyAttribute()]
        public XmlAttribute[] RowMeta;

        //[XmlAttribute("name")]
        //public string Name { get; set; }

        //[XmlAttribute("key")]
        //public string Key { get; set; }

        //[XmlAttribute("columns")]
        //public string Columns { get; set; }

    }
}