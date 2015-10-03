using System;
using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Links;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    [DataContract]
    public sealed class SovCampaignsCollection : CollectionResource<SovCampaignsCollection, SovCampaignsCollection.Campaign> {

        public SovCampaignsCollection() {
            ContentType = "application/vnd.ccp.eve.SovCampaignsCollection-v1+json; charset=utf-8";
        }


        [DataContract]
        public class Campaign {
            
            [DataMember(Name = "eventType")]
            public int eventType { get; set; } 

            [DataMember(Name = "campaignID")]
            public int CampaignId { get; set; }

            [DataMember(Name = "sourceSolarSystem")]
            public LinkedEntity<SolarSystem> SourceSolarSystem { get; set; }

            [DataMember(Name = "sourceItemID")]
            public long SourceItemId { get; set; }

            [DataMember(Name = "startTime")]
            public DateTime StartTime { get; set; }

            [DataMember(Name = "constellation")]
            public LinkedEntity<Constellation> Constellation { get; set; }

            [DataMember(Name = "attackers")]
            public AttackerEntity Attackers { get; set; }

            [DataMember(Name = "defender")]
            public DefenderEntity Defender { get; set; }
        }

        [DataContract]
        public class DefenderEntity {
            
            [DataMember(Name = "defender")]
            public LinkedEntity<Alliance> Defender { get; set; }

            [DataMember(Name = "score")]
            public float Score { get; set; }

        }

        [DataContract]
        public class AttackerEntity {
            [DataMember(Name = "score")]
            public float Score { get; set; }
        }
    }
}
