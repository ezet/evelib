using System.Xml.Serialization;

namespace eZet.EveLib.EveMarketDataLib.Model {
    public class RecentUploads {
        [XmlElement("rowset")]
        public RowCollection<RecentUploadsEntry> Uploads { get; set; }

        [XmlRoot("row")]
        public class RecentUploadsEntry {
            [XmlAttribute("upload_type")]
            public UploadType UploadType { get; set; }

            [XmlAttribute("regionID")]
            public long RegionId { get; set; }

            [XmlAttribute("typeID")]
            public long TypeId { get; set; }

            [XmlAttribute("updated")]
            public string Updated { get; set; }
        }
    }
}