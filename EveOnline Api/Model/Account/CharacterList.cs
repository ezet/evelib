using System;
using System.Xml.Serialization;

namespace eZet.EveLib.EveOnline.Model.Account {
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class CharacterList : XmlElement {
        [XmlElement("rowset")] public RowCollection<CharacterInfo> Characters;
    }
}