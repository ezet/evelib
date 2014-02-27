using System;
using System.Xml.Serialization;

namespace eZet.Eve.EveLib.Model.EveApi.Account {

    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class CharacterList : XmlElement {

        [XmlElement("rowset")]
        public XmlRowSet<CharacterInfo> Characters;

    }
 
}