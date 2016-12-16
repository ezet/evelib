using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using eZet.EveLib.Core.RequestHandlers;
using eZet.EveLib.Core.Serializers;

namespace eZet.EveLib.Test.EveXml.Mocks {
    public class StaticXmlRequestHandler : IRequestHandler {
        public StaticXmlRequestHandler(ISerializer serializer) {
            Serializer = serializer;
        }

        public ISerializer Serializer { get; set; }

        public async Task<T> RequestAsync<T>(Uri uri) {
            var directoryInfo = Directory.GetParent(Directory.GetCurrentDirectory());
            if (directoryInfo != null) {
                var baseDir = directoryInfo.FullName;
                var path = uri.PathAndQuery;
                var relPath =
                    path.Substring(path.Remove(path.LastIndexOf("/", StringComparison.Ordinal))
                        .LastIndexOf("/", StringComparison.Ordinal));
                relPath = relPath.Remove(relPath.LastIndexOf(".aspx", StringComparison.Ordinal)).Replace("/", "\\");
                relPath = baseDir + "\\Xml" + relPath;
                using (var reader = (File.OpenText(relPath))) {
                    var data = await reader.ReadToEndAsync().ConfigureAwait(false);
                    return Serializer.Deserialize<T>(data);
                }
            }
            throw new InvalidOperationException("Static XML directory not found.");
        }

        public Task<HttpWebResponse> GetResponseAsync(Uri uri) {
            throw new NotImplementedException();
        }
    }
}