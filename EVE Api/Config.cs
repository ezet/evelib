using System;
using System.Configuration;
using System.Globalization;
using System.IO;

namespace eZet.Eve.EveLib {
    /// <summary>
    ///     Provides configuration and constants for the library.
    /// </summary>
    public static class Config {
        public static readonly string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        public static readonly string Separator = Path.DirectorySeparatorChar.ToString(CultureInfo.InvariantCulture);

        public static readonly string CacheExpirationFileName = "cache";

        public static readonly string CachePath = AppData + Separator +
                                                  ConfigurationManager.AppSettings["eoLib.appData.cachePath"];

        public static readonly string ImagePath = AppData + Separator +
                                                  ConfigurationManager.AppSettings["eoLib.appData.imagePath"];

        public static readonly string ExpirationRegister = CachePath + Separator + CacheExpirationFileName;
    }
}