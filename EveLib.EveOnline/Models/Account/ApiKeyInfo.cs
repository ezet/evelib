using System;
using System.Xml.Serialization;
using eZet.EveLib.Modules.Util;

namespace eZet.EveLib.Modules.Models.Account {
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class ApiKeyInfo {
        [XmlElement("key")]
        public ApiKeyData Key { get; set; }

        public class ApiKeyData {
            [XmlElement("rowset")]
            public EveOnlineRowCollection<CharacterInfo> Characters { get; set; }

            [XmlAttribute("accessMask")]
            public int AccessMask { get; set; }

            [XmlAttribute("type")]
            public string Type { get; set; }

            [XmlIgnore]
            public DateTime ExpireDate { get; private set; }

            [XmlAttribute("expires")]
            public string ExpireDateAsString {
                get { return ExpireDate.ToString(XmlHelper.DateFormat); }
                set {
                    ExpireDate = value == "" ? DateTime.MinValue : DateTime.ParseExact(value, XmlHelper.DateFormat, null);
                }
            }
        }

        [Serializable]
        [XmlRoot("row", IsNullable = false)]
        public class CharacterInfo {
            [XmlAttribute("characterName")]
            public string CharacterName { get; set; }

            [XmlAttribute("characterID")]
            public long CharacterId { get; set; }

            [XmlAttribute("corporationName")]
            public string CorporationName { get; set; }

            [XmlAttribute("corporationID")]
            public long CorporationId { get; set; }
        }
    }
}