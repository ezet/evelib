using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace eZet.EveLib.EveOnlineApi.Model.Character {
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class CharacterSheet : XmlElement, IXmlSerializable {
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
        public RowCollection<Skill> Skills { get; set; }

        [XmlElement("rowset")]
        public RowCollection<Certificate> Certificates { get; set; }

        [XmlElement("rowset")]
        public RowCollection<Role> CorporationRoles { get; set; }

        [XmlElement("rowset")]
        public RowCollection<Role> CorporationRolesAtHq { get; set; }

        [XmlElement("rowset")]
        public RowCollection<Role> CorporationRolesAtBase { get; set; }

        [XmlElement("rowset")]
        public RowCollection<Role> CorporationRolesAtOther { get; set; }

        [XmlElement("rowset")]
        public RowCollection<Title> CorporationTitles { get; set; }


        public XmlSchema GetSchema() {
            throw new NotImplementedException();
        }

        public void ReadXml(XmlReader reader) {
            setRoot(reader);
            CharacterId = getLong("characterID");
            Name = getString("name");
            DateOfBirthAsString = getString("DoB");
            Race = getString("race");
            Bloodline = getString("bloodLine");
            Ancestry = getString("ancestry");
            Gender = getString("gender");
            CorporationName = getString("corporationName");
            CorporationId = getLong("corporationID");
            AllianceName = getString("allianceName");
            AllianceId = getLong("allianceID");
            CloneName = getString("cloneName");
            CloneSkillPoints = getInt("cloneSkillPoints");
            Balance = getDecimal("balance");
            AttributeEnhancers = deserialize(getReader("attributeEnhancers"), new Implants());
            Skills = deserializeRowSet(getRowSetReader("skills"), new Skill());
            Certificates = deserializeRowSet(getRowSetReader("certificates"), new Certificate());
            CorporationRoles = deserializeRowSet(getRowSetReader("corporationRoles"), new Role());
            CorporationRolesAtHq = deserializeRowSet(getRowSetReader("corporationRolesAtHQ"), new Role());
            CorporationRolesAtBase = deserializeRowSet(getRowSetReader("corporationRolesAtBase"), new Role());
            CorporationRolesAtOther = deserializeRowSet(getRowSetReader("corporationRolesAtOther"), new Role());
            CorporationTitles = deserializeRowSet(getRowSetReader("corporationTitles"), new Title());
        }

        public void WriteXml(XmlWriter writer) {
            throw new NotImplementedException();
        }
    }


    [Serializable]
    [DebuggerStepThrough]
    [XmlRoot("attributeEnhancers")]
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
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class Implant {
        [XmlElement("augmentatorName")]
        public string Name { get; set; }

        [XmlElement("augmentatorValue")]
        public int Value { get; set; }
    }


    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
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
    }

    [Serializable]
    [XmlRoot("row")]
    public class Certificate {
        [XmlAttribute("certificateID")]
        public long CertificateId { get; set; }
    }

    [Serializable]
    [XmlRoot("row")]
    public class Role {
        [XmlAttribute("roleID")]
        public long RoleId { get; set; }

        [XmlAttribute("roleName")]
        public string RoleName { get; set; }
    }

    [Serializable]
    [XmlRoot("row")]
    public class Title {
        [XmlAttribute("titleID")]
        public long TitleId { get; set; }

        [XmlAttribute("titleName")]
        public string TitleName { get; set; }
    }
}