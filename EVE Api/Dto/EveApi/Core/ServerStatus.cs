using System.Xml.Serialization;

namespace eZet.Eve.EoLib.Dto.EveApi.Core {
    public class ServerStatus : XmlElement {

        [XmlElement("serverOpen")]
        public string ServerOpen { get; set; }

        [XmlElement("onlinePlayers")]
        public int PlayersOnline { get; set; }

    }
}
