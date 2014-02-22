using System.IO;
using eZet.Eve.EoLib.Entity;
using eZet.Eve.EoLib.Util;

namespace eZet.Eve.EoLib.Test.Mocks {
    public class TestRequester : IRequester {

        public string Request(string uri, params object[] args) {
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
    }
}
