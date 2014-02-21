using System;
using System.Xml.Serialization;

namespace eZet.Eve.EoLib.Dto.EveApi.Core {
    public class SkillTree : XmlResult {

        [XmlElement("rowset")]
        public XmlRowSet<SkillGroup> Groups { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class SkillGroup {

            [XmlAttribute("groupID")]
            public int GroupId { get; set; }

            [XmlAttribute("groupName")]
            public string CorporationName { get; set; }

            [XmlElement("rowset")]
            public XmlRowSet<Skill> Skills { get; set; }

        }

        [Serializable]
        [XmlRoot("row")]
        public class Skill {

            [XmlAttribute("groupID")]
            public int GroupId { get; set; }
            
            [XmlAttribute("published")]
            public bool Published { get; set; }

            [XmlAttribute("typeID")]
            public long TypeId { get; set; }

            [XmlAttribute("typeName")]
            public string TypeName { get; set; }

            [XmlElement("description")]
            public string Description { get; set; }

            [XmlElement("rank")]
            public int Rank { get; set; }

            [XmlElement("rowset")]
            public XmlRowSet<RequiredAttribute> RequiredAttributes { get; set; }

        }


        // TODO Implement skilltree
        [Serializable]
        [XmlRoot("row")]
        public class RequiredSkill {
            
        }

        public class RequiredAttribute {
            
        }

        public class SkillBonus {
            
        }
    }



}
