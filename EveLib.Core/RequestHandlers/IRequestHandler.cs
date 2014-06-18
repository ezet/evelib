using System;
using System.Threading.Tasks;
using eZet.EveLib.Core.Serializers;
using eZet.EveLib.Core.Util;

namespace eZet.EveLib.Core.RequestHandlers {
    public interface IRequestHandler {
        IHttpRequester HttpRequester { get; set; }

        ISerializer Serializer { get; set; }

        Task<T> RequestAsync<T>(Uri uri);


    }
}