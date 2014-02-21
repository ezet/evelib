using System.Xml.Serialization;

namespace eZet.Eve.EoLib.Dto.EveApi.Map {
    public class SovereigntyStatus : XmlResult {

        [XmlElement("rowset")]
        public XmlRowSet<Structure> Structures { get; set; }

        public class Structure {
           // TODO Implement

            
        }
    }
}
