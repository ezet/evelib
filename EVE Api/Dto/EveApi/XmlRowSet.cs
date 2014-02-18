using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace eZet.Eve.EveApi.Dto.EveApi {

    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    public class XmlRowSet<T> {

        [XmlElement("row")]
        public List<T> Rows { get; set; }

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
