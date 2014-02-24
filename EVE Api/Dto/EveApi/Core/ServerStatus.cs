using System;
using System.Xml.Serialization;

namespace eZet.Eve.EoLib.Dto.EveApi.Core {

    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class ServerStatus : XmlElement {

        [XmlElement("serverOpen")]
        public string ServerOpen { get; set; }

        [XmlElement("onlinePlayers")]
        public int PlayersOnline { get; set; }

    }
}
