using System;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web.Configuration;
using eZet.Eve.EoLib.Model.EveApi;

namespace eZet.Eve.EoLib.Util.EveApi {
    /// <summary>
    /// Provides basic properties and methods for Eve Api RequestHandler objects.
    /// </summary>
    public abstract class BaseRequestHandler : IRequestHandler {

        /// <summary>
        /// A lock for the Cache
        /// </summary>
        private static readonly object CacheLock = new object();

 
        /// <summary>
        /// Backing field for CacheExpirationRegister.
        /// </summary>
        private static ICacheExpirationRegister _cacheExpirationRegister;

        /// <summary>
        /// A register for cached until values.
        /// </summary>
        protected static ICacheExpirationRegister CacheExpirationRegister {
            get {
                if (_cacheExpirationRegister == null)
                    load();
                return _cacheExpirationRegister;
            }
            set { _cacheExpirationRegister = value; }
        }

        /// <summary>
        /// A serializer for deserializing objects.
        /// </summary>
        public IXmlSerializer Serializer { get; private set; }


        protected BaseRequestHandler(IXmlSerializer serializer) {
            Serializer = serializer;
        }

        /// <summary>
        /// Performs a request using the specified URI.
        /// </summary>
        /// <typeparam name="T">Type of XmlResponse.</typeparam>
        /// <param name="type">An object of the type to return in the response.</param>
        /// <param name="uri">The uri to request.</param>
        /// <returns></returns>
        public abstract XmlResponse<T> Request<T>(T type, Uri uri) where T : new();
        
        /// <summary>
        /// Stores the CacheExpirationRegister to disk.
        /// </summary>
        public virtual void SaveCacheState() {
            try {
                File.WriteAllLines(Config.ExpirationRegister,
                    CacheExpirationRegister.Select(x => x.Key + "," + x.Value.ToString(CultureInfo.InvariantCulture)));
            } catch (DirectoryNotFoundException) {
                Directory.CreateDirectory(Config.CachePath);
                SaveCacheState();
            }
        }

        /// <summary>
        /// Loads the CacheExpirationRegister from disk.
        /// </summary>
        private static void load() {
            lock (CacheLock) {
                if (_cacheExpirationRegister != null) return;
                _cacheExpirationRegister = new HashedCacheExpirationRegister();
                try {
                    var data =
                        File.ReadAllLines(Config.ExpirationRegister);
                    for (var i = 0; i < data.Length; ++i) {
                        var split = data[i].Split(',');
                        _cacheExpirationRegister.Restore(split[0],
                            DateTime.Parse(split[1], CultureInfo.InvariantCulture));
                    }
                }
                catch (DirectoryNotFoundException) {

                }
                catch (FileNotFoundException) {
                    
                }
            }
        }
    }
}
