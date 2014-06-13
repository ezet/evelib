using System;
using System.Xml.Serialization;

namespace eZet.EveLib.Modules.Models.Corporation {
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class CorporationSheet {
        [XmlElement("corporationID")]
        public long CorporationId { get; set; }

        [XmlElement("corporationName")]
        public string CorporationName { get; set; }

        [XmlElement("ticker")]
        public string Ticker { get; set; }

        [XmlElement("ceoID")]
        public long CeoId { get; set; }

        [XmlElement("ceoName")]
        public string CeoName { get; set; }

        [XmlElement("stationID")]
        public int StationId { get; set; }

        [XmlElement("stationName")]
        public string StationName { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }

        [XmlElement("url")]
        public string Url { get; set; }

        [XmlElement("allianceID")]
        public long AllianceId { get; set; }

        [XmlElement("factionID")]
        public long FactionId { get; set; }

        [XmlElement("taxRate")]
        public string TaxRate { get; set; }

        [XmlElement("memberCount")]
        public int MemberCount { get; set; }

        [XmlElement("memberLimit")]
        public int MemberLimit { get; set; }

        [XmlElement("shares")]
        public int Shares { get; set; }

        [XmlElement("rowset")]
        public EveOnlineRowCollection<Division> Divisions { get; set; }

        [XmlElement("logo")]
        public LogoData Logo { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class Division {
            [XmlAttribute("accountKey")]
            public int AccountKey { get; set; }

            [XmlAttribute("description")]
            public string Description { get; set; }
        }

        public class LogoData {
            [XmlElement("graphicID")]
            public int GraphicId { get; set; }

            [XmlElement("shape1")]
            public int Shape1 { get; set; }

            [XmlElement("shape2")]
            public int Shape2 { get; set; }

            [XmlElement("shape3")]
            public int Shape3 { get; set; }

            [XmlElement("color1")]
            public int Color1 { get; set; }

            [XmlElement("color2")]
            public int Color2 { get; set; }

            [XmlElement("color3")]
            public int Color3 { get; set; }
        }
    }
}