using System;

namespace eZet.EveLib.EveOnline.Util {
    public interface ICache {
        bool TryGet(Uri uri, out string data);

        void Insert(Uri uri, string data);
    }
}