using System;
using System.IO;

namespace eZet.Eve.EoLib {
    public static class Configuration {

        public static string FileDir = @"..\..";

        public static string AppDataCache = Path.Combine(Environment.GetFolderPath(
            Environment.SpecialFolder.ApplicationData), "eZet" + Path.DirectorySeparatorChar + "EoLib" + Path.DirectorySeparatorChar + "Cache");

    }


}
