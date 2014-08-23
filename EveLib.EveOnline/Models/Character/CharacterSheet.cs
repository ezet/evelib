using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using eZet.EveLib.Modules.Util;

namespace eZet.EveLib.Modules.Models.Character {
    /// <summary>
    /// Represents a Character Sheet
    /// </summary>
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class CharacterSheet : IXmlSerializable {

        /// <summary>
        /// The character ID
        /// </summary>
        [XmlElement("characterID")]
        public long CharacterId { get; set; }

        /// <summary>
        /// The character name
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// The characters date of birth
        /// </summary>
        [XmlIgnore]
        public DateTime DateOfBirth { get; private set; }

        /// <summary>
        /// The characters date of birth 
        /// </summary>
        [XmlElement("DoB")]
        public string DateOfBirthAsString {
            get { return DateOfBirth.ToString(XmlHelper.DateFormat); }
            set { DateOfBirth = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
        }

        /// <summary>
        /// The characters race
        /// </summary>
        [XmlElement("race")]
        public string Race { get; set; }

        /// <summary>
        /// The characters bloodline
        /// </summary>
        [XmlElement("bloodLine")]
        public string Bloodline { get; set; }

        /// <summary>
        /// The characters ancestry
        /// </summary>
        [XmlElement("ancestry")]
        public string Ancestry { get; set; }

        /// <summary>
        /// The characters gender
        /// </summary>
        [XmlElement("gender")]
        public string Gender { get; set; }

        /// <summary>
        /// The ID of the corporation the character is in
        /// </summary>
        [XmlElement("corporationID")]
        public long CorporationId { get; set; }

        /// <summary>
        /// The name of the corporation the character is in
        /// </summary>
        [XmlElement("corporationName")]
        public string CorporationName { get; set; }

        /// <summary>
        /// The ID of the alliance the character is in
        /// </summary>
        [XmlElement("allianceID")]
        public long AllianceId { get; set; }

        /// <summary>
        /// The name of the alliance the character is in
        /// </summary>
        [XmlElement("allianceName")]
        public string AllianceName { get; set; }

        /// <summary>
        /// The ID of the faction the character is in
        /// </summary>
        [XmlElement("factionID")]
        public long FactionId { get; set; }

        /// <summary>
        /// The name of the faction the character is in
        /// </summary>
        [XmlElement("factionName")]
        public string FactionName { get; set; }

        /// <summary>
        /// The name of the current medical clone
        /// </summary>
        [XmlElement("cloneName")]
        public string CloneName { get; set; }

        /// <summary>
        /// The amount of skillpoints supported by the current medical clone
        /// </summary>
        [XmlElement("cloneSkillPoints")]
        public int CloneSkillPoints { get; set; }

        /// <summary>
        /// The wallet balance
        /// </summary>
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
            Attributes = xml.deserialize<Attributes>("attributes");
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


    /// <summary>
    /// Represents the current attribute implants
    /// </summary>
    [Serializable]
    [DebuggerStepThrough]
    [XmlRoot("attributeEnhancers")]
    public class Implants {
        /// <summary>
        /// The current memory bonus
        /// </summary>
        [XmlElement("memoryBonus")]
        public Implant Memory { get; set; }

        /// <summary>
        /// The current perception bonus
        /// </summary>
        [XmlElement("perceptionBonus")]
        public Implant Perception { get; set; }

        /// <summary>
        /// The current willpower bonus
        /// </summary>
        [XmlElement("willpowerBonus")]
        public Implant Willpower { get; set; }

        /// <summary>
        /// The current intelligence bonus
        /// </summary>
        [XmlElement("intelligenceBonus")]
        public Implant Intelligence { get; set; }

        /// <summary>
        /// The current charisma bonus
        /// </summary>
        [XmlElement("charismaBonus")]
        public Implant Charisma { get; set; }
    }


    /// <summary>
    /// Represents an implant
    /// </summary>
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class Implant {
        /// <summary>
        /// The implant name
        /// </summary>
        [XmlElement("augmentatorName")]
        public string Name { get; set; }

        /// <summary>
        /// The attribute bonus
        /// </summary>
        [XmlElement("augmentatorValue")]
        public int Value { get; set; }
    }

    /// <summary>
    /// The total attribute values
    /// </summary>
    [Serializable]
    [DebuggerStepThrough]
    [XmlType(AnonymousType = true)]
    [XmlRoot("attributes")]
    public class Attributes {
        /// <summary>
        /// Total intelligence
        /// </summary>
        [XmlElement("intelligence")]
        public int Intelligence { get; set; }

        /// <summary>
        /// Total memory
        /// </summary>
        [XmlElement("memory")]
        public int Memory { get; set; }

        /// <summary>
        /// Total charisma
        /// </summary>
        [XmlElement("charisma")]
        public int Charisma { get; set; }

        /// <summary>
        /// Total perception
        /// </summary>
        [XmlElement("perception")]
        public int Perception { get; set; }

        /// <summary>
        /// Total willpower
        /// </summary>
        [XmlElement("willlpower")]
        public int Willpower { get; set; }
    }


    [Serializable]
    [XmlRoot("row")]
    public class Skill {
        [XmlAttribute("typeID")]
        public int TypeId { get; set; }

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