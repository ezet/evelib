using System.IO;
using eZet.Eve.EolNet.Entity;
using eZet.Eve.EolNet.Util;

namespace eZet.Eve.EolNet.Test {
    public class TestRequestHelper : IRequestHelper {
        public string Request(string uri, string postString) {
// ReSharper disable once PossibleNullReferenceException
            var baseDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            var relPath = uri.Substring(uri.Remove(uri.LastIndexOf("/", System.StringComparison.Ordinal)).LastIndexOf("/", System.StringComparison.Ordinal));
            relPath = relPath.Remove(relPath.LastIndexOf(".aspx", System.StringComparison.Ordinal)).Replace("/", "\\");
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
