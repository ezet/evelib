using System;
using System.Net;
using eZet.Eve.EoLib.Dto.EveApi;

namespace eZet.Eve.EoLib.Util {
    public class WebClientRequestHandler : EveApiRequestHandler {

        private readonly string cachePath = Configuration.AppDataPath;

        
        public WebClientRequestHandler(IXmlSerializer serializer) : base(serializer) {
        }

        public override XmlResponse<T> Request<T>(T type, Uri uri) {
            DateTime cachedUntil;
            if (CacheExpirationRegister.TryGetValue(uri, out cachedUntil)) {
                
            }

            var client = new WebClient();

            var data = client.DownloadString(uri);



            throw new NotImplementedException();
        }

        public override void SaveCacheState() {
            throw new NotImplementedException();
        }
    }
}
