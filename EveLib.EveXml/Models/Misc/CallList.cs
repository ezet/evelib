// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="CallList.cs" company="">
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
    ///     Class CallList.
    /// </summary>
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class CallList : IXmlSerializable {
        /// <summary>
        ///     Gets or sets the call groups.
        /// </summary>
        /// <value>The call groups.</value>
        [XmlElement("rowset")]
        public EveXmlRowCollection<CallGroup> CallGroups { get; set; }


        /// <summary>
        ///     Gets or sets the calls.
        /// </summary>
        /// <value>The calls.</value>
        [XmlElement("rowset")]
        public EveXmlRowCollection<Call> Calls { get; set; }


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
            CallGroups = xml.deserializeRowSet<CallGroup>("callGroups");
            Calls = xml.deserializeRowSet<Call>("calls");
        }

        /// <summary>
        ///     Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter" /> stream to which the object is serialized.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void WriteXml(XmlWriter writer) {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Class Call.
        /// </summary>
        [Serializable]
        [XmlRoot("row")]
        public class Call {
            /// <summary>
            ///     Gets or sets the access mask.
            /// </summary>
            /// <value>The access mask.</value>
            [XmlAttribute("accessMask")]
            public long AccessMask { get; set; }

            /// <summary>
            ///     Gets or sets the character.
            /// </summary>
            /// <value>The character.</value>
            [XmlAttribute("type")]
            public string Character { get; set; }

            /// <summary>
            ///     Gets or sets the name.
            /// </summary>
            /// <value>The name.</value>
            [XmlAttribute("name")]
            public string Name { get; set; }

            /// <summary>
            ///     Gets or sets the group identifier.
            /// </summary>
            /// <value>The group identifier.</value>
            [XmlAttribute("groupID")]
            public long groupId { get; set; }

            /// <summary>
            ///     Gets or sets the description.
            /// </summary>
            /// <value>The description.</value>
            [XmlAttribute("description")]
            public string Description { get; set; }
        }

        /// <summary>
        ///     Class CallGroup.
        /// </summary>
        [Serializable]
        [XmlRoot("row")]
        public class CallGroup {
            /// <summary>
            ///     Gets or sets the group identifier.
            /// </summary>
            /// <value>The group identifier.</value>
            [XmlAttribute("groupID")]
            public long GroupId { get; set; }

            /// <summary>
            ///     Gets or sets the name of the group.
            /// </summary>
            /// <value>The name of the group.</value>
            [XmlAttribute("name")]
            public string GroupName { get; set; }

            /// <summary>
            ///     Gets or sets the description.
            /// </summary>
            /// <value>The description.</value>
            [XmlAttribute("description")]
            public string Description { get; set; }
        }
    }
}