using System.Xml.Serialization;

namespace eZet.Eve.EveApi.Dto.EveApi.Character {

    [System.SerializableAttribute]
    [System.Diagnostics.DebuggerStepThroughAttribute]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    public class MarketOrderCollection : XmlResult {

        [XmlElement("rowset")]
        public XmlRowSet<MarketOrder> Orders;
    }


}