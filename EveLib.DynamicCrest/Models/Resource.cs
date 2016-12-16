namespace eZet.EveLib.DynamicCrest.Models {
    public class Resource {
        public Resource(long id, string href) {
            this.id = id;
            this.href = href;
        }

        public long id { get; set; }

        public string href { get; set; }
    }
}