using System;
using System.Xml.Serialization;

namespace eZet.EveLib.Modules.Models.Misc {
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class ServerStatus {
        [XmlElement("serverOpen")]
        public string ServerOpen { get; set; }

        [XmlElement("onlinePlayers")]
        public int PlayersOnline { get; set; }
    }
}