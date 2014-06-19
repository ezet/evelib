using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using eZet.EveLib.Modules.JsonConverters;
using Newtonsoft.Json;

namespace eZet.EveLib.Modules.Models {
    [DataContract]
    [JsonConverter(typeof (EmdRecentUploadsJsonConverter))]
    public class EmdRecentUploads {
        [DataMember(Name = "rowset")]
        [XmlElement("rowset")]
        public EveMarketDataRowCollection<RecentUploadsEntry> Uploads { get; set; }

        [DataContract]
        [XmlRoot("row")]
        public class RecentUploadsEntry {
            [DataMember(Name = "upload_type")]
            [XmlAttribute("upload_type")]
            public UploadType UploadType { get; set; }

            [DataMember(Name = "regionID")]
            [XmlAttribute("regionID")]
            public int RegionId { get; set; }

            [DataMember(Name = "typeID")]
            [XmlAttribute("typeID")]
            public int TypeId { get; set; }

            [DataMember(Name = "updated")]
            [XmlAttribute("updated")]
            public DateTime Updated { get; set; }
        }
    }
}