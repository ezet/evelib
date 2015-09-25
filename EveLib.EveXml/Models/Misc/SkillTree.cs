// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 08-23-2014
// ***********************************************************************
// <copyright file="SkillTree.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using eZet.EveLib.EveXmlModule.Util;

namespace eZet.EveLib.EveXmlModule.Models.Misc {
    /// <summary>
    ///     Represents the skill tree
    /// </summary>
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class SkillTree {
        /// <summary>
        ///     Gets or sets the groups.
        /// </summary>
        /// <value>The groups.</value>
        [XmlElement("rowset")]
        public EveXmlRowCollection<SkillGroup> Groups { get; set; }

        /// <summary>
        ///     Class RequiredAttribute.
        /// </summary>
        [Serializable]
        [XmlRoot("requiredAttributes")]
        public class RequiredAttribute {
            /// <summary>
            ///     Gets or sets the primary attribute.
            /// </summary>
            /// <value>The primary attribute.</value>
            [XmlElement("primaryAttribute")]
            public string PrimaryAttribute { get; set; }

            /// <summary>
            ///     Gets or sets the secondary attribute.
            /// </summary>
            /// <value>The secondary attribute.</value>
            [XmlElement("secondaryAttribute")]
            public string SecondaryAttribute { get; set; }
        }

        /// <summary>
        ///     Class RequiredSkill.
        /// </summary>
        [Serializable]
        [XmlRoot("row")]
        public class RequiredSkill {
            /// <summary>
            ///     Gets or sets the skill level.
            /// </summary>
            /// <value>The skill level.</value>
            [XmlAttribute("skillLevel")]
            public int SkillLevel { get; set; }

            /// <summary>
            ///     Gets or sets the type identifier.
            /// </summary>
            /// <value>The type identifier.</value>
            [XmlAttribute("typeID")]
            public int TypeId { get; set; }
        }

        /// <summary>
        ///     Class Skill.
        /// </summary>
        [Serializable]
        [XmlRoot("row")]
        public class Skill : IXmlSerializable {
            /// <summary>
            ///     Gets or sets the group identifier.
            /// </summary>
            /// <value>The group identifier.</value>
            [XmlAttribute("groupID")]
            public long GroupId { get; set; }

            /// <summary>
            ///     Gets or sets a value indicating whether this <see cref="Skill" /> is published.
            /// </summary>
            /// <value><c>true</c> if published; otherwise, <c>false</c>.</value>
            [XmlAttribute("published")]
            public bool Published { get; set; }

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

            /// <summary>
            ///     Gets or sets the description.
            /// </summary>
            /// <value>The description.</value>
            [XmlElement("description")]
            public string Description { get; set; }

            /// <summary>
            ///     Gets or sets the rank.
            /// </summary>
            /// <value>The rank.</value>
            [XmlElement("rank")]
            public int Rank { get; set; }

            /// <summary>
            ///     Gets or sets the required attributes.
            /// </summary>
            /// <value>The required attributes.</value>
            [XmlElement("requiredAttributes")]
            public RequiredAttribute RequiredAttributes { get; set; }

            /// <summary>
            ///     Gets or sets the required skills.
            /// </summary>
            /// <value>The required skills.</value>
            [XmlElement("rowset")]
            public EveXmlRowCollection<RequiredSkill> RequiredSkills { get; set; }

            /// <summary>
            ///     Gets or sets the skill bonuses.
            /// </summary>
            /// <value>The skill bonuses.</value>
            [XmlElement("rowset")]
            public EveXmlRowCollection<SkillBonus> SkillBonuses { get; set; }

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
                return null;
            }

            /// <summary>
            ///     Generates an object from its XML representation.
            /// </summary>
            /// <param name="reader">The <see cref="T:System.Xml.XmlReader" /> stream from which the object is deserialized.</param>
            public void ReadXml(XmlReader reader) {
                var xml = new XmlHelper(reader);
                GroupId = xml.getLongAttribute("groupID");
                Published = xml.getBoolAttribute("published") ?? false;
                TypeId = xml.getIntAttribute("typeID");
                TypeName = xml.getStringAttribute("typeName");
                Description = xml.getString("description");
                Rank = xml.getInt("rank");
                RequiredSkills = xml.deserializeRowSet<RequiredSkill>("requiredSkills");
                RequiredAttributes = xml.deserialize<RequiredAttribute>("requiredAttributes");
                SkillBonuses = xml.deserializeRowSet<SkillBonus>("skillBonusCollection");
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
        ///     Class SkillBonus.
        /// </summary>
        [Serializable]
        [XmlRoot("row")]
        public class SkillBonus {
            /// <summary>
            ///     Gets or sets the type of the bonus.
            /// </summary>
            /// <value>The type of the bonus.</value>
            [XmlAttribute("bonusType")]
            public string BonusType { get; set; }

            /// <summary>
            ///     Gets or sets the bonus value.
            /// </summary>
            /// <value>The bonus value.</value>
            [XmlAttribute("bonusValue")]
            public string BonusValue { get; set; }
        }

        /// <summary>
        ///     Class SkillGroup.
        /// </summary>
        [Serializable]
        [XmlRoot("row")]
        public class SkillGroup {
            /// <summary>
            ///     Gets or sets the group identifier.
            /// </summary>
            /// <value>The group identifier.</value>
            [XmlAttribute("groupID")]
            public int GroupId { get; set; }

            /// <summary>
            ///     Gets or sets the name of the group.
            /// </summary>
            /// <value>The name of the group.</value>
            [XmlAttribute("groupName")]
            public string GroupName { get; set; }

            /// <summary>
            ///     Gets or sets the skills.
            /// </summary>
            /// <value>The skills.</value>
            [XmlElement("rowset")]
            public EveXmlRowCollection<Skill> Skills { get; set; }
        }
    }
}