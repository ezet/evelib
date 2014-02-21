using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace eZet.Eve.EoLib.Dto.EveApi {

    [Serializable]
    [XmlRoot("rowset")]
    public class XmlRowSet<T> : IXmlSerializable, IEnumerable<T> {

        private List<T> Rows { get; set; }

        public RowSetAttributes RowSetMeta { get; private set; }

        public XmlRowSet() {
            Rows = new List<T>();
            RowSetMeta = new RowSetAttributes();
        } 

        public XmlSchema GetSchema() {
            throw new NotImplementedException();
        }

        public void ReadXml(XmlReader reader) {
            var serializer = new XmlSerializer(typeof(T));
            if (reader.IsStartElement()) {
                RowSetMeta.Name = reader.GetAttribute("name");
                RowSetMeta.Key = reader.GetAttribute("Key");
                RowSetMeta.Columns = reader.GetAttribute("columns");
                reader.ReadToDescendant("row");
                while (reader.Name == "row") {
                    if (reader.IsStartElement()) {
                        var row = (T) serializer.Deserialize(reader);
                        Rows.Add(row);
                    }
                    reader.ReadToNextSibling("row");
                }
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

        public class RowSetAttributes {

            [XmlAttribute("name")]
            public string Name { get; set; }

            [XmlAttribute("Key")]
            public string Key { get; set; }

            [XmlAttribute("coloumns")]
            public string Columns { get; set; }
            
        }
    }
}
