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
        /// <summary>
        ///     Directory Separator
        /// </summary>
        public static readonly string Separator = Path.DirectorySeparatorChar.ToString(CultureInfo.InvariantCulture);

        private static string _appData;
        public static string AppData {
            get {
                if (IsNullOrWhiteSpace(_appData)) {
                    _appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Separator;
                }
                return _appData;
            }

            set {
                _appData = value;
                SetConfig();
            }
        }


        static Config() {
            if (IsNullOrEmpty(UserAgent))
                UserAgent = "EveLib";
            SetConfig();
        }

        private static void SetConfig() {
            CachePath = AppData + Separator + "Cache";
            ImagePath = AppData + Separator + "Images";
            CacheFactory = module => new EveLibFileCache(Path.Combine(CachePath, module), "register");
        }


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

    }
}