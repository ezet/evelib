using System;
using System.Xml.Serialization;

namespace eZet.Eve.EveApi.Dto.EveApi.Corporation {
    public class StarbaseDetails : XmlResult {

        [XmlElement("state")]
        public int State { get; set; }

        // TODO DateTime
        [XmlElement("stateTimestamp")]
        public string StateTimestamp { get; set; }

        [XmlElement("onlineTimestamp")]
        public string OnlineTimestamp { get; set; }

        [XmlElement("generalSettings")]
        public GeneralSetting GeneralSettings { get; set; }

        [XmlElement("rowset")]
        public XmlRowSet<FuelEntry> Fuel { get; set; }


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

        public class CombatSetting {
            
        }
        
        [Serializable]
        [XmlRoot("row")]
        public class FuelEntry {
            
            [XmlAttribute("typeID")]
            public long TypeId { get; set; }

            [XmlAttribute("quantity")]
            public int Quantity { get; set; }
        }
    }
}
