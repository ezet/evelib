using System;
using System.Xml.Serialization;

namespace eZet.EveLib.Modules.Models {
    [Serializable]
    [XmlRoot("result")]
    public class NewIndustryJobs {

        [XmlElement("rowset")]
        public EveOnlineRowCollection<NewIndustryJob> Jobs { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class NewIndustryJob {

            [XmlAttribute("jobID")]
            public long JobId { get; set; }

            [XmlAttribute("installedID")]
            public long InstallerId { get; set; }

            [XmlAttribute("installerName")]
            public string InstallerName { get; set; }

            [XmlAttribute("facilityID")]
            public int FacilityId { get; set; }

            [XmlAttribute("solarSystemID")]
            public int SolarSystemId { get; set; }

            [XmlAttribute("solarSystemName")]
            public string SolarSystemName { get; set; }

            [XmlAttribute("stationID")]
            public int StationId { get; set; }

            [XmlAttribute("activityID")]
            public int ActivityId { get; set; }

            [XmlAttribute("blueprintID")]
            public int BlueprintId { get; set; }

            [XmlAttribute("blueprintTypeID")]
            public int BlueprintTypeId { get; set; }

            [XmlAttribute("blueprintTypeName")]
            public string BueprintTypeName { get; set; }

            [XmlAttribute("blueprintLocationID")]
            public int BlueprintLocationId { get; set; }

            [XmlAttribute("outputLocationID")]
            public int OutputLocationId { get; set; }

            [XmlAttribute("runs")]
            public int Runs { get; set; }

            [XmlAttribute("cost")]
            public decimal Cost { get; set; }

            [XmlAttribute("teamID")]
            public int TeamId { get; set; }

            [XmlAttribute("licensedRuns")]
            public int LicensedRuns { get; set; }

            [XmlAttribute("probability")]
            public float Probability { get; set; }

            [XmlAttribute("productTypeID")]
            public int ProductTypeId { get; set; }

            [XmlAttribute("productTypeName")]
            public string ProductTypeName { get; set; }

            [XmlAttribute("status")]
            public string Status { get; set; }

            [XmlAttribute("timeInSeconds")]
            public int timeInSeconds { get; set; }

            [XmlAttribute("startDate")]
            public DateTime StartDate { get; set; }

            [XmlAttribute("endDate")]
            public DateTime EndDate { get; set; }

            [XmlAttribute("pauseDate")]
            public DateTime PauseDate { get; set; }

            [XmlAttribute("completedDate")]
            public DateTime CompletedDate { get; set; }

            [XmlAttribute("completedCharacterID")]
            public long CompletedCharacterId { get; set; }

        }
    }
}
