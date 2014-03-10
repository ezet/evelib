using System;
using System.Diagnostics.Contracts;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace eZet.EveLib.EveOnline.Model.Character {
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class ContactList : XmlElement, IXmlSerializable {
        [XmlElement("rowset")]
        public RowCollection<Contact> PersonalContacts { get; set; }

        [XmlElement("rowset")]
        public RowCollection<Contact> CorporationContacts { get; set; }

        [XmlElement("rowset")]
        public RowCollection<Contact> AllianceContacts { get; set; }


        public XmlSchema GetSchema() {
            throw new NotImplementedException();
        }

        public void ReadXml(XmlReader reader) {
            setRoot(reader);
            PersonalContacts = deserializeRowSet(getRowSetReader("contactList"), new Contact());
            CorporationContacts = deserializeRowSet(getRowSetReader("corporateContactList"), new Contact());
            AllianceContacts = deserializeRowSet(getRowSetReader("allianceContactList"), new Contact());
        }

        public void WriteXml(XmlWriter writer) {
            throw new NotImplementedException();
        }

        [Serializable]
        [XmlRoot("row")]
        public class Contact {
            [XmlAttribute("contactID")]
            public long ContactId { get; set; }

            [XmlAttribute("contactName")]
            public string ContactName { get; set; }

            [XmlAttribute("standing")]
            public double Standing { get; set; }

            [XmlIgnore]
            public bool InWatchlist { get; set; }

            [XmlAttribute("inWatchlist")]
            public string InWatchlistAsString {
                get { return InWatchlist.ToString(); }
                set {
                    Contract.Requires(value != null);
                    InWatchlist = (value.ToLower() == "true");
                }
            }
        }
    }
}