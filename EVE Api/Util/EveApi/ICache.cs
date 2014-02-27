using System;

namespace eZet.Eve.EveLib.Util.EveApi {
    public interface ICache {

        bool TryGet(Uri uri, out string data);

        void Insert(Uri uri, string data);

    }
}
