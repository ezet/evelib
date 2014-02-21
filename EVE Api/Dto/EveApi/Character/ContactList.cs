using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace eZet.Eve.EoLib.Dto.EveApi.Character {
    public class ContactList : XmlResult, IXmlSerializable {

        [XmlElement("rowset")]
        public XmlRowSet<Contact> PersonalContacts { get; set; }

        [XmlElement("rowset")]
        public XmlRowSet<Contact> CorporationContacts { get; set; }

        [XmlElement("rowset")]
        public XmlRowSet<Contact> AllianceContacts { get; set; }


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
                set { InWatchlist = (value.ToLower() == "true"); }
            }

        }

        public XmlSchema GetSchema() {
            throw new NotImplementedException();
        }

        public void ReadXml(XmlReader reader) {
            PersonalContacts = deserializeRowSet(reader, new Contact());
            CorporationContacts = deserializeRowSet(reader, new Contact());
            AllianceContacts = deserializeRowSet(reader, new Contact());
        }

        public void WriteXml(XmlWriter writer) {
            throw new NotImplementedException();
        }
    }
}
