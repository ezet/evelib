using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models {
    [DataContract]
    public class InvType {
        public long TypeId { get; set; }

        [DataMember(Name = "url")]
        public string Url { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        public long GroupId { get; set; }

        [DataMember(Name = "group")]
        public string Group { get; set; }

        public long MarketGroupId { get; set; }

        [DataMember(Name = "market_group")]
        public string MarketGroup { get; set; }

        [DataMember(Name = "mass")]
        public double Mass { get; set; }

        [DataMember(Name = "volume")]
        public double Volume { get; set; }

        [DataMember(Name = "capacity")]
        public double Capacity { get; set; }

        [DataMember(Name = "portion_size")]
        public int PortionSize { get; set; }

        [DataMember(Name = "race")]
        public string Race { get; set; }

        [DataMember(Name = "base_price")]
        public double BasePrice { get; set; }

        [DataMember(Name = "is_published")]
        public bool IsPublished { get; set; }

        [DataMember(Name = "chance_of_duplicating")]
        public double ChanceOfDuplicating { get; set; }
    }
}