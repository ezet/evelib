using System;
using System.Xml.Serialization;

namespace eZet.EveLib.Modules.Models.Misc {
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class ErrorList {
        [XmlElement("rowset")]
        public EveOnlineRowCollection<Error> Errors { get; set; }

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