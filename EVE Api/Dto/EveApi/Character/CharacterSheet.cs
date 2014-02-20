using System;
using System.Xml.Serialization;

namespace eZet.Eve.EveApi.Dto.EveApi.Character {

    [Serializable]
    [System.Diagnostics.DebuggerStepThroughAttribute]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    public class CharacterSheet : XmlResult {

        [XmlElement("characterID")]
        public long CharacterId { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlIgnore]
        public DateTime DateOfBirth { get; private set; }

        [XmlElement("DoB")]
        public string DateOfBirthAsString {
            get { return DateOfBirth.ToString(DateFormat); }
            set { DateOfBirth = DateTime.ParseExact(value, DateFormat, null); }
        }

        [XmlElement("race")]
        public string Race { get; set; }

        [XmlElement("bloodLine")]
        public string Bloodline { get; set; }

        [XmlElement("ancestry")]
        public string Ancestry { get; set; }

        [XmlElement("gender")]
        public string Gender { get; set; }

        [XmlElement("corporationName")]
        public string CorporationName { get; set; }

        [XmlElement("corporationID")]
        public long CorporationId { get; set; }

        [XmlElement("allianceName")]
        public object AllianceName { get; set; }

        [XmlElement("allianceID")]
        public long AllianceId { get; set; }

        [XmlElement("cloneName")]
        public string CloneName { get; set; }

        [XmlElement("cloneSkillPoints")]
        public int CloneSkillPoints { get; set; }

        [XmlElement("balance")]
        public decimal Balance { get; set; }

        [XmlElement("attributeEnhancers")]
        public Implants AttributeEnhancers { get; set; }

        [XmlElement("attributes")]
        public Attributes Attributes { get; set; }

        [XmlElement("rowset")]
        public XmlRowSet<Skill>[] Skills { get; set; }

    }


    [Serializable]
    [System.Diagnostics.DebuggerStepThroughAttribute]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    public class Implants {

        [XmlElement("memoryBonus")]
        public Implant Memory { get; set; }

        [XmlElement("perceptionBonus")]
        public Implant Perception { get; set; }

        [XmlElement("willpowerBonus")]
        public Implant Willpower { get; set; }

        [XmlElement("intelligenceBonus")]
        public Implant Intelligence { get; set; }

        [XmlElement("charismaBonus")]
        public Implant Charisma { get; set; }

    }


    [Serializable]
    [System.Diagnostics.DebuggerStepThroughAttribute]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    public class Implant {

        [XmlElement("augmentatorName")]
        public string Name { get; set; }

        [XmlElement("augmentatorValue")]
        public int Value { get; set; }

    }


    [Serializable]
    [System.Diagnostics.DebuggerStepThroughAttribute]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    public class Attributes {

        [XmlElement("intelligence")]
        public int Intelligence { get; set; }

        [XmlElement("memory")]
        public int Memory { get; set; }

        [XmlElement("charisma")]
        public int Charisma { get; set; }

        [XmlElement("perception")]
        public int Perception { get; set; }

        [XmlElement("willlpower")]
        public int Willpower { get; set; }

    }


    [Serializable]
    [XmlRoot("row")]
    public class Skill {

        [XmlAttribute("typeID")]
        public long TypeId { get; set; }

        [XmlAttribute("skillpoints")]
        public int Skillpoints { get; set; }

        [XmlAttribute("level")]
        public int Level { get; set; }

        [XmlAttribute("published")]
        public int Published { get; set; }

        [XmlAttribute("certificateID")]
        public long CertificateId { get; set; }

        [XmlAttribute("roleID")]
        public long RoleId { get; set; }

        [XmlAttribute("roleName")]
        public string RoleName { get; set; }

        [XmlAttribute("titleID")]
        public long TitleId { get; set; }

        [XmlAttribute("titleName")]
        public string TitleName { get; set; }

    }
}