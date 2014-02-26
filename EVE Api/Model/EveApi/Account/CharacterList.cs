using System;
using System.Xml.Serialization;

namespace eZet.Eve.EoLib.Model.EveApi.Account {

    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class CharacterList : XmlElement {

        [XmlElement("rowset")]
        public XmlRowSet<CharacterInfo> Characters;

    }
 
}