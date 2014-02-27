using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace eZet.Eve.EveLib.Util.EveApi {
    public class HashedCacheExpirationRegister : ICacheExpirationRegister  {

        private static readonly SHA1CryptoServiceProvider Sha1 = new SHA1CryptoServiceProvider();

        private readonly ConcurrentDictionary<string, DateTime> register = new ConcurrentDictionary<string, DateTime>();

        public virtual bool Restore(string key, DateTime value) {
            return register.TryAdd(key, value);
        }

        public virtual void AddOrUpdate(Uri uri, DateTime cachedUntil) {
           var key = resolve(uri);
           register.AddOrUpdate(key, cachedUntil, (k, v) => cachedUntil);
        }

        public virtual bool TryGetValue(Uri uri, out DateTime value) {
            var key = resolve(uri);
            return register.TryGetValue(key, out value);
        }

        private static string resolve(Uri uri) {
            var file = uri.PathAndQuery.Replace("/", "");
            var hash = Sha1.ComputeHash(System.Text.Encoding.Unicode.GetBytes(file));
            return BitConverter.ToString(hash).Replace("-", "");
        }

        public IEnumerator<KeyValuePair<string, DateTime>> GetEnumerator() {
            return register.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return ((IEnumerable) register).GetEnumerator();
        }
    }
}
