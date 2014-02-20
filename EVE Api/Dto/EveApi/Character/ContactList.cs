using System;
using System.Xml.Serialization;

namespace eZet.Eve.EveApi.Dto.EveApi.Character {
    public class ContactList : XmlResult {

        [XmlElement("rowset")]
        public XmlRowSet<Contact> Contacts { get; set; }


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
    }
}
