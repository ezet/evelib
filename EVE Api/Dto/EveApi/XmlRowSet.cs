using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace eZet.Eve.EveApi.Dto.EveApi {

    public class XmlRowSet<T> : IXmlSerializable, IEnumerable<T> {

        [XmlElement("row")]
        private List<T> Rows { get; set; }

        [XmlAnyAttribute]
        public XmlAttribute[] RowMeta;

        public XmlRowSet() {
            Rows = new List<T>();
        } 

        public XmlSchema GetSchema() {
            throw new NotImplementedException();
        }

        public void ReadXml(XmlReader reader) {
            var serializer = new XmlSerializer(typeof(T));
            reader.ReadToDescendant("row");
            T row;
            while (reader.Name == "row") {
                if (reader.IsStartElement()) {
                    row = (T) serializer.Deserialize(reader);
                    Rows.Add(row);
                }
                reader.ReadToNextSibling("row");
            }
        }

        public void WriteXml(XmlWriter writer) {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator() {
            return Rows.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return ((IEnumerable) Rows).GetEnumerator();
        }
    }
}
