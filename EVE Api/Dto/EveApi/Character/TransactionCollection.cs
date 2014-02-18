using System.Xml.Serialization;

namespace eZet.Eve.EveApi.Dto.EveApi.Character {


    [System.SerializableAttribute]
    [System.Diagnostics.DebuggerStepThroughAttribute]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    public class TransactionCollection : XmlResult {

        [XmlElement("rowset")]
        public XmlRowSet<Transaction> Transactions { get; set; }

    }


}