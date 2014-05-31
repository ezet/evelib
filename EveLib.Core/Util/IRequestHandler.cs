using System;
using System.Threading.Tasks;

namespace eZet.EveLib.Core.Util {
    public interface IRequestHandler {

        IHttpRequester HttpRequester { get; set; }

        ISerializer Serializer { get; set; }

        T Request<T>(Uri uri);

        Task<T> RequestAsync<T>(Uri uri);
    }
}
