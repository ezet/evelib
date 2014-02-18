using System;
using System.Xml.Serialization;

namespace eZet.Eve.EveApi.Dto.EveApi.Character {


    [Serializable()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    public partial class CharacterSheet : XmlResult {

        [XmlElement("characterID")]
        public long CharacterId { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("DoB")]
        public string DateOfBirth { get; set; }

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



    public class Implant {

        [XmlElement("augmentatorName")]
        public string Name { get; set; }

        [XmlElement("augmentatorValue")]
        public int Value { get; set; }

    }



    [Serializable()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
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

        [XmlIgnore()]
        public bool typeIDFieldSpecified;

        [XmlAttribute("skillpoints")]
        public int Skillpoints { get; set; }

        [XmlIgnore()]
        public bool skillpointsFieldSpecified;

        [XmlAttribute("level")]
        public int Level { get; set; }

        [XmlIgnore()]
        public bool levelFieldSpecified;

        [XmlAttribute("published")]
        public int Published { get; set; }

        [XmlIgnore()]
        public bool publishedFieldSpecified;

        [XmlAttribute("certificateID")]
        public long CertificateId { get; set; }

        [XmlIgnore()]
        public bool certificateIDFieldSpecified;

        [XmlAttribute("roleID")]
        public long RoleId { get; set; }

        [XmlIgnore()]
        public bool roleIDFieldSpecified;

        [XmlAttribute("roleName")]
        public string RoleName { get; set; }

        [XmlAttribute("titleID")]
        public long TitleId { get; set; }

        [XmlIgnore()]
        public bool titleIDFieldSpecified;

        [XmlAttribute("titleName")]
        public string TitleName { get; set; }


    }
}