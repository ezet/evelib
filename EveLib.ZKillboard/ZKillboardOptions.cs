using System;
using System.Collections.Generic;

namespace eZet.EveLib.Modules {
    /// <summary>
    /// Represents options for ZKillboard requests
    /// </summary>
    public class ZKillboardOptions {
        /// <summary>
        /// Represents the data formats for requests
        /// </summary>
        public enum DataFormat {
            /// <summary>
            /// JSON
            /// </summary>
            Json,
            /// <summary>
            /// XML
            /// </summary>
            Xml
        }

        /// <summary>
        /// Represents mail types
        /// </summary>
        public enum MailType {
            /// <summary>
            /// Kills
            /// </summary>
            Kills,
            /// <summary>
            /// Losses
            /// </summary>
            Losses,
            /// <summary>
            /// Kills and losses
            /// </summary>
            Both
        }

        /// <summary>
        /// Represents the order directions
        /// </summary>
        public enum OrderDirection {
            /// <summary>
            /// Descending order
            /// </summary>
            Descending,
            /// <summary>
            /// Ascending order
            /// </summary>
            Ascending
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public ZKillboardOptions() {
            CharacterId = new List<long>();
            CorporationId = new List<long>();
            AllianceId = new List<long>();
            FactionId = new List<long>();
            ShiptypeId = new List<long>();
            GroupId = new List<long>();
            SolarsystemId = new List<long>();
            RegionId = new List<long>();
        }

        /// <summary>
        /// Gets or sets the character ID
        /// </summary>
        public IList<long> CharacterId { get; set; }

        /// <summary>
        /// Gets or sets the corporation ID
        /// </summary>
        public IList<long> CorporationId { get; set; }

        /// <summary>
        /// Gets or sets the alliance ID
        /// </summary>
        public IList<long> AllianceId { get; set; }

        /// <summary>
        /// Gets or sets the faction ID
        /// </summary>
        public IList<long> FactionId { get; set; }

        /// <summary>
        /// Gets or sets the ship type ID
        /// </summary>
        public IList<long> ShiptypeId { get; set; }

        /// <summary>
        /// Gets or sets the group ID
        /// </summary>
        public IList<long> GroupId { get; set; }

        /// <summary>
        /// Gets or sets the solar system ID
        /// </summary>
        public IList<long> SolarsystemId { get; set; }

        /// <summary>
        /// Gets or sets the region ID
        /// </summary>
        public IList<long> RegionId { get; set; }

        /// <summary>
        /// Gets or sets the order direction
        /// </summary>
        public OrderDirection Order { get; set; }

        /// <summary>
        /// Gets or sets the limit for returned rows
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// Gets or sets the page 
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Gets or sets the start time
        /// </summary>
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// Gets or sets the end time
        /// </summary>
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// Gets or sets the year
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Gets or sets the month
        /// </summary>
        public int Month { get; set; }

        /// <summary>
        /// Gets or sets the week
        /// </summary>
        public int Week { get; set; }

        /// <summary>
        /// Gets or sets the format
        /// </summary>
        public DataFormat Format { get; set; }

        /// <summary>
        /// Gets or sets the before kill ID
        /// </summary>
        public long BeforeKillId { get; set; }

        /// <summary>
        /// Gets or sets the after kill ID
        /// </summary>
        public long AfterKillId { get; set; }

        /// <summary>
        /// Gets or sets the past seconds limit
        /// </summary>
        public int PastSeconds { get; set; }

        /// <summary>
        /// Gets or sets the kill ID
        /// </summary>
        public long KillId { get; set; }

        /// <summary>
        /// Set to true to ignore items
        /// </summary>
        public bool NoItems { get; set; }

        /// <summary>
        /// Set to true to ignore attackers
        /// </summary>
        public bool NoAttackers { get; set; }

        /// <summary>
        /// Set to true to only return killmails verified through API
        /// </summary>
        public bool ApiOnly { get; set; }

        /// <summary>
        /// Set to true to only return solo kills
        /// </summary>
        public bool Solo { get; set; }

        /// <summary>
        /// Set tot true to only return wspace kills
        /// </summary>
        public bool WSpace { get; set; }

        /// <summary>
        /// Creates and returns a query string for the options
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        internal string GetQueryString(string uri) {
            string queryString = uri;

            if (Solo)
                queryString += "/solo";
            if (WSpace)
                queryString += "/w-space";

            if (CharacterId.Count != 0)
                queryString += "/characterID/" + string.Join(",", CharacterId);
            if (CorporationId.Count != 0)
                queryString += "/corporationID/" + string.Join(",", CorporationId);
            if (AllianceId.Count != 0)
                queryString += "/allianceID/" + string.Join(",", AllianceId);
            if (FactionId.Count != 0)
                queryString += "/factionID/" + string.Join(",", FactionId);
            if (ShiptypeId.Count != 0)
                queryString += "/shipTypeID/" + string.Join(",", ShiptypeId);
            if (GroupId.Count != 0)
                queryString += "/groupID/" + string.Join(",", GroupId);
            if (SolarsystemId.Count != 0)
                queryString += "solarSystemID/" + string.Join(",", SolarsystemId);
            if (RegionId.Count != 0)
                queryString += "regionID/" + string.Join(",", RegionId);

            if (StartTime != null)
                queryString += "/startTime/" + StartTime.Value.ToString("yyyyMMddHHmm");
            if (EndTime != null)
                queryString += "/endTime/" + EndTime.Value.ToString("yyyyMMddHHmm");
            if (Year != 0)
                queryString += "/year/" + Year;
            if (Month != 0)
                queryString += "/month/" + Month;
            if (Week != 0)
                queryString += "/week/" + Week;


            if (BeforeKillId != 0)
                queryString += "/beforeKillID/" + BeforeKillId;
            if (AfterKillId != 0)
                queryString += "/afterKillID/" + AfterKillId;
            if (PastSeconds != 0)
                queryString += "/pastSeconds/" + PastSeconds;
            if (KillId != 0)
                queryString += "/killID" + KillId;


            if (Limit != 0)
                queryString += "/limit/" + Limit;
            else if (Page != 0)
                queryString += "/page/" + Page;


            if (Order == OrderDirection.Ascending)
                queryString += "/orderDirection/asc";


            if (NoItems)
                queryString += "/no-items";
            if (NoAttackers)
                queryString += "/no-attackers";
            if (ApiOnly)
                queryString += "/api-only";
            if (Format == DataFormat.Xml)
                queryString += "/xml";

            queryString += "/";
            return queryString;
        }
    }
}