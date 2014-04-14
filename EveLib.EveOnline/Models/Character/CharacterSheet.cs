using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using eZet.EveLib.Modules.Util;

namespace eZet.EveLib.Modules.Models.Character {
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class CharacterSheet : IXmlSerializable {
        [XmlElement("characterID")]
        public long CharacterId { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlIgnore]
        public DateTime DateOfBirth { get; private set; }

        [XmlElement("DoB")]
        public string DateOfBirthAsString {
            get { return DateOfBirth.ToString(XmlHelper.DateFormat); }
            set { DateOfBirth = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
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

        [XmlElement("factionID")]
        public object FactionId { get; set; }
        
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
        public EveOnlineRowCollection<Skill> Skills { get; set; }

        [XmlElement("rowset")]
        public EveOnlineRowCollection<Certificate> Certificates { get; set; }

        [XmlElement("rowset")]
        public EveOnlineRowCollection<Role> CorporationRoles { get; set; }

        [XmlElement("rowset")]
        public EveOnlineRowCollection<Role> CorporationRolesAtHq { get; set; }

        [XmlElement("rowset")]
        public EveOnlineRowCollection<Role> CorporationRolesAtBase { get; set; }

        [XmlElement("rowset")]
        public EveOnlineRowCollection<Role> CorporationRolesAtOther { get; set; }

        [XmlElement("rowset")]
        public EveOnlineRowCollection<Title> CorporationTitles { get; set; }


        public XmlSchema GetSchema() {
            throw new NotImplementedException();
        }

        public void ReadXml(XmlReader reader) {
            var xml = new XmlHelper(reader);
            CharacterId = xml.getLong("characterID");
            Name = xml.getString("name");
            DateOfBirthAsString = xml.getString("DoB");
            Race = xml.getString("race");
            Bloodline = xml.getString("bloodLine");
            Ancestry = xml.getString("ancestry");
            Gender = xml.getString("gender");
            CorporationName = xml.getString("corporationName");
            CorporationId = xml.getLong("corporationID");
            AllianceName = xml.getString("allianceName");
            AllianceId = xml.getLong("allianceID");
            CloneName = xml.getString("cloneName");
            CloneSkillPoints = xml.getInt("cloneSkillPoints");
            Balance = xml.getDecimal("balance");
            AttributeEnhancers = xml.deserialize<Implants>("attributeEnhancers");
            Skills = xml.deserializeRowSet<Skill>("skills");
            Certificates = xml.deserializeRowSet<Certificate>("certificates");
            CorporationRoles = xml.deserializeRowSet<Role>("corporationRoles");
            CorporationRolesAtHq = xml.deserializeRowSet<Role>("corporationRolesAtHQ");
            CorporationRolesAtBase = xml.deserializeRowSet<Role>("corporationRolesAtBase");
            CorporationRolesAtOther = xml.deserializeRowSet<Role>("corporationRolesAtOther");
            CorporationTitles = xml.deserializeRowSet<Title>("corporationTitles");
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