using System;

namespace eZet.Eve.EoLib.Util {
    public interface ICacheHandler {

        bool TryGet(Uri uri, out string data);

        void Add(Uri uri, string data);

        void SaveState();

    }
}
