// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 11-03-2014
// ***********************************************************************
// <copyright file="IndustryJobs.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Xml.Serialization;
using eZet.EveLib.EveOnlineModule.Util;

namespace eZet.EveLib.EveOnlineModule.Models.Character {
    /// <summary>
    ///     Represents a IndustryJobs response
    /// </summary>
    [Serializable]
    [XmlRoot("result")]
    public class IndustryJobs {
        /// <summary>
        ///     A list of industry jobs
        /// </summary>
        /// <value>The jobs.</value>
        [XmlElement("rowset")]
        public EveOnlineRowCollection<NewIndustryJob> Jobs { get; set; }

        /// <summary>
        ///     Represents a industry job
        /// </summary>
        [Serializable]
        [XmlRoot("row")]
        public class NewIndustryJob {
            /// <summary>
            ///     The job ID
            /// </summary>
            /// <value>The job identifier.</value>
            [XmlAttribute("jobID")]
            public long JobId { get; set; }

            /// <summary>
            ///     The installer entity ID
            /// </summary>
            /// <value>The installer identifier.</value>
            [XmlAttribute("installerID")]
            public long InstallerId { get; set; }

            /// <summary>
            ///     The installer's name
            /// </summary>
            /// <value>The name of the installer.</value>
            [XmlAttribute("installerName")]
            public string InstallerName { get; set; }

            /// <summary>
            ///     The id of the facility the job was installed in
            /// </summary>
            /// <value>The facility identifier.</value>
            [XmlAttribute("facilityID")]
            public long FacilityId { get; set; }

            /// <summary>
            ///     The solar system ID of the facility
            /// </summary>
            /// <value>The solar system identifier.</value>
            [XmlAttribute("solarSystemID")]
            public int SolarSystemId { get; set; }

            /// <summary>
            ///     The solar system name
            /// </summary>
            /// <value>The name of the solar system.</value>
            [XmlAttribute("solarSystemName")]
            public string SolarSystemName { get; set; }

            /// <summary>
            ///     The station ID
            /// </summary>
            /// <value>The station identifier.</value>
            [XmlAttribute("stationID")]
            public long StationId { get; set; }

            /// <summary>
            ///     The activity ID
            /// </summary>
            /// <value>The activity identifier.</value>
            [XmlAttribute("activityID")]
            public int ActivityId { get; set; }

            /// <summary>
            ///     The blueprint ID
            /// </summary>
            /// <value>The blueprint identifier.</value>
            [XmlAttribute("blueprintID")]
            public long BlueprintId { get; set; }

            /// <summary>
            ///     The blueprint type ID
            /// </summary>
            /// <value>The blueprint type identifier.</value>
            [XmlAttribute("blueprintTypeID")]
            public int BlueprintTypeId { get; set; }

            /// <summary>
            ///     The blueprint name
            /// </summary>
            /// <value>The name of the blueprint type.</value>
            [XmlAttribute("blueprintTypeName")]
            public string BlueprintTypeName { get; set; }

            /// <summary>
            ///     The location ID for the blueprint
            /// </summary>
            /// <value>The blueprint location identifier.</value>
            [XmlAttribute("blueprintLocationID")]
            public long BlueprintLocationId { get; set; }

            /// <summary>
            ///     The location ID for the job output
            /// </summary>
            /// <value>The output location identifier.</value>
            [XmlAttribute("outputLocationID")]
            public long OutputLocationId { get; set; }

            /// <summary>
            ///     The number of runs
            /// </summary>
            /// <value>The runs.</value>
            [XmlAttribute("runs")]
            public int Runs { get; set; }

            /// <summary>
            ///     The job cost
            /// </summary>
            /// <value>The cost.</value>
            [XmlAttribute("cost")]
            public decimal Cost { get; set; }

            /// <summary>
            ///     The team ID
            /// </summary>
            /// <value>The team identifier.</value>
            [XmlAttribute("teamID")]
            public int TeamId { get; set; }

            /// <summary>
            ///     The number of licensed runs
            /// </summary>
            /// <value>The licensed runs.</value>
            [XmlAttribute("licensedRuns")]
            public int LicensedRuns { get; set; }

            /// <summary>
            ///     The probability of success for invention
            /// </summary>
            /// <value>The probability.</value>
            [XmlAttribute("probability")]
            public float Probability { get; set; }

            /// <summary>
            ///     The type ID of the final product
            /// </summary>
            /// <value>The product type identifier.</value>
            [XmlAttribute("productTypeID")]
            public int ProductTypeId { get; set; }

            /// <summary>
            ///     The type name of the final product
            /// </summary>
            /// <value>The name of the product type.</value>
            [XmlAttribute("productTypeName")]
            public string ProductTypeName { get; set; }

            /// <summary>
            ///     The job status
            /// </summary>
            /// <value>The status.</value>
            [XmlAttribute("status")]
            public string Status { get; set; }

            /// <summary>
            ///     The time left on the job, in seconds
            /// </summary>
            /// <value>The time in seconds.</value>
            [XmlAttribute("timeInSeconds")]
            public int timeInSeconds { get; set; }

            /// <summary>
            ///     The start date
            /// </summary>
            /// <value>The start date.</value>
            [XmlIgnore]
            public DateTime StartDate { get; private set; }

            /// <summary>
            ///     The start date
            /// </summary>
            /// <value>The start date as string.</value>
            [XmlAttribute("startDate")]
            public string StartDateAsString {
                get { return StartDate.ToString(XmlHelper.DateFormat); }
                set { StartDate = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
            }

            /// <summary>
            ///     The end date
            /// </summary>
            /// <value>The end date.</value>
            [XmlIgnore]
            public DateTime EndDate { get; private set; }

            /// <summary>
            ///     The end date
            /// </summary>
            /// <value>The end date as string.</value>
            [XmlAttribute("endDate")]
            public string EndDateAsString {
                get { return EndDate.ToString(XmlHelper.DateFormat); }
                set { EndDate = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
            }


            /// <summary>
            ///     The pause date, if any
            /// </summary>
            /// <value>The pause date.</value>
            [XmlIgnore]
            public DateTime PauseDate { get; private set; }

            /// <summary>
            ///     The pause date, if any
            /// </summary>
            /// <value>The pause date as string.</value>
            [XmlAttribute("pauseDate")]
            public string PauseDateAsString {
                get { return PauseDate.ToString(XmlHelper.DateFormat); }
                set { PauseDate = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
            }

            /// <summary>
            ///     The date the job completed, if any
            /// </summary>
            /// <value>The completed date.</value>
            [XmlIgnore]
            public DateTime CompletedDate { get; private set; }

            /// <summary>
            ///     The date the job completed, if any
            /// </summary>
            /// <value>The completed date as string.</value>
            [XmlAttribute("completedDate")]
            public string CompletedDateAsString {
                get { return CompletedDate.ToString(XmlHelper.DateFormat); }
                set { CompletedDate = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
            }

            /// <summary>
            ///     The ID of the character that completed the job
            /// </summary>
            /// <value>The completed character identifier.</value>
            [XmlAttribute("completedCharacterID")]
            public long CompletedCharacterId { get; set; }

            /// <summary>
            ///     Gets or sets the successful runs.
            /// </summary>
            /// <value>The successful runs.</value>
            [XmlAttribute("successfulRuns")]
            public int SuccessfulRuns { get; set; }
        }
    }
}