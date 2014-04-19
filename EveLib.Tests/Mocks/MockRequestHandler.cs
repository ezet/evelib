using System;
using System.IO;
using eZet.EveLib.Core.Util;
using eZet.EveLib.Modules.Util;

namespace eZet.EveLib.Test.Mocks {
    public class MockRequestHandler : CachedRequestHandler {
        private readonly ISerializer _serializer = new XmlSerializerWrapper();

        public MockRequestHandler(ISerializer serializer) : base(serializer) {
        }

        public override T Request<T>(Uri uri) {
            // ReSharper disable once PossibleNullReferenceException
            string baseDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string path = uri.PathAndQuery;
            string relPath =
                path.Substring(path.Remove(path.LastIndexOf("/", StringComparison.Ordinal))
                    .LastIndexOf("/", StringComparison.Ordinal));
            relPath = relPath.Remove(relPath.LastIndexOf(".aspx", StringComparison.Ordinal)).Replace("/", "\\");
            relPath = baseDir + "\\Xml" + relPath;
            string data;
            using (StreamReader reader = (File.OpenText(relPath))) {
                data = reader.ReadToEnd();
            }
            return _serializer.Deserialize<T>(data);
        }
    }
}