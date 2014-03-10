using System;
using System.Xml.Serialization;

namespace eZet.EveLib.EveOnline.Model.Core {
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class ErrorList : XmlElement {
        [XmlElement("rowset")]
        public RowCollection<Error> Errors { get; set; }

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