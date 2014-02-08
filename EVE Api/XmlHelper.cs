using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace eZet.Eve.EveApi {
    public static class XmlHelper {

        public static IEnumerable<XElement> getRows(XDocument xml) {
            return xml.Element("eveapi").Element("result").Element("rowset").Elements();
        }

    }
}
