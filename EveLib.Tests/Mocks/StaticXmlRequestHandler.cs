using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using eZet.EveLib.Core.RequestHandlers;
using eZet.EveLib.Core.Serializers;

namespace eZet.EveLib.Test.Mocks {
    public class StaticXmlRequestHandler : IRequestHandler {
        public StaticXmlRequestHandler(ISerializer serializer) {
            Serializer = serializer;
        }

        public ISerializer Serializer { get; set; }

        public async Task<T> RequestAsync<T>(Uri uri) {
            DirectoryInfo directoryInfo = Directory.GetParent(Directory.GetCurrentDirectory()).Parent;
            if (directoryInfo != null) {
                string baseDir = directoryInfo.FullName;
                string path = uri.PathAndQuery;
                string relPath =
                    path.Substring(path.Remove(path.LastIndexOf("/", StringComparison.Ordinal))
                        .LastIndexOf("/", StringComparison.Ordinal));
                relPath = relPath.Remove(relPath.LastIndexOf(".aspx", StringComparison.Ordinal)).Replace("/", "\\");
                relPath = baseDir + "\\Xml" + relPath;
                using (StreamReader reader = (File.OpenText(relPath))) {
                    string data = await reader.ReadToEndAsync().ConfigureAwait(false);
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