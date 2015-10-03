// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 03-11-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="XmlHelper.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using eZet.EveLib.EveXmlModule.Models;

namespace eZet.EveLib.EveXmlModule.Util {
    /// <summary>
    ///     Provides utility methods for XML element classes.
    /// </summary>
    public class XmlHelper {
        /// <summary>
        ///     The date format
        /// </summary>
        public const string DateFormat = "yyyy-MM-dd HH:mm:ss";

        /// <summary>
        ///     Sets and initializes the xml document for parsing using linq to xml.
        /// </summary>
        /// <param name="reader">The reader.</param>
        public XmlHelper(XmlReader reader) {
            Contract.Requires(reader != null);
            root = XElement.Load(reader.ReadSubtree());
            list = root.Descendants();
        }

        /// <summary>
        ///     Gets or sets the list.
        /// </summary>
        /// <value>The list.</value>
        protected IEnumerable<XElement> list { get; set; }

        /// <summary>
        ///     Gets or sets the root.
        /// </summary>
        /// <value>The root.</value>
        protected XElement root { get; set; }

        /// <summary>
        ///     Deserializes an XML rowset using .NETs XmlSerializer.
        /// </summary>
        /// <typeparam name="T">KeyType used for deserialization.</typeparam>
        /// <param name="name">The name.</param>
        /// <returns>EveXmlRowCollection&lt;T&gt;.</returns>
        public virtual EveXmlRowCollection<T> deserializeRowSet<T>(string name) {
            var reader = getRowSetReader(name);
            if (reader == null) return default(EveXmlRowCollection<T>);
            reader.ReadToDescendant("rowset");
            var serializer = new XmlSerializer(typeof (EveXmlRowCollection<T>));
            return (EveXmlRowCollection<T>) serializer.Deserialize(reader);
        }


        /// <summary>
        ///     Deserializes the specified name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name">The name.</param>
        /// <returns>T.</returns>
        public T deserialize<T>(string name) {
            var reader = getReader(name);
            if (reader == null) return default(T);
            var serializer = new XmlSerializer(typeof (T));
            return (T) serializer.Deserialize(reader);
        }

        /// <summary>
        ///     Gets a XML reader for a regular element for use with reflected XML serialization.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>XmlReader.</returns>
        public XmlReader getReader(string name) {
            var el = list.FirstOrDefault(x => x.Name == name);
            return el != null ? el.CreateReader() : null;
        }

        /// <summary>
        ///     Gets a XML reader for a rowset element for use with reflected XML serialization.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>XmlReader.</returns>
        public XmlReader getRowSetReader(string name) {
            var rowset = list.Where(x => x.Name == "rowset").FirstOrDefault(r => r.Attribute("name").Value == name);
            return rowset != null ? rowset.CreateReader() : null;
        }

        /// <summary>
        ///     Gets the long.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>System.Int64.</returns>
        public long getLong(string name) {
            var val = list.FirstOrDefault(x => x.Name == name);
            return val != null ? long.Parse(val.Value) : 0;
        }

        /// <summary>
        ///     Gets the string.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>System.String.</returns>
        public string getString(string name) {
            var val = list.SingleOrDefault(x => x.Name == name);
            return val != null ? val.Value : "";
        }

        /// <summary>
        ///     Gets the int.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>System.Int32.</returns>
        public int getInt(string name) {
            var val = list.FirstOrDefault(x => x.Name == name);
            return val != null ? int.Parse(val.Value) : 0;
        }

        /// <summary>
        ///     Gets the decimal.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>System.Decimal.</returns>
        public decimal getDecimal(string name) {
            var val = list.FirstOrDefault(x => x.Name == name);
            return val != null ? decimal.Parse(list.First(x => x.Name == name).Value, CultureInfo.InvariantCulture) : 0;
        }

        /// <summary>
        ///     Gets the string attribute.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>System.String.</returns>
        public string getStringAttribute(string name) {
            return root.Attribute(name) != null ? root.Attribute(name).Value : "";
        }

        /// <summary>
        ///     Gets the long attribute.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>System.Int64.</returns>
        public long getLongAttribute(string name) {
            return root.Attribute(name) != null ? long.Parse(root.Attribute(name).Value) : 0;
        }

        /// <summary>
        ///     Gets the int attribute.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>System.Int32.</returns>
        public int getIntAttribute(string name) {
            return root.Attribute(name) != null ? int.Parse(root.Attribute(name).Value) : 0;
        }

        /// <summary>
        ///     Gets the bool attribute.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool? getBoolAttribute(string name) {
            return root.Attribute(name) != null
                ? root.Attribute(name).Value != "0" && root.Attribute(name).Value.ToLower() != "false"
                : default(bool?);
        }
    }
}