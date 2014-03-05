using System;
using System.Xml.Serialization;

namespace eZet.Eve.EveLib.Model.EveApi.Corporation {
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class StarbaseList : XmlElement {
        [XmlElement("rowset")]
        public XmlRowSet<Starbase> Starbases { get; set; }


        [Serializable]
        [XmlRoot("row")]
        public class Starbase {
            public enum StarbaseState {
                [XmlEnum("0")] Unanchored,
                [XmlEnum("1")] Anchored,
                [XmlEnum("2")] Onlining,
                [XmlEnum("3")] Reinforced,
                [XmlEnum("4")] Online
            }

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

            [XmlIgnore]
            public DateTime StateTimestamp { get; private set; }

            [XmlElement("stateTimestamp")]
            public string StateTimestampAsString {
                get { return StateTimestamp.ToString(DateFormat); }
                set { StateTimestamp = DateTime.ParseExact(value, DateFormat, null); }
            }

            [XmlIgnore]
            public DateTime OnlineTimestamp { get; private set; }

            [XmlElement("onlineTimestamp")]
            public string OnlineTimestampAsString {
                get { return OnlineTimestamp.ToString(DateFormat); }
                set { OnlineTimestamp = DateTime.ParseExact(value, DateFormat, null); }
            }

            [XmlAttribute("standingOwnerID")]
            public long StandingOwnerId { get; set; }
        }
    }
}