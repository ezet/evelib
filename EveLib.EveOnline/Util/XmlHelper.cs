using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using eZet.EveLib.Modules.Models;

namespace eZet.EveLib.Modules.Util {
    /// <summary>
    ///     Provides utility methods for XML element classes.
    /// </summary>
    public class XmlHelper {
        public const string DateFormat = "yyyy-MM-dd HH:mm:ss";

        /// <summary>
        ///     Sets and initializes the xml document for parsing using linq to xml.
        /// </summary>
        /// <param name="reader"></param>
        public XmlHelper(XmlReader reader) {
            Contract.Requires(reader != null);
            root = XElement.Load(reader.ReadSubtree());
            list = root.Descendants();
        }

        protected IEnumerable<XElement> list { get; set; }

        protected XElement root { get; set; }

        /// <summary>
        ///     Deserializes an XML rowset using .NETs XmlSerializer.
        /// </summary>
        /// <typeparam name="T">KeyType used for deserialization.</typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public virtual EveOnlineRowCollection<T> deserializeRowSet<T>(string name) {
            XmlReader reader = getRowSetReader(name);
            if (reader == null) return default(EveOnlineRowCollection<T>);
            reader.ReadToDescendant("rowset");
            var serializer = new XmlSerializer(typeof (EveOnlineRowCollection<T>));
            return (EveOnlineRowCollection<T>) serializer.Deserialize(reader);
        }


        /// <summary>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public T deserialize<T>(string name) {
            XmlReader reader = getReader(name);
            if (reader == null) return default(T);
            var serializer = new XmlSerializer(typeof (T));
            return (T) serializer.Deserialize(reader);
        }

        /// <summary>
        ///     Gets a XML reader for a regular element for use with reflected XML serialization.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public XmlReader getReader(string name) {
            XElement el = list.FirstOrDefault(x => x.Name == name);
            return el != null ? el.CreateReader() : null;
        }

        /// <summary>
        ///     Gets a XML reader for a rowset element for use with reflected XML serialization.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public XmlReader getRowSetReader(string name) {
            XElement rowset = list.Where(x => x.Name == "rowset").FirstOrDefault(r => r.Attribute("name").Value == name);
            return rowset != null ? rowset.CreateReader() : null;
        }

        public long getLong(string name) {
            XElement val = list.FirstOrDefault(x => x.Name == name);
            return val != null ? long.Parse(val.Value) : 0;
        }

        public string getString(string name) {
            XElement val = list.SingleOrDefault(x => x.Name == name);
            return val != null ? val.Value : "";
        }

        public int getInt(string name) {
            XElement val = list.FirstOrDefault(x => x.Name == name);
            return val != null ? int.Parse(val.Value) : 0;
        }

        public decimal getDecimal(string name) {
            XElement val = list.FirstOrDefault(x => x.Name == name);
            return val != null ? decimal.Parse(list.First(x => x.Name == name).Value, CultureInfo.InvariantCulture) : 0;
        }

        public string getStringAttribute(string name) {
            return root.Attribute(name) != null ? root.Attribute(name).Value : "";
        }

        public long getLongAttribute(string name) {
            return root.Attribute(name) != null ? long.Parse(root.Attribute(name).Value) : 0;
        }

        public int getIntAttribute(string name) {
            return root.Attribute(name) != null ? int.Parse(root.Attribute(name).Value) : 0;
        }

        public bool? getBoolAttribute(string name) {
            return root.Attribute(name) != null
                ? root.Attribute(name).Value != "0" && root.Attribute(name).Value.ToLower() != "false"
                : default(bool?);
        }
    }
}