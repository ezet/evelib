using System;
using System.Configuration;
using System.Globalization;
using System.IO;
using eZet.EveLib.Core.Cache;
using static System.String;

namespace eZet.EveLib.Core {
    /// <summary>
    ///     Provides configuration and constants for the library.
    /// </summary>
    public static class Config {
        private static string _appData;

        /// <summary>
        ///     UserAgent used for HTTP requests
        /// </summary>
        public static readonly string UserAgent = ConfigurationManager.AppSettings["eveLib.UserAgent"];

        static Config() {
            Separator = Path.DirectorySeparatorChar.ToString(CultureInfo.InvariantCulture);
            if (IsNullOrEmpty(UserAgent))
                UserAgent = "EveLib";
            _appData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "EveLib");
            SetConfig();
        }

        /// <summary>
        ///     Directory Separator
        /// </summary>
        public static string Separator { get; set; }

        /// <summary>
        ///     Gets or sets the application data.
        /// </summary>
        /// <value>The application data.</value>
        public static string AppData {
            get { return _appData; }

            set {
                _appData = value;
                SetConfig();
            }
        }

        /// <summary>
        ///     Gets or sets the image path.
        /// </summary>
        /// <value>The image path.</value>
        public static string ImagePath { get; set; }

        /// <summary>
        ///     Gets or sets the cache path.
        /// </summary>
        /// <value>The cache path.</value>
        public static string CachePath { get; set; }

        /// <summary>
        ///     The cache factory
        /// </summary>
        public static Func<string, IEveLibCache> CacheFactory { get; set; }

        private static void SetConfig() {
            CachePath = Path.Combine(AppData, "Cache");
            ImagePath = Path.Combine(AppData, "Images");
            CacheFactory = module => new EveLibFileCache(Path.Combine(CachePath, module), "register");
        }
    }
}