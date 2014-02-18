using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace eZet.Eve.EveApi.Dto.EveCentral {

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [SerializableAttribute]
    [System.Diagnostics.DebuggerStepThroughAttribute]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(ElementName = "evec_api", Namespace = "", IsNullable = false)]
    public class XmlResponse {

        [XmlAttribute("version")]
        public string Version { get; set; }

        [XmlAttribute("method")]
        public string Method { get; set; }

    }
}
