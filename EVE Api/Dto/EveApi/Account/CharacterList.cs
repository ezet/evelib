using System;
using System.Xml.Serialization;
using eZet.Eve.EoLib.Entity;

namespace eZet.Eve.EoLib.Dto.EveApi.Account {

    [Serializable]
    [System.Diagnostics.DebuggerStepThroughAttribute]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    public class CharacterList : XmlElement {

        [XmlElement("rowset")]
        public XmlRowSet<CharacterInfo> Characters;

        public override void SetApiKey(ApiKey key) {
            foreach (var character in Characters) {
                character.ApiKey = key;
            }
        }
    }
 
}