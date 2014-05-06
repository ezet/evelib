using System;
using System.Collections.Generic;

namespace eZet.EveLib.Modules {
    public class ZKillboardOptions {
        public enum OrderDirection {
            Descending,
            Ascending
        }

        public enum DataFormat {
            Json,
            Xml
        }

        public enum MailType {
            Kills,
            Losses,
            Both
        }

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


        public IList<long> CharacterId { get; set; }

        public IList<long> CorporationId { get; set; }

        public IList<long> AllianceId { get; set; }

        public IList<long> FactionId { get; set; }

        public IList<long> ShiptypeId { get; set; }

        public IList<long> GroupId { get; set; }

        public IList<long> SolarsystemId { get; set; }

        public IList<long> RegionId { get; set; }

        public OrderDirection Order { get; set; }

        public int Limit { get; set; }

        public int Page { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public int Year { get; set; }

        public int Month { get; set; }

        public int Week { get; set; }

        public DataFormat Format { get; set; }

        public long BeforeKillId { get; set; }

        public long AfterKillId { get; set; }

        public int PastSeconds { get; set; }

        public long KillId { get; set; }

        public bool NoItems { get; set; }

        public bool NoAttackers { get; set; }

        public bool ApiOnly { get; set; }

        public bool Solo { get; set; }

        public bool WSpace { get; set; }

        public string GetQueryString(string uri) {
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
