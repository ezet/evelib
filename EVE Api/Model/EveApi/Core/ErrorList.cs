using System;
using System.Xml.Serialization;

namespace eZet.Eve.EveLib.Model.EveApi.Core {

    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class ErrorList : XmlElement {

        [XmlElement("rowset")]
        public XmlRowSet<Error> Errors { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class Error {

            [XmlAttribute("errorCode")]
            public int ErrorCode { get; set; }

            [XmlAttribute("errorText")]
            public string ErrorText { get; set; }
        }
    }

}
