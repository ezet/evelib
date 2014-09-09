using System;
using System.Configuration;
using System.Globalization;
using System.IO;
using eZet.EveLib.Core.Cache;

namespace eZet.EveLib.Core {
    /// <summary>
    ///     Provides configuration and constants for the library.
    /// </summary>
    public static class Config {
        /// <summary>
        ///     Directory Separator
        /// </summary>
        public static readonly string Separator = Path.DirectorySeparatorChar.ToString(CultureInfo.InvariantCulture);

        /// <summary>
        ///     Path to ApplicationData folder.
        /// </summary>
        public static readonly string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                                                Separator;

        /// <summary>
        ///     The cache factory
        /// </summary>
        public static Func<IEveLibCache> CacheFactory;

        /// <summary>
        ///     Filename for the Cache Register
        /// </summary>
        public static readonly string CacheRegisterFileName = "cache";

        /// <summary>
        ///     Path to cache directory
        /// </summary>
        public static readonly string CachePath;

        /// <summary>
        ///     Path to image directory
        /// </summary>
        public static readonly string ImagePath;

        /// <summary>
        ///     Full path to cache register file
        /// </summary>
        public static readonly string CacheRegister;

        /// <summary>
        ///     UserAgent used for HTTP requests
        /// </summary>
        public static readonly string UserAgent = ConfigurationManager.AppSettings["eveLib.UserAgent"];

        static Config() {
            if (String.IsNullOrEmpty(UserAgent))
                UserAgent = "EveLib";
            string appName = ConfigurationManager.AppSettings["eveLib.AppData"];
            CacheFactory = () => new EveLibFileCache();
            AppData += !string.IsNullOrEmpty(appName) ? appName : "EveLib";
            CachePath = AppData + Separator + "Cache";
            ImagePath = AppData + Separator + "Images";
            CacheRegister = CachePath + Separator + CacheRegisterFileName;
        }
    }
}