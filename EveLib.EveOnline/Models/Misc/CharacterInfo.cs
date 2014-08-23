using System;
using System.Xml.Serialization;
using eZet.EveLib.Modules.Util;

namespace eZet.EveLib.Modules.Models.Misc {
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class CharacterInfo {
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
            get { return CorporationDate.ToString(XmlHelper.DateFormat); }
            set { CorporationDate = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
        }

        [XmlElement("allianceID")]
        public long AllianceId { get; set; }

        [XmlElement("alliance")]
        public string AllianceName { get; set; }

        [XmlIgnore]
        public DateTime AllianceDate { get; private set; }

        [XmlElement("allianceDate")]
        public string AllianceDateAsString {
            get { return AllianceDate.ToString(XmlHelper.DateFormat); }
            set { AllianceDate = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
        }

        [XmlElement("lastKnownLocation")]
        public string LastKnownLocation { get; set; }

        [XmlElement("securityStatus")]
        public double SecurityStatus { get; set; }

        [XmlElement("rowset")]
        public EveOnlineRowCollection<Employment> EmploymentHistory { get; set; }

        /// <summary>
        /// Represents a employment entry
        /// </summary>
        [Serializable]
        [XmlRoot("row")]
        public class Employment {
            /// <summary>
            /// The employment record ID
            /// </summary>
            [XmlAttribute("recordID")]
            public long RecordId { get; set; }

            /// <summary>
            /// The corporation ID
            /// </summary>
            [XmlAttribute("corporationID")]
            public long CorporationId { get; set; }

            /// <summary>
            /// The corporation name
            /// </summary>
            [XmlAttribute("corporationName")]
            public string CorporationName { get; set; }

            /// <summary>
            /// The employment start date
            /// </summary>
            [XmlIgnore]
            public DateTime StartDate { get; private set; }

            [XmlAttribute("startDate")]
            public string StartDateAsString {
                get { return StartDate.ToString(XmlHelper.DateFormat); }
                set { StartDate = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
            }
        }
    }
}