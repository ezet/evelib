using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace eZet.Eve.EoLib.Util {
    public class HashedCacheExpirationRegister : ICacheExpirationRegister  {

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
            return uri.PathAndQuery.Replace("/", "");
        }

        public IEnumerator<KeyValuePair<string, DateTime>> GetEnumerator() {
            return register.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return ((IEnumerable) register).GetEnumerator();
        }
    }
}
