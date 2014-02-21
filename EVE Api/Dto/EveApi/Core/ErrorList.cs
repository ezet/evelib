using System;
using System.Xml.Serialization;

namespace eZet.Eve.EolNet.Dto.EveApi.Core {
    public class ErrorList : XmlResult {

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
