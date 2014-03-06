using System.Runtime.Serialization;
using System.Xml.Serialization;
using eZet.EveLib.EveMarketDataLib.JsonConverter;
using Newtonsoft.Json;

namespace eZet.EveLib.EveMarketDataLib.Model {
    [DataContract]
    [JsonConverter(typeof (RecentUploadsJsonConverter))]
    public class RecentUploads {
        [DataMember(Name = "rowset")]
        [XmlElement("rowset")]
        public RowCollection<RecentUploadsEntry> Uploads { get; set; }

        [DataContract]
        [XmlRoot("row")]
        public class RecentUploadsEntry {
            [DataMember(Name = "upload_type")]
            [XmlAttribute("upload_type")]
            public UploadType UploadType { get; set; }

            [DataMember(Name = "regionID")]
            [XmlAttribute("regionID")]
            public long RegionId { get; set; }

            [DataMember(Name = "typeID")]
            [XmlAttribute("typeID")]
            public long TypeId { get; set; }

            [DataMember(Name = "updated")]
            [XmlAttribute("updated")]
            public string Updated { get; set; }
        }
    }
}