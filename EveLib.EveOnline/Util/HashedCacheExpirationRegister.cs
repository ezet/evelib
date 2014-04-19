using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace eZet.EveLib.Modules.Util {
    public class HashedCacheExpirationRegister : ICacheExpirationRegister {
        
        private static readonly SHA1CryptoServiceProvider Sha1 = new SHA1CryptoServiceProvider();

        private readonly ConcurrentDictionary<string, DateTime> _register = new ConcurrentDictionary<string, DateTime>();

        public virtual bool Restore(string key, DateTime value) {
            return _register.TryAdd(key, value);
        }

        public virtual void AddOrUpdate(Uri uri, DateTime cachedUntil) {
            string key = resolve(uri);
            _register.AddOrUpdate(key, cachedUntil, (k, v) => cachedUntil);
        }

        public virtual bool TryGetValue(Uri uri, out DateTime value) {
            string key = resolve(uri);
            return _register.TryGetValue(key, out value);
        }

        public IEnumerator<KeyValuePair<string, DateTime>> GetEnumerator() {
            return _register.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return ((IEnumerable) _register).GetEnumerator();
        }

        private static string resolve(Uri uri) {
            string file = uri.PathAndQuery;
            byte[] hash = Sha1.ComputeHash(Encoding.Unicode.GetBytes(file));
            return BitConverter.ToString(hash).Replace("-", "");
        }
    }
}