using System;
using System.Threading.Tasks;
using eZet.EveLib.Core.Serializers;

namespace eZet.EveLib.Core.RequestHandlers {
    public interface IRequestHandler {
        ISerializer Serializer { get; set; }

        Task<T> RequestAsync<T>(Uri uri);
    }
}