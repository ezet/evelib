using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models {
    [DataContract]
    public class MarketHistoryResponse : EveCrestResponse {

        [DataMember(Name = "items")]
        public IList<MarketHistoryEntry> Entries { get; set; }


        public class MarketHistoryEntry {
            [DataMember(Name = "volume")]
            public long Volume { get; set; }

            [DataMember(Name = "orderCount")]
            public long OrderCount { get; set; }

            [DataMember(Name = "lowPrice")]
            public decimal LowPrice { get; set; }

            [DataMember(Name = "highPrice")]
            public decimal HighPrice { get; set; }

            [DataMember(Name = "avgPrice")]
            public decimal AvgPrice { get; set; }

            [DataMember(Name = "date")]
            public DateTime Date { get; set; }
        }

    }
}
