// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Lars Kristian
// Created          : 12-19-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 12-19-2014
// ***********************************************************************
// <copyright file="EveRoot.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace eZet.EveLib.EveCrestModule.Models.Resources {
    /// <summary>
    /// Class EveRoot. This class cannot be inherited.
    /// </summary>
    public sealed class EveRoot : CrestResource<EveRoot> {

        /// <summary>
        /// Initializes a new instance of the <see cref="EveRoot" /> class.
        /// </summary>
        public EveRoot() {
            ContentType = "application/vnd.ccp.eve.EveRoot-v1+json";
        }


    }
}
