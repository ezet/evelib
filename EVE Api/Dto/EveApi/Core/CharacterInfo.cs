using System;
using System.Xml.Serialization;

namespace eZet.Eve.EveApi.Dto.EveApi.Core {
    public class CharacterInfo : XmlResult {

        [XmlElement("characterID")]
        public long CharacterId { get; set; }

        [XmlElement("characterName")]
        public string CharacterName { get; set; }

        [XmlElement("race")]
        public string Race { get; set; }

        [XmlElement("bloodline")]
        public string Bloodline { get; set; }

        [XmlElement("accountBalance")]
        public string AccountBalance { get; set; }

        [XmlElement("skillPoints")]
        public int SkillPoints { get; set; }

        [XmlElement("shipName")]
        public string ShipName { get; set; }

        [XmlElement("shipTypeID")]
        public long ShipTypeId { get; set; }

        [XmlElement("shipTypeName")]
        public string ShipTypeName { get; set; }

        [XmlElement("corporationID")]
        public long CorporationId { get; set; }

        [XmlElement("corporation")]
        public string CorporationName { get; set; }

        [XmlElement("corporationDate")]
        public string CorporationDate { get; set; }

        [XmlElement("allianceID")]
        public long AllianceId { get; set; }

        [XmlElement("alliance")]
        public string AllianceName { get; set; }

        [XmlElement("allianceDate")]
        public string AllianceDate { get; set; }

        [XmlElement("lastKnownLocation")]
        public string LastKnownLocation { get; set; }

        [XmlElement("securityStatus")]
        public double SecurityStatus { get; set; }

        [XmlElement("rowset")]
        public XmlRowSet<Employment> EmploymentHistory { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class Employment {

            [XmlAttribute("recordID")]
            public long RecordId { get; set; }

            [XmlAttribute("corporationID")]
            public long CorporationId { get; set; }

            [XmlAttribute("startDate")]
            public string StartDate { get; set; }

        }
    }

}
