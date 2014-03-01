using System;
using System.Xml.Serialization;

namespace eZet.Eve.EveLib.Model.EveMarketData {

    [Serializable]
    [XmlType(AnonymousType = true)]
    public class RecentUploads {

        [XmlElement("rowset")]
        public XmlRowSet<RecentUploadsEntry> RecentUploads { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class RecentUploadsEntry {

            [XmlAttribute("upload_type")]
            public string UploadType { get; set; }

            [XmlAttribute("regionID")]
            public long RegionId { get; set; }

            [XmlAttribute("typeID")]
            public long TypeId { get; set; }

            [XmlAttribute("updated")]
            public string Updated { get; set; }
        }

    }
}
