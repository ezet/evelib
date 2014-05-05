using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using eZet.EveLib.Core;

namespace eZet.EveLib.Modules.Util {
    public class EveXmlCache : IEveXmlCache {

        private static readonly SHA1CryptoServiceProvider Sha1 = new SHA1CryptoServiceProvider();

        private readonly IDictionary<string, DateTime> _register = new Dictionary<string, DateTime>();

        public EveXmlCache() {
            loadFromDisk();
        }

        public void Store(Uri uri, DateTime cacheTime, string data) {
            try {
                File.WriteAllText(Config.CachePath + Path.DirectorySeparatorChar + GetUriHash(uri), data);
                Store(uri, cacheTime);
            } catch (DirectoryNotFoundException) {
                Directory.CreateDirectory(Config.CachePath);
                File.WriteAllText(Config.CachePath + Path.DirectorySeparatorChar + GetUriHash(uri), data);
                Store(uri, cacheTime);
            }
        }

        public void Store(Uri uri, DateTime cacheTime) {
            string key = GetUriHash(uri);
            _register[key] = cacheTime;
            try {
                File.WriteAllLines(Config.CacheRegister,
        _register.Select(x => x.Key + "," + x.Value.ToString(CultureInfo.InvariantCulture)));
            } catch (DirectoryNotFoundException) {
                Directory.CreateDirectory(Config.CachePath);
                File.WriteAllLines(Config.CacheRegister,
        _register.Select(x => x.Key + "," + x.Value.ToString(CultureInfo.InvariantCulture)));
            }
        }

        public bool TryGet(Uri uri, out string data) {
            data = "";
            DateTime cacheExpirationTime;
            _register.TryGetValue(GetUriHash(uri), out cacheExpirationTime);
            if (DateTime.UtcNow < cacheExpirationTime) {
                try {
                    data = File.ReadAllText(Config.CachePath + Config.Separator + GetUriHash(uri));
                } catch (FileNotFoundException) {
                    Debug.WriteLine("URI is in the cache register but the file was not found.");
                }
            }
            return data != "";
        }

        public virtual bool TryGetExpirationDate(Uri uri, out DateTime value) {
            string key = GetUriHash(uri);
            return _register.TryGetValue(key, out value);
        }

        public string GetUriHash(Uri uri) {
            string fileName = uri.PathAndQuery;
            byte[] hash = Sha1.ComputeHash(Encoding.Unicode.GetBytes(fileName));
            return BitConverter.ToString(hash).Replace("-", "");
        }

        private void loadFromDisk() {
            try {
                string[] data =
                    File.ReadAllLines(Config.CacheRegister);
                foreach (string entry in data) {
                    string[] split = entry.Split(',');
                    _register[split[0]] = DateTime.Parse(split[1], CultureInfo.InvariantCulture);
                }
            } catch (DirectoryNotFoundException) {
            } catch (FileNotFoundException) {
            }
        }

    }
}