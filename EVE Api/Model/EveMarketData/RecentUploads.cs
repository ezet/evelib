using System;
using System.Xml.Serialization;
using eZet.Eve.EveLib.Entity.EveMarketData;

namespace eZet.Eve.EveLib.Model.EveMarketData {

    [Serializable]
    [XmlType(AnonymousType = true)]
    public class RecentUploads {

        [XmlElement("rowset")]
        public XmlRowSet<RecentUploadsEntry> Uploads { get; set; }

        [Serializable]
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
