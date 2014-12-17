using System;
using System.Threading.Tasks;
using eZet.EveLib.EveCrestModule.Models.Links;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    public abstract class CrestResource<T> : ICrestResource<T> where T : class, ICrestResource<T> {
        
        public EveCrest Crest { get; set; }

        public virtual bool IsDeprecated { get; set; }

        public virtual string Version { get; protected set; }


        public Task<TOut> QueryAsync<TOut>(Func<T, Href<TOut>> objFunc)
            where TOut : class, ICrestResource<TOut> {
            return Crest.LoadAsync(objFunc.Invoke(this as T));
        }

        public Task<TOut> QueryAsync<TOut>(Func<T, LinkedEntity<TOut>> objFunc)
            where TOut : class, ICrestResource<TOut> {
            return Crest.LoadAsync(objFunc.Invoke(this as T));
        }
    }
}