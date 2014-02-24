using System;

namespace eZet.Eve.EoLib.Util {
    public abstract class BaseRequester : IRequester {
        public ICacheHandler Cache { get; private set; }
        public abstract string Request(Uri uri);

        protected BaseRequester(ICacheHandler cache) {
            Cache = cache;
        }
    }
}
