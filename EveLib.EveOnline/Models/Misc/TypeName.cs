using System;
using System.Xml.Serialization;

namespace eZet.EveLib.Modules.Models.Misc {
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class TypeName {
        [XmlElement("rowset")]
        public EveOnlineRowCollection<TypeData> Types { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class TypeData {
            [XmlAttribute("typeID")]
            public int TypeId { get; set; }

            [XmlAttribute("typeName")]
            public string TypeName { get; set; }
        }
    }
}