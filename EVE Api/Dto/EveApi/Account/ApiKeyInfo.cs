using System;
using System.Xml.Serialization;
using eZet.Eve.EolNet.Entity;

namespace eZet.Eve.EolNet.Dto.EveApi.Account {

    [Serializable]
    [System.Diagnostics.DebuggerStepThroughAttribute]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    public class ApiKeyInfo : XmlResult {

        [XmlElement("Key")]
        public ApiKeyData Key { get; set; }

        public override void SetApiKey(ApiKey key) {
            foreach (var character in Key.Characters) {
                character.ApiKey = key;
            }
        }

    }

    public class ApiKeyData {

        [XmlElement("rowset")]
        public XmlRowSet<CharacterInfo> Characters { get; set; }

        [XmlAttribute("accessMask")]
        public int AccessMask { get; set; }

        [XmlAttribute("type")]
        public string Type { get; set; }

        [XmlIgnore]
        public DateTime ExpireDate { get; private set; }

        [XmlAttribute("expires")]
        public string ExpiresAsString {
            get { return ExpireDate.ToString(XmlResult.DateFormat); }
            set { ExpireDate = DateTime.ParseExact(value, XmlResult.DateFormat, null); }
        }

    }
}