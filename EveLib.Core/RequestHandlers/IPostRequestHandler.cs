using System;
using System.Threading.Tasks;

namespace eZet.EveLib.Core.RequestHandlers {
    /// <summary>
    /// 
    /// </summary>
    public interface IPostRequestHandler : IRequestHandler {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="postData"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        Task<T> PostRequestAsync<T>(Uri uri, string postData);

    }
}