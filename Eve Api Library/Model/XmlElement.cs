using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace eZet.EveLib.EveOnlineLib.Model {
    /// <summary>
    ///     Provides utility methods for XML element classes.
    /// </summary>
    public abstract class XmlElement {
        public const string DateFormat = "yyyy-MM-dd HH:mm:ss";

        protected IEnumerable<XElement> list { get; set; }

        protected XElement root { get; set; }

        /// <summary>
        ///     Sets and initializes the xml document for parsing using linq to xml.
        /// </summary>
        /// <param name="reader"></param>
        protected void setRoot(XmlReader reader) {
            Contract.Requires(reader != null);
            root = XElement.Load(reader.ReadSubtree());
            list = root.Descendants();
        }

        /// <summary>
        ///     Deserializes an XML rowset using .NETs XmlSerializer.
        /// </summary>
        /// <typeparam name="T">KeyType used for deserialization.</typeparam>
        /// <param name="reader">A reader containing the rowset to deserialize.</param>
        /// <param name="type">An instance of the type.</param>
        /// <returns></returns>
        protected virtual XmlRowSet<T> deserializeRowSet<T>(XmlReader reader, T type) {
            if (reader == null) return default(XmlRowSet<T>);
            reader.ReadToDescendant("rowset");
            var serializer = new XmlSerializer(typeof (XmlRowSet<T>));
            return (XmlRowSet<T>) serializer.Deserialize(reader);
        }


        /// <summary>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reader"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        protected virtual T deserialize<T>(XmlReader reader, T type) {
            if (reader == null) return default(T);
            var serializer = new XmlSerializer(typeof (T));
            return (T) serializer.Deserialize(reader);
        }

        /// <summary>
        ///     Gets a XML reader for a regular element for use with reflected XML serialization.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        protected XmlReader getReader(string name) {
            XElement el = list.FirstOrDefault(x => x.Name == name);
            return el != null ? el.CreateReader() : null;
        }

        /// <summary>
        ///     Gets a XML reader for a rowset element for use with reflected XML serialization.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        protected XmlReader getRowSetReader(string name) {
            XElement rowset = list.Where(x => x.Name == "rowset").FirstOrDefault(r => r.Attribute("name").Value == name);
            return rowset != null ? rowset.CreateReader() : null;
        }

        protected long getLong(string name) {
            return long.Parse(list.First(x => x.Name == name).Value);
        }

        protected string getString(string name) {
            return list.First(x => x.Name == name).Value;
        }

        protected int getInt(string name) {
            return int.Parse(list.First(x => x.Name == name).Value);
        }

        protected decimal getDecimal(string name) {
            return decimal.Parse(list.First(x => x.Name == name).Value, CultureInfo.InvariantCulture);
        }

        protected string getStringAttribute(string name) {
            return root.Attribute(name).Value;
        }

        protected long getLongAttribute(string name) {
            return long.Parse(root.Attribute(name).Value);
        }

        protected int getIntAttribute(string name) {
            return int.Parse(root.Attribute(name).Value);
        }

        protected bool getBoolAttribute(string name) {
            return root.Attribute(name).Value != "0" && root.Attribute(name).Value.ToLower() != "false";
        }
    }
}