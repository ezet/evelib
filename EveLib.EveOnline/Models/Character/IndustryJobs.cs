using System;
using System.Xml.Serialization;
using eZet.EveLib.Modules.Util;

namespace eZet.EveLib.Modules.Models.Character {
    /// <summary>
    /// Represents a IndustryJobs response
    /// </summary>
    [Serializable]
    [XmlRoot("result")]
    public class IndustryJobs {

        /// <summary>
        /// A list of industry jobs
        /// </summary>
        [XmlElement("rowset")]
        public EveOnlineRowCollection<NewIndustryJob> Jobs { get; set; }

        /// <summary>
        /// Represents a industry job
        /// </summary>
        [Serializable]
        [XmlRoot("row")]
        public class NewIndustryJob {
            /// <summary>
            /// The job ID
            /// </summary>
            [XmlAttribute("jobID")]
            public long JobId { get; set; }

            /// <summary>
            /// The installer entity ID
            /// </summary>
            [XmlAttribute("installerID")]
            public long InstallerId { get; set; }

            /// <summary>
            /// The installer's name
            /// </summary>
            [XmlAttribute("installerName")]
            public string InstallerName { get; set; }

            /// <summary>
            /// The id of the facility the job was installed in
            /// </summary>
            [XmlAttribute("facilityID")]
            public long FacilityId { get; set; }

            /// <summary>
            /// The solar system ID of the facility
            /// </summary>
            [XmlAttribute("solarSystemID")]
            public int SolarSystemId { get; set; }

            /// <summary>
            /// The solar system name
            /// </summary>
            [XmlAttribute("solarSystemName")]
            public string SolarSystemName { get; set; }

            /// <summary>
            /// The station ID
            /// </summary>
            [XmlAttribute("stationID")]
            public long StationId { get; set; }

            /// <summary>
            /// The activity ID
            /// </summary>
            [XmlAttribute("activityID")]
            public int ActivityId { get; set; }

            /// <summary>
            /// The blueprint ID
            /// </summary>
            [XmlAttribute("blueprintID")]
            public long BlueprintId { get; set; }

            /// <summary>
            /// The blueprint type ID
            /// </summary>
            [XmlAttribute("blueprintTypeID")]
            public int BlueprintTypeId { get; set; }

            /// <summary>
            /// The blueprint name
            /// </summary>
            [XmlAttribute("blueprintTypeName")]
            public string BueprintTypeName { get; set; }

            /// <summary>
            /// The location ID for the blueprint
            /// </summary>
            [XmlAttribute("blueprintLocationID")]
            public long BlueprintLocationId { get; set; }

            /// <summary>
            /// The location ID for the job output
            /// </summary>
            [XmlAttribute("outputLocationID")]
            public long OutputLocationId { get; set; }

            /// <summary>
            /// The number of runs
            /// </summary>
            [XmlAttribute("runs")]
            public int Runs { get; set; }

            /// <summary>
            /// The job cost
            /// </summary>
            [XmlAttribute("cost")]
            public decimal Cost { get; set; }

            /// <summary>
            /// The team ID
            /// </summary>
            [XmlAttribute("teamID")]
            public int TeamId { get; set; }

            /// <summary>
            /// The number of licensed runs
            /// </summary>
            [XmlAttribute("licensedRuns")]
            public int LicensedRuns { get; set; }

            /// <summary>
            /// The probability of success for invention
            /// </summary>
            [XmlAttribute("probability")]
            public float Probability { get; set; }

            /// <summary>
            /// The type ID of the final product
            /// </summary>
            [XmlAttribute("productTypeID")]
            public int ProductTypeId { get; set; }

            /// <summary>
            /// The type name of the final product
            /// </summary>
            [XmlAttribute("productTypeName")]
            public string ProductTypeName { get; set; }

            /// <summary>
            /// The job status
            /// </summary>
            [XmlAttribute("status")]
            public string Status { get; set; }

            /// <summary>
            /// The time left on the job, in seconds
            /// </summary>
            [XmlAttribute("timeInSeconds")]
            public int timeInSeconds { get; set; }

            /// <summary>
            /// The start date
            /// </summary>
            [XmlIgnore]
            public DateTime StartDate { get; private set; }

            /// <summary>
            /// The start date
            /// </summary>
            [XmlAttribute("startDate")]
            public string StartDateAsString {
                get { return StartDate.ToString(XmlHelper.DateFormat); }
                set { StartDate = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
            }

            /// <summary>
            /// The end date
            /// </summary>
            [XmlIgnore]
            public DateTime EndDate { get; private set; }

            /// <summary>
            /// The end date
            /// </summary>
            [XmlAttribute("endDate")]
            public string EndDateAsString {
                get { return EndDate.ToString(XmlHelper.DateFormat); }
                set { EndDate = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
            }


            /// <summary>
            /// The pause date, if any
            /// </summary>
            [XmlIgnore]
            public DateTime PauseDate { get; private set; }

            /// <summary>
            /// The pause date, if any
            /// </summary>
            [XmlAttribute("pauseDate")]
            public string PauseDateAsString {
                get { return PauseDate.ToString(XmlHelper.DateFormat); }
                set { PauseDate = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
            }

            /// <summary>
            /// The date the job completed, if any
            /// </summary>
            [XmlIgnore]
            public DateTime CompletedDate { get; private set; }

            /// <summary>
            /// The date the job completed, if any
            /// </summary>
            [XmlAttribute("completedDate")]
            public string CompletedDateAsString {
                get { return CompletedDate.ToString(XmlHelper.DateFormat); }
                set { CompletedDate = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
            }

            /// <summary>
            /// The ID of the character that completed the job
            /// </summary>
            [XmlAttribute("completedCharacterID")]
            public long CompletedCharacterId { get; set; }
        }
    }
}