using System;
using System.Xml.Serialization;

namespace eZet.Eve.EveApi.Dto.EveApi.Corporation {
    public class StarbaseList : XmlResult {

        [XmlElement("rowset")]
        public XmlRowSet<Starbase> Starbases { get; set; }


        [Serializable]
        [XmlRoot("row")]
        public class Starbase {
            
            [XmlAttribute("itemID")]
            public long ItemId { get; set; }

            [XmlAttribute("typeID")]
            public long TypeId { get; set; }

            [XmlAttribute("locationID")]
            public long LocationId { get; set; }

            [XmlAttribute("moonID")]
            public long MoonId { get; set; }

            [XmlAttribute("state")]
            public StarbaseState State { get; set; }

            // TODO DateTime
            [XmlAttribute("stateTimestamp")]
            public string StateTimestamp { get; set; }

            [XmlAttribute("onlineTimestamp")]
            public string OnlineTimestamp { get; set; }

            [XmlAttribute("standingOwnerID")]
            public long StandingOwnerId { get; set; }

            public enum StarbaseState {
                [XmlEnum("0")]
                Unanchored,
                [XmlEnum("1")]
                Anchored,
                [XmlEnum("2")]
                Onlining,
                [XmlEnum("3")]
                Reinforced,
                [XmlEnum("4")]
                Online
            }

        }
    }
}
