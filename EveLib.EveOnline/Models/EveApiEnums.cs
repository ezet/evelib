using System.Xml.Serialization;

namespace eZet.EveLib.Modules.Models {
    public enum OrderType {
        [XmlEnum("buy")] Buy,
        [XmlEnum("sell")] Sell
    }
}