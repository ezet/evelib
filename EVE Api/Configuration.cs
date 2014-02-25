using System;
using System.IO;
using eZet.Eve.EoLib.Util;

namespace eZet.Eve.EoLib {
    public static class Configuration {

        public static string FileDir = @"..\..";

        public static string AppDataPath = Path.Combine(Environment.GetFolderPath(
            Environment.SpecialFolder.ApplicationData), "eZet" + Path.DirectorySeparatorChar + "EoLib" + Path.DirectorySeparatorChar + "Cache");

        public static string CacheFileName = "cache";

        public static Type DefaultRequester = typeof(IeCachedRequestHandler);

    }


}
