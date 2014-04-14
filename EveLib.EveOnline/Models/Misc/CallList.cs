using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using eZet.EveLib.Modules.Util;

namespace eZet.EveLib.Modules.Models.Misc {
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class CallList : IXmlSerializable {
        [XmlElement("rowset")]
        public EveOnlineRowCollection<CallGroup> CallGroups { get; set; }


        [XmlElement("rowset")]
        public EveOnlineRowCollection<Call> Calls { get; set; }


        public XmlSchema GetSchema() {
            throw new NotImplementedException();
        }

        public void ReadXml(XmlReader reader) {
            var xml = new XmlHelper(reader);
            CallGroups = xml.deserializeRowSet<CallGroup>("callGroups");
            Calls = xml.deserializeRowSet<Call>("calls");
        }

        public void WriteXml(XmlWriter writer) {
            throw new NotImplementedException();
        }

        [Serializable]
        [XmlRoot("row")]
        public class Call {
            [XmlAttribute("accessMask")]
            public int AccessMask { get; set; }

            [XmlAttribute("type")]
            public string Character { get; set; }

            [XmlAttribute("name")]
            public string Name { get; set; }

            [XmlAttribute("groupID")]
            public long groupId { get; set; }

            [XmlAttribute("description")]
            public string Description { get; set; }
        }

        [Serializable]
        [XmlRoot("row")]
        public class CallGroup {
            [XmlAttribute("groupID")]
            public long GroupId { get; set; }

            [XmlAttribute("name")]
            public string GroupName { get; set; }

            [XmlAttribute("description")]
            public string Description { get; set; }
        }
    }
}