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

        public static readonly string CacheRegisterFileName = "cache";

        public static readonly string CachePath;

        public static readonly string ImagePath;

        public static readonly string CacheRegister;

        public static readonly string UserAgent = ConfigurationManager.AppSettings["eveLib.UserAgent"];

        static Config() {
            if (String.IsNullOrEmpty(UserAgent))
                UserAgent = "EveLib";
            var appName = ConfigurationManager.AppSettings["eveLib.AppData"];
            AppData += !string.IsNullOrEmpty(appName) ? appName : "EveLib";
            CachePath = AppData + Separator + "Cache";
            ImagePath = AppData + Separator + "Images";
            CacheRegister = CachePath + Separator + CacheRegisterFileName;
        }
    }
}