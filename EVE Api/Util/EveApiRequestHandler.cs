using System;
using System.Globalization;
using System.IO;
using eZet.Eve.EoLib.Dto.EveApi;

namespace eZet.Eve.EoLib.Util {
    public abstract class EveApiRequestHandler {

        private static ICacheExpirationRegister _cacheExpirationRegister;

        protected static ICacheExpirationRegister CacheExpirationRegister {
            get {
                if (_cacheExpirationRegister == null)
                    load();
                return _cacheExpirationRegister;
            }
            set { _cacheExpirationRegister = value; }
        }

        public IXmlSerializer Serializer { get; private set; }

        protected EveApiRequestHandler(IXmlSerializer serializer) {
            Serializer = serializer;
        }

        public abstract XmlResponse<T> Request<T>(T type, Uri uri) where T : new();

        public abstract void SaveCacheState();

        private static readonly object CacheLock = new object();


        private static void load() {
            lock (CacheLock) {
                if (_cacheExpirationRegister != null) return;
                _cacheExpirationRegister = new HashedCacheExpirationRegister();
                try {
                    var data =
                        File.ReadAllLines(Configuration.AppDataPath + Path.DirectorySeparatorChar +
                                          Configuration.CacheFileName);
                    for (var i = 0; i < data.Length; ++i) {
                        var split = data[i].Split(',');
                        _cacheExpirationRegister.Restore(split[0], DateTime.Parse(split[1], CultureInfo.InvariantCulture));
                    }
                } catch (DirectoryNotFoundException e) {

                }
            }
        }
    }
}
