using System;
using eZet.Eve.EoLib.Dto.EveApi;

namespace eZet.Eve.EoLib.Util {
    public interface IRequester {

        /// <summary>
        /// The serializer used to deserialize the repsonses for this entity.
        /// </summary>
        //IXmlSerializer Serializer { get; }

        //ICacheHandler Cache { get; }

        ///// <summary>
        ///// Performs a request to the provided URI, using the provided arguments.
        ///// </summary>
        ///// <param name="uri">The URI to request.</param>
        ///// <param name="cachedUntil"></param>
        ///// <returns></returns>
        //string Request(Uri uri, DateTime cachedUntil);

         XmlResponse<T> Request<T>(T type, Uri uri) where T : new();



    }
}
