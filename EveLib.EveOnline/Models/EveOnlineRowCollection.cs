using System;
using System.Collections.ObjectModel;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace eZet.EveLib.Modules.Models {
    [Serializable]
    [XmlRoot("rowset")]
    public class EveOnlineRowCollection<T> : Collection<T>, IXmlSerializable {
        public EveOnlineRowCollection() {
            RowSetMeta = new RowSetAttributes();
        }

        public RowSetAttributes RowSetMeta { get; private set; }

        public XmlSchema GetSchema() {
            throw new NotImplementedException();
        }

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

        public void WriteXml(XmlWriter writer) {
            throw new NotImplementedException();
        }

        public class RowSetAttributes {
            public string Name { get; set; }

            public string Key { get; set; }

            public string Columns { get; set; }
        }
    }
}