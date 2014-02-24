using System;
using System.IO;
using eZet.Eve.EoLib.Dto.EveApi;
using eZet.Eve.EoLib.Util;

namespace eZet.Eve.EoLib.Test.Mocks {
    public class TestRequester : IRequester {

        private readonly IXmlSerializer serializer = new XmlSerializerWrapper();

        public XmlResponse<T>Request<T>(T t, Uri uri) where T : XmlElement {
            // ReSharper disable once PossibleNullReferenceException
            var baseDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            var path = uri.PathAndQuery;
            var relPath = path.Substring(path.Remove(path.LastIndexOf("/", System.StringComparison.Ordinal)).LastIndexOf("/", System.StringComparison.Ordinal));
            relPath = relPath.Remove(relPath.LastIndexOf(".aspx", System.StringComparison.Ordinal)).Replace("/", "\\");
            relPath = baseDir + "\\Xml" + relPath;
            string data;
            using (var reader = (File.OpenText(relPath))) {
                data = reader.ReadToEnd();
            }
            return serializer.Deserialize<T>(data);
        }
    }
}
