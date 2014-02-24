using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;

namespace eZet.Eve.EoLib.Util {
    public class FileCacheHandler : ICacheHandler {

        private readonly string cachePath = Configuration.AppDataCache;

        private static ConcurrentDictionary<string, DateTime> cache;

        public FileCacheHandler() {

        }


        public bool TryGet(Uri uri, out string data) {
            data = "";
            DateTime cachedUntil;
            var filePath = resolveFile(uri);
            if (!cache.TryGetValue(filePath, out cachedUntil)) {
                return false;
            }
            if (DateTime.UtcNow > cachedUntil) {
                return false;
            }
            using (var file = File.OpenText(cachePath + Path.DirectorySeparatorChar + filePath)) {
                data = file.ReadToEnd();
            }
            return true;
        }

        public void Store(Uri uri, string data) {
            var filePath = resolveFile(uri);
            using (var file = File.CreateText(cachePath + Path.DirectorySeparatorChar + filePath)) {
                file.Write(data);
            }
            
        }

        private static string resolveFile(Uri uri) {
            return Path.DirectorySeparatorChar + uri.AbsolutePath.Replace("/", "-").Replace(".aspx", "");
        }
    }
}
