using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace eZet.Eve.EoLib.Dto.EveApi.Core {

    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class SkillTree : XmlElement {

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
        public class Skill : XmlElement, IXmlSerializable {

            [XmlAttribute("groupID")]
            public long GroupId { get; set; }
            
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

            [XmlElement("requiredAttributes")]
            public RequiredAttribute RequiredAttributes { get; set; }

            [XmlElement("rowset")]
            public XmlRowSet<RequiredSkill> RequiredSkills { get; set; }

            [XmlElement("rowset")]
            public XmlRowSet<SkillBonus> SkillBonuses { get; set; }

            public XmlSchema GetSchema() {
                throw new NotImplementedException();
            }

            public void ReadXml(XmlReader reader) {
                setRoot(reader);
                GroupId = getLongAttribute("groupID");
                Published = getBoolAttribute("published");
                TypeId = getLongAttribute("typeID");
                TypeName = getStringAttribute("typeName");
                Description = getString("description");
                Rank = getInt("rank");
                RequiredSkills = deserializeRowSet(getRowSetReader("requiredSkills"), new RequiredSkill());
                RequiredAttributes = deserialize(getReader("requiredAttributes"), new RequiredAttribute());
                SkillBonuses = deserializeRowSet(getRowSetReader("skillBonusCollection"), new SkillBonus());
            }

            public void WriteXml(XmlWriter writer) {
                throw new NotImplementedException();
            }
        }

        [Serializable]
        [XmlRoot("row")]
        public class RequiredSkill {
            
            [XmlAttribute("skillLevel")]
            public int SkillLevel { get; set; }

            [XmlAttribute("typeID")]
            public long TypeId { get; set; }
            
        }

        [Serializable]
        [XmlRoot("requiredAttributes")]
        public class RequiredAttribute {
            
            [XmlElement("primaryAttribute")]
            public string PrimaryAttribute { get; set; }

            [XmlElement("secondaryAttribute")]
            public string SecondaryAttribute { get; set; }
            
        }

        [Serializable]
        [XmlRoot("row")]
        public class SkillBonus {

            [XmlAttribute("bonusType")]
            public string BonusType { get; set; }

            [XmlAttribute("bonusValue")]
            public string BonusValue { get; set; }
            
        }
    }



}
