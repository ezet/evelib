using System.Xml.Serialization;
using eZet.Eve.EveApi;
using eZet.Eve.EveApi.Dto.EveApi.Character;

namespace eZet.Eve.EveApi.Dto.EveApi.Account {


    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    public class ApiKeyInfo : XmlResult {

        [XmlElement("key")]
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

        [XmlAttribute("expires")]
        public string Expires { get; set; }

    }
}