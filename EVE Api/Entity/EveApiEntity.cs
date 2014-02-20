using System.Security.Cryptography.X509Certificates;
using eZet.Eve.EveApi.Dto.EveApi;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace eZet.Eve.EveApi.Entity {
    public abstract class EveApiEntity {

        private const string UriBase = "https://api.eveonline.com";

        public ApiKey ApiKey { get; private set; }

        protected EveApiEntity() {
            Serializer = new XmlSerializerWrapper();
            RequestHelper = new RequestHelper();

        }

        protected EveApiEntity(ApiKey apiKey) : this() {
            ApiKey = apiKey;
        }

        public IXmlSerializer Serializer { get; set; }

        public IRequestHelper RequestHelper { get; set; }

        protected XmlResponse<T> request<T>(string path, T type, string postString = "") where T : XmlResult {
            var data = RequestHelper.Request(UriBase + path, postString);
            return Serializer.Deserialize<T>(data);
        }
    }


}
