using eZet.Eve.EolNet.Dto.EveApi;
using eZet.Eve.EolNet.Util;

namespace eZet.Eve.EolNet.Entity {
    public abstract class BaseEntity {

        protected abstract string UriBase { get; set; } 

        protected BaseEntity() {
            Serializer = new XmlSerializerWrapper();
            RequestHelper = new RequestHelper();
        }

        public IXmlSerializer Serializer { get; set; }

        public IRequestHelper RequestHelper { get; set; }

        protected XmlResponse<T> request<T>(string path, T type, string postString = "") where T : XmlResult {
            var data = RequestHelper.Request(UriBase + path, postString);
            return Serializer.Deserialize<T>(data);
        }
    }


}
