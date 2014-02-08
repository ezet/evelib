using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eZet.Eve.EveApi.Entity {
    public struct EveApiMeta {

        public byte Version { get; private set; }

        public DateTime CurrentTime { get; private set; }

        public DateTime CachedUntil { get; private set; }

        public EveApiMeta(byte version, string current, string cache) : this() {
            Version = version;
            CurrentTime = DateTime.Parse(current);
            CachedUntil = DateTime.Parse(cache);
        }

    }
}
