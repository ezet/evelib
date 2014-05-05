using System;
using System.Diagnostics.Contracts;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using eZet.EveLib.Modules.Util;

namespace eZet.EveLib.Modules.Models.Character {
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class ContactList : IXmlSerializable {
        [XmlElement("rowset")]
        public EveOnlineRowCollection<Contact> PersonalContacts { get; set; }

        [XmlElement("rowset")]
        public EveOnlineRowCollection<Contact> CorporationContacts { get; set; }

        [XmlElement("rowset")]
        public EveOnlineRowCollection<Contact> AllianceContacts { get; set; }

        public XmlSchema GetSchema() {
            throw new NotImplementedException();
        }

        public void ReadXml(XmlReader reader) {
            var xml = new XmlHelper(reader);
            PersonalContacts = xml.deserializeRowSet<Contact>("contactList");
            CorporationContacts = xml.deserializeRowSet<Contact>("corporateContactList");
            AllianceContacts = xml.deserializeRowSet<Contact>("allianceContactList");
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