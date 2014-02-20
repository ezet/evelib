using System;
using System.Xml.Serialization;

namespace eZet.Eve.EveApi.Dto.EveApi.Corporation {
    public class MedalList : XmlResult {

        [XmlElement("rowset")]
        public XmlRowSet<Medal> Medals { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class Medal {
            [XmlAttribute("medalID")]
            public long MedalId { get; set; }

            [XmlAttribute("title")]
            public string Title { get; set; }

            [XmlAttribute("description")]
            public string Description { get; set; }

            [XmlAttribute("creatorID")]
            public long CreatorId { get; set; }

            // TODO DateTime
            [XmlAttribute("created")]
            public string Created { get; set; }
        }

    }
}
