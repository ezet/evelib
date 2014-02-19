using System.Xml.Serialization;
using eZet.Eve.EveApi.Dto.EveApi;

namespace eZet.Eve.EveApi.Entity {
    public class SovereigntyStatus : XmlResult {

        [XmlElement("rowset")]
        public XmlRowSet<Structure> Structures { get; set; }

        public class Structure {

            
        }
    }
}
