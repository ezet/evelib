using eZet.Eve.EveApi.Dto;
/// <remarks/>
using System.Xml.Serialization;

namespace eZet.Eve.EveApi.Dto {

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute("eveapi", Namespace = "", IsNullable = false)]


    public class EveApiXml<T> {

        public string currentTime { get; set; }

        public T result { get; set; }

        public string cachedUntil { get; set; }

        [XmlAttribute()]
        public byte version { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class EveApiRowset<T> {

        public T row { get; set; }

        [XmlAttribute()]
        public string name { get; set; }

        [XmlAttribute()]
        public string key { get; set; }

        [XmlAttribute()]
        public string columns { get; set; }


    }
}