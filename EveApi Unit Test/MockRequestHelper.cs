using System.IO;

namespace eZet.Eve.EveApi.Test {
    public class MockRequestHelper : IRequestHelper {
        public string Request(string uri, string postString) {
            var baseDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            var relPath = uri.Substring(uri.Remove(uri.LastIndexOf("/")).LastIndexOf("/"));
            relPath = relPath.Remove(relPath.LastIndexOf(".aspx")).Replace("/", "\\");
            relPath = baseDir + "\\Xml" + relPath;
            string data;
            using (var reader = (File.OpenText(relPath))) {
                data = reader.ReadToEnd();
            }
            return data;
        }

        public string GeneratePostString(params object[] args) {
            return "";
        }

        public string GeneratePostString(ApiKey apiKey, params object[] args) {
            return "";
        }
    }
}
