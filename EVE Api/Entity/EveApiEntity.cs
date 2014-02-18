using System.Dynamic;
using eZet.Eve.EveApi.Dto.EveApi;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace eZet.Eve.EveApi.Entity {
    public abstract class EveApiEntity {

        private const string UriBase = "https://api.eveonline.com";

        public ApiKey ApiKey { get; private set; }

        protected EveApiEntity() {
            
        }

        protected EveApiEntity(ApiKey apiKey) {
            ApiKey = apiKey;
        }

        protected XmlResponse<T> request<T>(string uri, string postString, T type) where T : XmlResult {
            string data = WebHelper.Request(UriBase + uri, postString);
            var serializer = new XmlSerializer(typeof(XmlResponse<T>));
            XmlResponse<T> xmlResponse;
            using (var reader = XmlReader.Create(new StringReader(data))) {
                xmlResponse = (XmlResponse<T>)serializer.Deserialize(reader);
            }
            return xmlResponse;
        }

        protected XmlResponse<T> request<T>(string uri, T type) where T : XmlResult {
            string data = WebHelper.Request(UriBase + uri, "");
            var serializer = new XmlSerializer(typeof(XmlResponse<T>));
            XmlResponse<T> xmlResponse;
            using (var reader = XmlReader.Create(new StringReader(data))) {
                xmlResponse = (XmlResponse<T>)serializer.Deserialize(reader);
            }
            return xmlResponse;
        }
    }
}
