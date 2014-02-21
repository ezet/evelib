using eZet.Eve.EveApi.Dto.EveApi;
using eZet.Eve.EveApi.Util;

namespace eZet.Eve.EveApi.Entity {
    public abstract class BaseEntity {

        private const string UriBase = "https://api.eveonline.com";

        public ApiKey Key { get; private set; }

        protected BaseEntity() {
            Serializer = new XmlSerializerWrapper();
            RequestHelper = new RequestHelper();

        }

        protected BaseEntity(ApiKey key) : this() {
            Key = key;
        }

        public IXmlSerializer Serializer { get; set; }

        public IRequestHelper RequestHelper { get; set; }

        protected XmlResponse<T> request<T>(string path, T type, string postString = "") where T : XmlResult {
            var data = RequestHelper.Request(UriBase + path, postString);
            return Serializer.Deserialize<T>(data);
        }
    }


}
