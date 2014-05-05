using System;
using System.Configuration;
using System.Globalization;
using System.IO;

namespace eZet.EveLib.Core {
    /// <summary>
    ///     Provides configuration and constants for the library.
    /// </summary>
    public static class Config {

        public static readonly string Separator = Path.DirectorySeparatorChar.ToString(CultureInfo.InvariantCulture);

        public static readonly string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Separator; 

        public static readonly string CacheExpirationFileName = "cache";

        public static readonly string CachePath;

        public static readonly string ImagePath;

        public static readonly string CacheRegister;

        static Config() {
            var appName = ConfigurationManager.AppSettings["eveLib.AppData"];
            AppData += !string.IsNullOrEmpty(appName) ? appName : "EveLib";
            CachePath = AppData + Separator + "Cache";
            ImagePath = AppData + Separator + "Images";
            CacheRegister = CachePath + Separator + CacheExpirationFileName;
        }
    }
}