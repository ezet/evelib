// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 11-03-2014
// ***********************************************************************
// <copyright file="CharacterSheet.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Diagnostics;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using eZet.EveLib.EveXmlModule.Util;

namespace eZet.EveLib.EveXmlModule.Models.Character {
    /// <summary>
    ///     Represents a Character Sheet
    /// </summary>
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class CharacterSheet : IXmlSerializable {
        /// <summary>
        ///     The character ID
        /// </summary>
        /// <value>The character identifier.</value>
        [XmlElement("characterID")]
        public long CharacterId { get; set; }


        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        ///     The characters date of birth
        /// </summary>
        /// <value>The date of birth.</value>
        [XmlIgnore]
        public DateTime DateOfBirth { get; private set; }

        /// <summary>
        ///     The characters date of birth
        /// </summary>
        /// <value>The date of birth as string.</value>
        [XmlElement("DoB")]
        public string DateOfBirthAsString {
            get { return DateOfBirth.ToString(XmlHelper.DateFormat); }
            set { DateOfBirth = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
        }

        /// <summary>
        ///     The characters race
        /// </summary>
        /// <value>The race.</value>
        [XmlElement("race")]
        public string Race { get; set; }

        /// <summary>
        ///     The characters bloodline
        /// </summary>
        /// <value>The bloodline.</value>
        [XmlElement("bloodLine")]
        public string Bloodline { get; set; }

        /// <summary>
        ///     The characters ancestry
        /// </summary>
        /// <value>The ancestry.</value>
        [XmlElement("ancestry")]
        public string Ancestry { get; set; }

        /// <summary>
        ///     The characters gender
        /// </summary>
        /// <value>The gender.</value>
        [XmlElement("gender")]
        public string Gender { get; set; }

        /// <summary>
        ///     The ID of the corporation the character is in
        /// </summary>
        /// <value>The corporation identifier.</value>
        [XmlElement("corporationID")]
        public long CorporationId { get; set; }

        /// <summary>
        ///     The name of the corporation the character is in
        /// </summary>
        /// <value>The name of the corporation.</value>
        [XmlElement("corporationName")]
        public string CorporationName { get; set; }

        /// <summary>
        ///     The ID of the alliance the character is in
        /// </summary>
        /// <value>The alliance identifier.</value>
        [XmlElement("allianceID")]
        public long AllianceId { get; set; }

        /// <summary>
        ///     The name of the alliance the character is in
        /// </summary>
        /// <value>The name of the alliance.</value>
        [XmlElement("allianceName")]
        public string AllianceName { get; set; }

        /// <summary>
        ///     The ID of the faction the character is in
        /// </summary>
        /// <value>The faction identifier.</value>
        [XmlElement("factionID")]
        public long FactionId { get; set; }

        /// <summary>
        ///     The name of the faction the character is in
        /// </summary>
        /// <value>The name of the faction.</value>
        [XmlElement("factionName")]
        public string FactionName { get; set; }

        /// <summary>
        ///     The wallet balance
        /// </summary>
        /// <value>The balance.</value>
        [XmlElement("balance")]
        public decimal Balance { get; set; }

        /// <summary>
        ///     Gets or sets Attributes
        /// </summary>
        /// <value>The attributes.</value>
        [XmlElement("attributes")]
        public Attributes Attributes { get; set; }

        /// <summary>
        ///     Gets or sets HomeStationId
        /// </summary>
        /// <value>The home station identifier.</value>
        [XmlElement("homeStationID")]
        public int HomeStationId { get; set; }

        /// <summary>
        ///     Gets or sets the last respec date.
        /// </summary>
        /// <value>The last respec date.</value>
        [XmlIgnore]
        public DateTime LastRespecDate { get; set; }

        /// <summary>
        ///     Gets or sets the last respec date as string.
        /// </summary>
        /// <value>The last respec date as string.</value>
        [XmlElement("lastRespecDate")]
        public string LastRespecDateAsString {
            get { return LastRespecDate.ToString(XmlHelper.DateFormat); }
            set { LastRespecDate = DateTime.Parse(value); }
        }

        /// <summary>
        ///     Gets or sets the last timed respec.
        /// </summary>
        /// <value>The last timed respec.</value>
        [XmlIgnore]
        public DateTime LastTimedRespec { get; set; }

        /// <summary>
        ///     Gets or sets the last timed respec as string.
        /// </summary>
        /// <value>The last timed respec as string.</value>
        [XmlElement("lastTimedRespec")]
        public string LastTimedRespecAsString {
            get { return LastRespecDate.ToString(XmlHelper.DateFormat); }
            set { LastTimedRespec = DateTime.Parse(value); }
        }

        /// <summary>
        ///     Gets or sets the free respecs.
        /// </summary>
        /// <value>The free respecs.</value>
        [XmlElement("freeRespecs")]
        public int FreeRespecs { get; set; }

        /// <summary>
        ///     Gets or sets the free skill points.
        /// </summary>
        /// <value>The free skill points.</value>
        [XmlElement("freeSkillPoints")]
        public int FreeSkillPoints { get; set; }

        /// <summary>
        ///     Gets or sets the clone jump date.
        /// </summary>
        /// <value>The clone jump date.</value>
        [XmlIgnore]
        public DateTime CloneJumpDate { get; set; }

        /// <summary>
        ///     Gets or sets the clone jump date as string.
        /// </summary>
        /// <value>The clone jump date as string.</value>
        [XmlElement("cloneJumpDate")]
        public string CloneJumpDateAsString {
            get { return CloneJumpDate.ToString(XmlHelper.DateFormat); }
            set { CloneJumpDate = DateTime.Parse(value); }
        }

        /// <summary>
        ///     Gets or sets the jump activation.
        /// </summary>
        /// <value>The jump activation.</value>
        [XmlIgnore]
        public DateTime JumpActivation { get; set; }

        /// <summary>
        ///     Sets the jump activation as string.
        /// </summary>
        /// <value>The jump activation as string.</value>
        [XmlElement("jumpActivation")]
        public string JumpActivationAsString {
            set { JumpActivation = DateTime.Parse(value); }
        }

        /// <summary>
        ///     Gets or sets the jump fatigue.
        /// </summary>
        /// <value>The jump fatigue.</value>
        [XmlIgnore]
        public DateTime JumpFatigue { get; set; }

        /// <summary>
        ///     Sets the jump fatigue as string.
        /// </summary>
        /// <value>The jump fatigue as string.</value>
        [XmlElement("jumpFatigue")]
        public string JumpFatigueAsString {
            set { JumpFatigue = DateTime.Parse(value); }
        }

        /// <summary>
        ///     Gets or sets the jump last update.
        /// </summary>
        /// <value>The jump last update.</value>
        [XmlIgnore]
        public DateTime JumpLastUpdate { get; set; }

        /// <summary>
        ///     Sets the jump last update as string.
        /// </summary>
        /// <value>The jump last update as string.</value>
        [XmlElement("jumpLastUpdate")]
        public string JumpLastUpdateAsString {
            set { JumpLastUpdate = DateTime.Parse(value); }
        }

        /// <summary>
        ///     Gets or sets the remote station date.
        /// </summary>
        /// <value>The remote station date.</value>
        [XmlIgnore]
        public DateTime RemoteStationDate { get; set; }

        /// <summary>
        ///     Sets the remote station date as string.
        /// </summary>
        /// <value>The remote station date as string.</value>
        [XmlElement("remoteStationDate")]
        public string RemoteStationDateAsString {
            set { RemoteStationDate = DateTime.Parse(value); }
        }


        /// <summary>
        ///     Gets or sets the implants.
        /// </summary>
        /// <value>The implants.</value>
        [XmlElement("rowset")]
        public EveXmlRowCollection<Implant> Implants { get; set; }

        /// <summary>
        ///     Gets or sets the jump clones.
        /// </summary>
        /// <value>The jump clones.</value>
        [XmlElement("rowset")]
        public EveXmlRowCollection<JumpClone> JumpClones { get; set; }

        /// <summary>
        ///     Gets or sets the jump clone implants.
        /// </summary>
        /// <value>The jump clone implants.</value>
        [XmlElement("rowset")]
        public EveXmlRowCollection<JumpCloneImplant> JumpCloneImplants { get; set; }

        /// <summary>
        ///     Gets or sets the skills.
        /// </summary>
        /// <value>The skills.</value>
        [XmlElement("rowset")]
        public EveXmlRowCollection<Skill> Skills { get; set; }

        /// <summary>
        ///     Gets or sets the certificates.
        /// </summary>
        /// <value>The certificates.</value>
        [XmlElement("rowset")]
        public EveXmlRowCollection<Certificate> Certificates { get; set; }

        /// <summary>
        ///     Gets or sets CorporationRoles
        /// </summary>
        /// <value>The corporation roles.</value>
        [XmlElement("rowset")]
        public EveXmlRowCollection<Role> CorporationRoles { get; set; }

        /// <summary>
        ///     Gets or sets Corporation roles at Hq
        /// </summary>
        /// <value>The corporation roles at hq.</value>
        [XmlElement("rowset")]
        public EveXmlRowCollection<Role> CorporationRolesAtHq { get; set; }

        /// <summary>
        ///     Gets or sets Corporation Roles At Base
        /// </summary>
        /// <value>The corporation roles at base.</value>
        [XmlElement("rowset")]
        public EveXmlRowCollection<Role> CorporationRolesAtBase { get; set; }

        /// <summary>
        ///     Gets or sets the corporation roles at other.
        /// </summary>
        /// <value>The corporation roles at other.</value>
        [XmlElement("rowset")]
        public EveXmlRowCollection<Role> CorporationRolesAtOther { get; set; }

        /// <summary>
        ///     Gets or sets the corporation titles.
        /// </summary>
        /// <value>The corporation titles.</value>
        [XmlElement("rowset")]
        public EveXmlRowCollection<Title> CorporationTitles { get; set; }


        /// <summary>
        ///     This method is reserved and should not be used. When implementing the IXmlSerializable interface, you should return
        ///     null (Nothing in Visual Basic) from this method, and instead, if specifying a custom schema is required, apply the
        ///     <see cref="T:System.Xml.Serialization.XmlSchemaProviderAttribute" /> to the class.
        /// </summary>
        /// <returns>
        ///     An <see cref="T:System.Xml.Schema.XmlSchema" /> that describes the XML representation of the object that is
        ///     produced by the <see cref="M:System.Xml.Serialization.IXmlSerializable.WriteXml(System.Xml.XmlWriter)" /> method
        ///     and consumed by the <see cref="M:System.Xml.Serialization.IXmlSerializable.ReadXml(System.Xml.XmlReader)" />
        ///     method.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public XmlSchema GetSchema() {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Generates an object from its XML representation.
        /// </summary>
        /// <param name="reader">The <see cref="T:System.Xml.XmlReader" /> stream from which the object is deserialized.</param>
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
            Balance = xml.getDecimal("balance");
            //JumpClones = xml.deserializeRowSet<JumpClone>("jumpClones");
            //JumpCloneImplants = xml.deserializeRowSet<JumpCloneImplant>("jumpCloneImplants");
            Implants = xml.deserializeRowSet<Implant>("implants");
            Attributes = xml.deserialize<Attributes>("attributes");
            Skills = xml.deserializeRowSet<Skill>("skills");
            Certificates = xml.deserializeRowSet<Certificate>("certificates");
            CorporationRoles = xml.deserializeRowSet<Role>("corporationRoles");
            CorporationRolesAtHq = xml.deserializeRowSet<Role>("corporationRolesAtHQ");
            CorporationRolesAtBase = xml.deserializeRowSet<Role>("corporationRolesAtBase");
            CorporationRolesAtOther = xml.deserializeRowSet<Role>("corporationRolesAtOther");
            CorporationTitles = xml.deserializeRowSet<Title>("corporationTitles");
        }

        /// <summary>
        ///     Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter" /> stream to which the object is serialized.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void WriteXml(XmlWriter writer) {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    ///     Class Implant.
    /// </summary>
    [Serializable]
    [XmlRoot("row")]
    public class Implant {
        /// <summary>
        ///     Gets or sets the type identifier.
        /// </summary>
        /// <value>The type identifier.</value>
        [XmlAttribute("typeID")]
        public int TypeId { get; set; }

        /// <summary>
        ///     Gets or sets the name of the type.
        /// </summary>
        /// <value>The name of the type.</value>
        [XmlAttribute("typeName")]
        public string TypeName { get; set; }
    }

    /// <summary>
    ///     Class JumpCloneImplant.
    /// </summary>
    [Serializable]
    [XmlRoot("row")]
    public class JumpCloneImplant {
        /// <summary>
        ///     Gets or sets the jump clone identifier.
        /// </summary>
        /// <value>The jump clone identifier.</value>
        [XmlAttribute("jumpCloneID")]
        public int JumpCloneId { get; set; }

        /// <summary>
        ///     Gets or sets the type identifier.
        /// </summary>
        /// <value>The type identifier.</value>
        [XmlAttribute("typeID")]
        public int TypeId { get; set; }

        /// <summary>
        ///     Gets or sets the name of the type.
        /// </summary>
        /// <value>The name of the type.</value>
        [XmlAttribute("typeName")]
        public string TypeName { get; set; }
    }

    /// <summary>
    ///     Class JumpClone.
    /// </summary>
    [Serializable]
    [XmlRoot("row")]
    public class JumpClone {
        /// <summary>
        ///     Gets or sets the jump clone identifier.
        /// </summary>
        /// <value>The jump clone identifier.</value>
        [XmlAttribute("jumpCloneID")]
        public int JumpCloneId { get; set; }

        /// <summary>
        ///     Gets or sets the type identifier.
        /// </summary>
        /// <value>The type identifier.</value>
        [XmlAttribute("typeID")]
        public int TypeId { get; set; }

        /// <summary>
        ///     Gets or sets the location identifier.
        /// </summary>
        /// <value>The location identifier.</value>
        [XmlAttribute("locationID")]
        public long LocationId { get; set; }

        /// <summary>
        ///     Gets or sets the name of the clone.
        /// </summary>
        /// <value>The name of the clone.</value>
        [XmlAttribute("cloneName")]
        public string CloneName { get; set; }
    }


    /// <summary>
    ///     The total attribute values
    /// </summary>
    [Serializable]
    [DebuggerStepThrough]
    [XmlType(AnonymousType = true)]
    [XmlRoot("attributes")]
    public class Attributes {
        /// <summary>
        ///     Total intelligence
        /// </summary>
        /// <value>The intelligence.</value>
        [XmlElement("intelligence")]
        public int Intelligence { get; set; }

        /// <summary>
        ///     Total memory
        /// </summary>
        /// <value>The memory.</value>
        [XmlElement("memory")]
        public int Memory { get; set; }

        /// <summary>
        ///     Total charisma
        /// </summary>
        /// <value>The charisma.</value>
        [XmlElement("charisma")]
        public int Charisma { get; set; }

        /// <summary>
        ///     Total perception
        /// </summary>
        /// <value>The perception.</value>
        [XmlElement("perception")]
        public int Perception { get; set; }

        /// <summary>
        ///     Total willpower
        /// </summary>
        /// <value>The willpower.</value>
        [XmlElement("willpower")]
        public int Willpower { get; set; }
    }


    /// <summary>
    ///     Class Skill.
    /// </summary>
    [Serializable]
    [XmlRoot("row")]
    public class Skill {
        /// <summary>
        ///     Gets or sets the type identifier.
        /// </summary>
        /// <value>The type identifier.</value>
        [XmlAttribute("typeID")]
        public int TypeId { get; set; }

        /// <summary>
        ///     Gets or sets the skillpoints.
        /// </summary>
        /// <value>The skillpoints.</value>
        [XmlAttribute("skillpoints")]
        public int Skillpoints { get; set; }

        /// <summary>
        ///     Gets or sets the level.
        /// </summary>
        /// <value>The level.</value>
        [XmlAttribute("level")]
        public int Level { get; set; }

        /// <summary>
        ///     Gets or sets the published.
        /// </summary>
        /// <value>The published.</value>
        [XmlAttribute("published")]
        public int Published { get; set; }
    }

    /// <summary>
    ///     Class Certificate.
    /// </summary>
    [Serializable]
    [XmlRoot("row")]
    public class Certificate {
        /// <summary>
        ///     Gets or sets the certificate identifier.
        /// </summary>
        /// <value>The certificate identifier.</value>
        [XmlAttribute("certificateID")]
        public long CertificateId { get; set; }
    }

    /// <summary>
    ///     Class Role.
    /// </summary>
    [Serializable]
    [XmlRoot("row")]
    public class Role {
        /// <summary>
        ///     Gets or sets the role identifier.
        /// </summary>
        /// <value>The role identifier.</value>
        [XmlAttribute("roleID")]
        public long RoleId { get; set; }

        /// <summary>
        ///     Gets or sets the name of the role.
        /// </summary>
        /// <value>The name of the role.</value>
        [XmlAttribute("roleName")]
        public string RoleName { get; set; }
    }

    /// <summary>
    ///     Class Title.
    /// </summary>
    [Serializable]
    [XmlRoot("row")]
    public class Title {
        /// <summary>
        ///     Gets or sets the title identifier.
        /// </summary>
        /// <value>The title identifier.</value>
        [XmlAttribute("titleID")]
        public long TitleId { get; set; }

        /// <summary>
        ///     Gets or sets the name of the title.
        /// </summary>
        /// <value>The name of the title.</value>
        [XmlAttribute("titleName")]
        public string TitleName { get; set; }
    }
}