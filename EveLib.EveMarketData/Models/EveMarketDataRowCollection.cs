// ***********************************************************************
// Assembly         : EveLib.EveMarketData
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="EveMarketDataRowCollection.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.ObjectModel;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace eZet.EveLib.Modules.Models {
    /// <summary>
    /// Class EveMarketDataRowCollection.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    [XmlRoot("rowset")]
    public class EveMarketDataRowCollection<T> : Collection<T>, IXmlSerializable {
        /// <summary>
        /// Initializes a new instance of the <see cref="EveMarketDataRowCollection{T}"/> class.
        /// </summary>
        public EveMarketDataRowCollection() {
            RowSetMeta = new RowSetAttributes();
        }

        /// <summary>
        /// Gets the row set meta.
        /// </summary>
        /// <value>The row set meta.</value>
        public RowSetAttributes RowSetMeta { get; private set; }

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
            var serializer = new XmlSerializer(typeof (T));
            if (!reader.IsStartElement()) return;
            RowSetMeta.Name = reader.GetAttribute("name");
            RowSetMeta.Key = reader.GetAttribute("key");
            RowSetMeta.Columns = reader.GetAttribute("columns");
            reader.ReadToDescendant("row");
            while (reader.Name == "row") {
                if (reader.IsStartElement()) {
                    var row = (T) serializer.Deserialize(reader);
                    Items.Add(row);
                }
                reader.ReadToNextSibling("row");
            }
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter" /> stream to which the object is serialized.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void WriteXml(XmlWriter writer) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Class RowSetAttributes.
        /// </summary>
        public class RowSetAttributes {
            /// <summary>
            /// Gets or sets the name.
            /// </summary>
            /// <value>The name.</value>
            public string Name { get; set; }

            /// <summary>
            /// Gets or sets the key.
            /// </summary>
            /// <value>The key.</value>
            public string Key { get; set; }

            /// <summary>
            /// Gets or sets the columns.
            /// </summary>
            /// <value>The columns.</value>
            public string Columns { get; set; }
        }
    }
}