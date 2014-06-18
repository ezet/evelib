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
            public EveOnlineRowCollection<ApiKeyEntity> KeyEntities { get; set; }

            [XmlAttribute("accessMask")]
            public int AccessMask { get; set; }

            [XmlAttribute("type")]
            public ApiKeyType Type { get; set; }

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
        public class ApiKeyEntity {
            [XmlAttribute("characterID")]
            public long CharacterId { get; set; }

            [XmlAttribute("characterName")]
            public string CharacterName { get; set; }

            [XmlAttribute("corporationID")]
            public long CorporationId { get; set; }

            [XmlAttribute("corporationName")]
            public string CorporationName { get; set; }

            [XmlAttribute("allianceID")]
            public long AllianceId { get; set; }

            [XmlAttribute("allianceName")]
            public string AllianceName { get; set; }

            [XmlAttribute("factionID")]
            public long FactionId { get; set; }

            [XmlAttribute("factionName")]
            public string FactionName { get; set; }
        }
    }
}