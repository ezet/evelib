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
        ///     relCachePath to image directory
        /// </summary>
        public static readonly string ImagePath;

        /// <summary>
        ///     The cache factory
        /// </summary>
        public static Func<IEveLibCache> CacheFactory;

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
            CacheFactory = () => new EveLibFileCache(AppData + Separator + "EveXmlCache", "register");
        }
    }
}