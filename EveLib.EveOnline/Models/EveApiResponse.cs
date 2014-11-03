// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="EveApiResponse.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using eZet.EveLib.Modules.Util;

namespace eZet.EveLib.Modules.Models {
    /// <summary>
    /// Class EveApiResponse.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    [XmlRoot("eveapi", IsNullable = false)]
    public class EveApiResponse<T> : IXmlSerializable {
        /// <summary>
        /// Gets the current time.
        /// </summary>
        /// <value>The current time.</value>
        [XmlIgnore]
        public DateTime CurrentTime { get; private set; }

        /// <summary>
        /// Gets or sets the current time as string.
        /// </summary>
        /// <value>The current time as string.</value>
        [XmlElement("currentTime")]
        public string CurrentTimeAsString {
            get { return CurrentTime.ToString(XmlHelper.DateFormat); }
            set { CurrentTime = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
        }

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>The result.</value>
        [XmlElement("result")]
        public T Result { get; set; }

        /// <summary>
        /// Gets or sets the cached until.
        /// </summary>
        /// <value>The cached until.</value>
        [XmlIgnore]
        public DateTime CachedUntil { get; set; }

        /// <summary>
        /// Gets or sets the cached until as string.
        /// </summary>
        /// <value>The cached until as string.</value>
        [XmlElement("cachedUntil")]
        public string CachedUntilAsString {
            get { return CachedUntil.ToString(XmlHelper.DateFormat); }
            set { CachedUntil = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
        }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        /// <value>The version.</value>
        [XmlAttribute("version")]
        public int Version { get; set; }

        /// <summary>
        /// This method is reserved and should not be used. When implementing the IXmlSerializable interface, you should return null (Nothing in Visual Basic) from this method, and instead, if specifying a custom schema is required, apply the <see cref="T:System.Xml.Serialization.XmlSchemaProviderAttribute" /> to the class.
        /// </summary>
        /// <returns>An <see cref="T:System.Xml.Schema.XmlSchema" /> that describes the XML representation of the object that is produced by the <see cref="M:System.Xml.Serialization.IXmlSerializable.WriteXml(System.Xml.XmlWriter)" /> method and consumed by the <see cref="M:System.Xml.Serialization.IXmlSerializable.ReadXml(System.Xml.XmlReader)" /> method.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public XmlSchema GetSchema() {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Generates an object from its XML representation.
        /// </summary>
        /// <param name="reader">The <see cref="T:System.Xml.XmlReader" /> stream from which the object is deserialized.</param>
        public void ReadXml(XmlReader reader) {
            var xml = new XmlHelper(reader);
            CurrentTimeAsString = xml.getString("currentTime");
            Result = xml.deserialize<T>("result");
            Version = xml.getIntAttribute("version");
            CachedUntilAsString = xml.getString("cachedUntil");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter" /> stream to which the object is serialized.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void WriteXml(XmlWriter writer) {
            throw new NotImplementedException();
        }
    }
}