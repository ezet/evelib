using eZet.EveLib.Core.Serializers;
using eZet.EveLib.EveCrestModule.RequestHandlers;

namespace eZet.EveLib.CrestClientModule {
    public class CrestClient {
        /// <summary>
        ///     The default URI used to access the CREST API. This can be overridded by setting the BasePublicUri.
        /// </summary>
        public const string DefaultUri = "http://public-crest.eveonline.com/";

        /// <summary>
        ///     The default URI used to access the authenticated CREST API. This can be overridded by setting the BasePublicUri.
        /// </summary>
        public const string AuthedUri = "https://crest-tq.eveonline.com/";

        public CrestClient() {
            RequestHandler = new CrestRequestHandler(new JsonSerializer());
        }

        public ICrestRequestHandler RequestHandler { get; set; }
    }
}