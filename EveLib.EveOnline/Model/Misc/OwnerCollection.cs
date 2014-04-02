using System;
using System.Xml.Serialization;

namespace eZet.EveLib.EveOnline.Model.Misc {
    [Serializable]
    [XmlRoot("result")]
    public class OwnerCollection {
        [XmlElement("rowset")]
        public RowCollection<Owner> Owners { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class Owner {
            [XmlAttribute("ownerID")]
            public long OwnerId { get; set; }

            [XmlAttribute("ownerName")]
            public string OwnerName { get; set; }

            [XmlAttribute("ownerGroupID")]
            public OwnerGroup OwnerGroup { get; set; }

        }
        public enum OwnerGroup {
            [XmlEnum("0")]
            None = 0,
            [XmlEnum("1")]
            Character = 1,
            [XmlEnum("2")]
            Corporation = 2,
            [XmlEnum("19")]
            Faction = 19,
            [XmlEnum("32")]
            Alliance = 32
        }

    }
}
