using System;
using System.Xml.Serialization;

namespace eZet.Eve.EoLib.Model.EveApi.Core {

    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class CharacterInfo : XmlElement {

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

        [XmlIgnore]
        public DateTime CorporationDate { get; private set; }

        [XmlElement("corporationDate")]
        public string CorporationDateAsString {
            get { return CorporationDate.ToString(DateFormat); }
            set { CorporationDate = DateTime.ParseExact(value, DateFormat, null); }
        }

        [XmlElement("allianceID")]
        public long AllianceId { get; set; }

        [XmlElement("alliance")]
        public string AllianceName { get; set; }

        [XmlIgnore]
        public DateTime AllianceDate { get; private set; }

        [XmlElement("allianceDate")]
        public string AllianceDateAsString {
            get { return AllianceDate.ToString(DateFormat); }
            set { AllianceDate = DateTime.ParseExact(value, DateFormat, null); }
        }

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

            [XmlIgnore]
            public DateTime StartDate { get; private set; }
            
            [XmlAttribute("startDate")]
            public string StartDateAsString {
                get { return StartDate.ToString(DateFormat); }
                set { StartDate = DateTime.ParseExact(value, DateFormat, null); }
            }

        }
    }

}
