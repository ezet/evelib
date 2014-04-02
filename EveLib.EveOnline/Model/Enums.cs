using System.Xml.Serialization;

namespace eZet.EveLib.EveOnline.Model {

    public enum OrderType {
        [XmlEnum("buy")]
        Buy,
        [XmlEnum("sell")]
        Sell
    }
}
