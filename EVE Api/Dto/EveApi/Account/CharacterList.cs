using System;
using System.Xml.Serialization;

namespace eZet.Eve.EveApi.Dto.EveApi.Account {

    [Serializable]
    [System.Diagnostics.DebuggerStepThroughAttribute]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    public class CharacterList : XmlResult {

        [XmlElement("rowset")]
        public XmlRowSet<CharacterInfo> Characters;

        public override void SetApiKey(ApiKey key) {
            foreach (var character in Characters) {
                character.ApiKey = key;
            }
        }
    }
 
}