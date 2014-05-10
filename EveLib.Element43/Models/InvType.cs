namespace eZet.EveLib.Modules.Models {
    public class InvType {

        public string Url { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Group { get; set; }

        public string MarketGroup { get; set; }

        public long Mass { get; set; }

        public double Volume { get; set; }

        public double Capacity { get; set; }

        public int PortionSize { get; set; }

        public string Race { get; set; }

        public double BasePrice { get; set; }

        public bool IsPublished { get; set; }

        public double ChanceOfDuplicating { get; set; }
        
    }
}
