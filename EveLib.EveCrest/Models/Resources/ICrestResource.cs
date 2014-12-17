using System;
using System.Threading.Tasks;
using eZet.EveLib.EveCrestModule.Models.Links;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    public interface ICrestResource<out T> where T : class, ICrestResource<T> {
        bool IsDeprecated { get; set; }

        string Version { get; }

        EveCrest Crest { get; set; }

        Task<TOut> QueryAsync<TOut>(Func<T, Href<TOut>> objFunc)
            where TOut : class, ICrestResource<TOut>;

        Task<TOut> QueryAsync<TOut>(Func<T, LinkedEntity<TOut>> objFunc)
            where TOut : class, ICrestResource<TOut>;
    }
}