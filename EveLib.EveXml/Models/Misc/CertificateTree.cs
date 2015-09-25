// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="CertificateTree.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Xml.Serialization;

namespace eZet.EveLib.EveXmlModule.Models.Misc {
    /// <summary>
    ///     Class CertificateTree.
    /// </summary>
    [Serializable]
    [XmlRoot("result")]
    public class CertificateTree {
        /// <summary>
        ///     Gets or sets the categories.
        /// </summary>
        /// <value>The categories.</value>
        [XmlElement("rowset")]
        public EveXmlRowCollection<CertificateCategory> Categories { get; set; }

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

            /// <summary>
            ///     Gets or sets the grade.
            /// </summary>
            /// <value>The grade.</value>
            [XmlAttribute("grade")]
            public int Grade { get; set; }

            /// <summary>
            ///     Gets or sets the corporation identifier.
            /// </summary>
            /// <value>The corporation identifier.</value>
            [XmlAttribute("corporationID")]
            public long CorporationId { get; set; }

            /// <summary>
            ///     Gets or sets the description.
            /// </summary>
            /// <value>The description.</value>
            [XmlAttribute("description")]
            public string Description { get; set; }

            /// <summary>
            ///     Gets or sets the required skills.
            /// </summary>
            /// <value>The required skills.</value>
            [XmlElement("rowset")]
            public EveXmlRowCollection<Skill> RequiredSkills { get; set; }
        }

        /// <summary>
        ///     Class CertificateCategory.
        /// </summary>
        [Serializable]
        [XmlRoot("row")]
        public class CertificateCategory {
            /// <summary>
            ///     Gets or sets the category identifier.
            /// </summary>
            /// <value>The category identifier.</value>
            [XmlAttribute("categoryID")]
            public long CategoryId { get; set; }

            /// <summary>
            ///     Gets or sets the name of the category.
            /// </summary>
            /// <value>The name of the category.</value>
            [XmlAttribute("categoryName")]
            public string CategoryName { get; set; }

            /// <summary>
            ///     Gets or sets the classes.
            /// </summary>
            /// <value>The classes.</value>
            [XmlElement("rowset")]
            public EveXmlRowCollection<CertificateClass> Classes { get; set; }
        }

        /// <summary>
        ///     Class CertificateClass.
        /// </summary>
        [Serializable]
        [XmlRoot("row")]
        public class CertificateClass {
            /// <summary>
            ///     Gets or sets the class identifier.
            /// </summary>
            /// <value>The class identifier.</value>
            [XmlAttribute("classID")]
            public long ClassId { get; set; }

            /// <summary>
            ///     Gets or sets the name of the class.
            /// </summary>
            /// <value>The name of the class.</value>
            [XmlAttribute("className")]
            public string ClassName { get; set; }

            /// <summary>
            ///     Gets or sets the certificates.
            /// </summary>
            /// <value>The certificates.</value>
            [XmlElement("rowset")]
            public EveXmlRowCollection<Certificate> Certificates { get; set; }
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
            ///     Gets or sets the level.
            /// </summary>
            /// <value>The level.</value>
            [XmlAttribute("level")]
            public int Level { get; set; }
        }
    }
}