using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Security.Cryptography;
using System.Text;

namespace eZet.EveLib.EveOnlineLib.Util {
    public class HashedCacheExpirationRegister : ICacheExpirationRegister {
        private static readonly SHA1CryptoServiceProvider Sha1 = new SHA1CryptoServiceProvider();

        private readonly ConcurrentDictionary<string, DateTime> register = new ConcurrentDictionary<string, DateTime>();

        public virtual bool Restore(string key, DateTime value) {
            return register.TryAdd(key, value);
        }

        public virtual void AddOrUpdate(Uri uri, DateTime cachedUntil) {
            string key = resolve(uri);
            register.AddOrUpdate(key, cachedUntil, (k, v) => cachedUntil);
        }

        public virtual bool TryGetValue(Uri uri, out DateTime value) {
            string key = resolve(uri);
            return register.TryGetValue(key, out value);
        }

        public IEnumerator<KeyValuePair<string, DateTime>> GetEnumerator() {
            return register.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return ((IEnumerable) register).GetEnumerator();
        }

        private static string resolve(Uri uri) {
            Contract.Requires(uri != null);
            string file = uri.PathAndQuery.Replace("/", "");
            byte[] hash = Sha1.ComputeHash(Encoding.Unicode.GetBytes(file));
            return BitConverter.ToString(hash).Replace("-", "");
        }
    }
}