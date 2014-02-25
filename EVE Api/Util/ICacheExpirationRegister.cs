using System;
using System.Collections.Generic;

namespace eZet.Eve.EoLib.Util {
    public interface ICacheExpirationRegister : IEnumerable<KeyValuePair<string, DateTime>> {

        bool Restore(string key, DateTime value);

        void AddOrUpdate(Uri uri, DateTime cachedUntil);

        bool TryGetValue(Uri uri, out DateTime value);

    }
}
