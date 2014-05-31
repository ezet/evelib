using System;
using System.Xml.Serialization;
using eZet.EveLib.Modules.Util;

namespace eZet.EveLib.Modules.Models.Corporation {
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class StarbaseDetails {
        [XmlElement("state")]
        public int State { get; set; }

        [XmlIgnore]
        public DateTime StateTimestamp { get; private set; }

        [XmlElement("stateTimestamp")]
        public string StateTimestampAsString {
            get { return StateTimestamp.ToString(XmlHelper.DateFormat); }
            set { StateTimestamp = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
        }

        [XmlIgnore]
        public DateTime OnlineTimestamp { get; private set; }

        [XmlElement("onlineTimestamp")]
        public string OnlineTimestampAsString {
            get { return OnlineTimestamp.ToString(XmlHelper.DateFormat); }
            set { OnlineTimestamp = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
        }

        [XmlElement("generalSettings")]
        public GeneralSetting GeneralSettings { get; set; }

        [XmlElement("rowset")]
        public EveOnlineRowCollection<FuelEntry> Fuel { get; set; }


        public class CombatSetting {
            // TODO Implement CombatSetting
        }

        [Serializable]
        [XmlRoot("row")]
        public class FuelEntry {
            [XmlAttribute("typeID")]
            public int TypeId { get; set; }

            [XmlAttribute("quantity")]
            public int Quantity { get; set; }
        }

        public class GeneralSetting {
            [XmlElement("usageFlags")]
            public int UsageFlags { get; set; }

            [XmlElement("deployFlags")]
            public int DeployFlags { get; set; }

            [XmlElement("allowCorporationMembers")]
            public bool AllowCorporationMembers { get; set; }

            [XmlElement("allowAllianceMembers")]
            public bool AllowAllianceMembers { get; set; }
        }
    }
}