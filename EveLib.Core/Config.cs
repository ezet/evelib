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
        ///     relCachePath to ApplicationData folder.
        /// </summary>
        public static readonly string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                                                Separator;


        /// <summary>
        /// Gets or sets the image path.
        /// </summary>
        /// <value>The image path.</value>
        public static string ImagePath { get; set; }

        /// <summary>
        /// Gets or sets the cache path.
        /// </summary>
        /// <value>The cache path.</value>
        public static string CachePath { get; set; }

        /// <summary>
        ///     The cache factory
        /// </summary>
        public static Func<string, IEveLibCache> CacheFactory { get; set; }

        /// <summary>
        ///     UserAgent used for HTTP requests
        /// </summary>
        public static readonly string UserAgent = ConfigurationManager.AppSettings["eveLib.UserAgent"];

        static Config() {
            if (String.IsNullOrEmpty(UserAgent))
                UserAgent = "EveLib";
            string appName = ConfigurationManager.AppSettings["eveLib.AppData"];
            AppData += !string.IsNullOrEmpty(appName) ? appName : "EveLib";
            ImagePath = AppData + Separator + "Images";
            CachePath = AppData + Separator + "Cache";
            CacheFactory = module => new EveLibFileCache(CachePath + Separator + module, "register");
        }
    }
}