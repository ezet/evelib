using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using eZet.Eve.EveApi.Dto.EveCentral;

namespace eZet.Eve.EveApi.Entity {
    public class EveCentral : EveApiEntity {

        public const string UriBase = "http://api.eve-central.com";

        public MarketStatResponse getMarketStat() {
            const string uri = "/api/marketstat";
            var postString = "typeid=34&typeid=35&regionlimit=10000002";
            string data = RequestHelper.Request(UriBase + uri, postString);
            var serializer = new XmlSerializer(typeof(MarketStatResponse));
            MarketStatResponse xmlResponse;
            using (var reader = XmlReader.Create(new StringReader(data))) {
                xmlResponse = (MarketStatResponse)serializer.Deserialize(reader);
            }
            return xmlResponse;

        }

        public QuicklookResponse getQuicklook() {
            const string uri = "/api/quicklook";
            var postString = "typeid=34";
            string data = RequestHelper.Request(UriBase + uri, postString);
            var serializer = new XmlSerializer(typeof(QuicklookResponse));
            QuicklookResponse xmlResponse;
            using (var reader = XmlReader.Create(new StringReader(data))) {
                xmlResponse = (QuicklookResponse)serializer.Deserialize(reader);
            }
            return xmlResponse;
        }

        public void getQuicklookPath() {
            throw new NotImplementedException();
        }

        public void getHistory() {
            throw new NotImplementedException();
        }



    }
}
