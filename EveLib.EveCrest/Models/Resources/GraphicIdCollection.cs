// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : larsd
// Created          : 10-20-2015
//
// Last Modified By : larsd
// Last Modified On : 10-20-2015
// ***********************************************************************
// <copyright file="GraphicIdCollection.cs" company="Lars Kristian Dahl">
//     Copyright ©  2015
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Runtime.Serialization;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    /// <summary>
    /// Class GraphicIdCollection.
    /// </summary>
    [DataContract]
    public sealed class GraphicIdCollection : CollectionResource<GraphicIdCollection, GraphicId> {

        /// <summary>
        /// Initializes a new instance of the <see cref="GraphicIdCollection"/> class.
        /// </summary>
        public GraphicIdCollection() {
            ContentType = "application/vnd.ccp.eve.GraphicIDCollection-v1+json; charset=utf-8";
        }

       
    }
}
