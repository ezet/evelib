using System;

namespace eZet.Eve.EoLib.Util {
    public interface ICacheHandler {

        bool TryGet(Uri uri, out string data);

        void Store(Uri uri, string data);

    }
}
