using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using eZet.Eve.EoLib.Entity;

namespace eZet.Eve.EoLib.Dto.EveApi {
    public abstract class XmlResult {

        public const string DateFormat = "yyyy-MM-dd HH:mm:ss";

        private bool firstRead = true;

        protected IEnumerable<XElement> list { get; set; }

        protected XElement root { get; set; }

        public virtual void SetApiKey(ApiKey key) {

        }

        protected void setRoot(XmlReader reader) {
            root = XElement.Load(reader.ReadSubtree());
            list = root.Descendants();
        }

        protected virtual XmlRowSet<T> deserializeRowSet<T>(XmlReader reader, T type) {
            if (firstRead) {
                reader.ReadToDescendant("rowset");
                firstRead = false;
            }
            else {
                reader.ReadToNextSibling("rowset");
            }
            var serializer = new XmlSerializer(typeof(XmlRowSet<T>));
            return (XmlRowSet<T>)serializer.Deserialize(reader);
        }

        protected virtual T deserialize<T>(XmlReader reader, T type) {
            var serializer = new XmlSerializer(typeof(T));
            return (T)serializer.Deserialize(reader);
        }

        protected XmlReader getReader(string name) {
            return list.First(x => x.Name == name).CreateReader();
        }

        protected XmlReader getRowSetReader(string name) {
            var rowset = list.Where(x => x.Name == "rowset").First(r => r.Attribute("name").Value == name);
            return rowset.CreateReader();
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
            return decimal.Parse(list.First(x => x.Name == name).Value, NumberStyles.AllowDecimalPoint);
        }

    }
}
