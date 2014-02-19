using System;
using System.Xml.Serialization;
using eZet.Eve.EveApi;
using eZet.Eve.EveApi.Dto.EveApi.Character;

namespace eZet.Eve.EveApi.Dto.EveApi.Account {

    [Serializable]
    [System.Diagnostics.DebuggerStepThroughAttribute]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    public class CharacterCollection : XmlResult {

        [XmlElement("rowset")]
        public XmlRowSet<Character.CharacterInfo> Characters;

        public override void SetApiKey(ApiKey key) {
            foreach (var character in Characters) {
                character.ApiKey = key;
            }
        }
    }
 
}