
using System;
using System.IO.Ports;
using System.Xml.Serialization;

namespace eZet.Eve.EolNet.Dto.EveApi.Corporation {
    public class CorporationSheet : XmlResult {

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
        public long StationId { get; set; }

        [XmlElement("stationName")]
        public string StationName { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }

        [XmlElement("url")]
        public string Url { get; set; }

        [XmlElement("allianceID")]
        public long AllianceId { get; set; }

        [XmlElement("allianceName")]
        public string AllianceName { get; set; }

        [XmlElement("taxRage")]
        public string TaxRate { get; set; }

        [XmlElement("memberCount")]
        public int MemberCount { get; set; }

        [XmlElement("memberLimit")]
        public int MemberLimit { get; set; }

        [XmlElement("shares")]
        public int Shares { get; set; }

        [XmlElement("rowset")]
        public XmlRowSet<Division> Divisions { get; set; }

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
