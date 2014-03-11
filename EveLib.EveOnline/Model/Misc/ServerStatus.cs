using System;
using System.Xml.Serialization;

namespace eZet.EveLib.EveOnline.Model.Misc {
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class ServerStatus {
        [XmlElement("serverOpen")]
        public string ServerOpen { get; set; }

        [XmlElement("onlinePlayers")]
        public int PlayersOnline { get; set; }
    }
}