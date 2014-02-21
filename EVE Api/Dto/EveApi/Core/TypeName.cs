using System;
using System.Xml.Serialization;

namespace eZet.Eve.EoLib.Dto.EveApi.Core {

    public class TypeName : XmlResult {

        [XmlElement("rowset")]
        public XmlRowSet<TypeData> Types { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class TypeData {
            
            [XmlAttribute("typeID")]
            public long TypeId { get; set; }

            [XmlAttribute("typeName")]
            public string TypeName { get; set; }
            
        }
    }


}
