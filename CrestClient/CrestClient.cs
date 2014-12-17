using eZet.EveLib.Core.Serializers;
using eZet.EveLib.Modules.RequestHandlers;

namespace eZet.EveLib.CrestClient {
    public class CrestClient {

        public CrestClient() {
            RequestHandler = new CrestRequestHandler(new JsonSerializer());
        }

        /// <summary>
        ///     The default URI used to access the CREST API. This can be overridded by setting the BasePublicUri.
        /// </summary>
        public const string DefaultUri = "http://public-crest.eveonline.com/";

        /// <summary>
        ///     The default URI used to access the authenticated CREST API. This can be overridded by setting the BasePublicUri.
        /// </summary>
        public const string AuthedUri = "https://crest-tq.eveonline.com/";

        public ICrestRequestHandler RequestHandler { get; set; }
        

    }
}
