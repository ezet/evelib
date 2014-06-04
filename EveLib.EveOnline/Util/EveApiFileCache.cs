using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using eZet.EveLib.Core;
using eZet.Utilities.Io;

namespace eZet.EveLib.Modules.Util {
    public class EveApiFileCache : IEveApiCache {

        private static readonly SHA1CryptoServiceProvider Sha1 = new SHA1CryptoServiceProvider();

        private readonly IDictionary<string, DateTime> _register = new Dictionary<string, DateTime>();

        private readonly TraceSource _trace = new TraceSource("EveLib", SourceLevels.All);

        private bool _isInitialized;

        private async Task initAsync() {
            if (_isInitialized) return;
            await loadRegisterFromDiskAsync().ConfigureAwait(false);
            _isInitialized = true;
        }

        public async Task StoreAsync(Uri uri, DateTime cacheTime, string data) {
            string key = getHash(uri);
            _register[key] = cacheTime;
            if (!Directory.Exists(Config.CachePath)) {
                _trace.TraceEvent(TraceEventType.Verbose, 0, "Creating cache directory");
                Directory.CreateDirectory(Config.CachePath);
            }
            try {
                var cacheTask = writeCacheDataToDiskAsync(uri, data);
                var registerTask = writeRegisterToDiskAsync();
                await Task.WhenAll(cacheTask, registerTask).ConfigureAwait(false);
            } catch (Exception) {
                _trace.TraceEvent(TraceEventType.Error, 0, "An error occured while writing to cache");
            }
        }

        public async Task<string> LoadAsync(Uri uri) {
            await initAsync().ConfigureAwait(false);
            string data = null;
            _trace.TraceEvent(TraceEventType.Verbose, 0, "CacheRegisterLookup: {0}", uri);
            DateTime cacheExpirationTime;
            var found = _register.TryGetValue(getHash(uri), out cacheExpirationTime);
            _trace.TraceEvent(TraceEventType.Verbose, 0, "CacheRegisterHit: {0}", found);
            if (found) {
                bool validCache = DateTime.UtcNow < cacheExpirationTime;
                _trace.TraceEvent(TraceEventType.Verbose, 0, "CacheIsValid: {0} ({1})", validCache, cacheExpirationTime);
                if (validCache) {
                    var filePath = Config.CachePath + Config.Separator + getHash(uri);
                    var fileExist = File.Exists(filePath);
                    _trace.TraceEvent(TraceEventType.Verbose, 0, "CacheDataFound: {0}", fileExist);
                    if (File.Exists(filePath)) {
                        try {
                            data = await FileEx.ReadAllTextAsync(Config.CachePath + Config.Separator + getHash(uri)).ConfigureAwait(false);
                            _trace.TraceEvent(TraceEventType.Verbose, 0, "Data successfully loaded from cache: {0}");
                        } catch (Exception) {
                            _trace.TraceEvent(TraceEventType.Error, 0, "Cache data could not be loaded: {0}", filePath);
                        }
                    }
                }
            }
            return data;
        }

        public virtual bool TryGetExpirationDate(Uri uri, out DateTime value) {
            string key = getHash(uri);
            return _register.TryGetValue(key, out value);
        }

        private Task writeRegisterToDiskAsync() {
            _trace.TraceEvent(TraceEventType.Verbose, 0, "Writing cache register to disk");
            return FileEx.WriteAllLinesAsync(Config.CacheRegister,
                _register.Select(x => x.Key + "," + x.Value.ToString(CultureInfo.InvariantCulture)));
        }

        private Task writeCacheDataToDiskAsync(Uri uri, string data) {
            _trace.TraceEvent(TraceEventType.Verbose, 0, "Writing cache data to disk: {0}", uri);
            return FileEx.WriteAllTextAsync(Config.CachePath + Path.DirectorySeparatorChar + getHash(uri), data);
        }

        private static string getHash(Uri uri) {
            string fileName = uri.PathAndQuery;
            byte[] hash = Sha1.ComputeHash(Encoding.Unicode.GetBytes(fileName));
            return BitConverter.ToString(hash).Replace("-", "");
        }

        private async Task loadRegisterFromDiskAsync() {
            _trace.TraceEvent(TraceEventType.Verbose, 0, "Loading cache register: {0}", Config.CacheRegister);
            if (!Directory.Exists(Config.CachePath)) {
                _trace.TraceEvent(TraceEventType.Warning, 0, "Cache directory not found: {0}", Config.CachePath);
                return;
            }
            if (!File.Exists(Config.CacheRegister)) {
                _trace.TraceEvent(TraceEventType.Warning, 0, "Cache register not found: {0}", Config.CacheRegister);
                return;
            }
            try {
                // read all lines
                string[] data = await
                    FileEx.ReadAllLinesAsync(Config.CacheRegister).ConfigureAwait(false);
                foreach (string entry in data) {
                    string[] split = entry.Split(',');
                    var date = DateTime.Parse(split[1], CultureInfo.InvariantCulture);
                    var fileName = split[0];
                    // if cache is still valid we insert it
                    if (date < DateTime.UtcNow)
                        _register[fileName] = date;
                    else {
                        // if cache is out of date we delete the data
                        if (File.Exists(fileName)) {
                            File.Delete(Config.CachePath + Config.Separator + fileName);
                        }
                    }

                }
                _trace.TraceEvent(TraceEventType.Verbose, 0, "CacheRegisterLoaded");
            } catch (Exception) {
                _trace.TraceEvent(TraceEventType.Error, 0, "Could not load cache register");
            }
        }

    }
}