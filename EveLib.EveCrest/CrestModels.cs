// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Lars Kristian
// Created          : 12-16-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 12-17-2014
// ***********************************************************************
// <copyright file="CrestModels.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using eZet.EveLib.EveCrestModule.Models.Resources;

namespace eZet.EveLib.EveCrestModule {
    /// <summary>
    /// Class CrestModels.
    /// </summary>
    public static class CrestModels {
        static CrestModels() {
            Register = new Dictionary<Type, string> {
                {typeof (CrestRoot), "application/vnd.ccp.eve.Api-v3+json"},
            };
        }

        private static Dictionary<Type, string> Register { get; set; }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>System.String.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public static string Get<T>() where T : class, ICrestResource<T> {
            // TODO optional throw on missing version
            var instance = Activator.CreateInstance<T>();
            if (String.IsNullOrEmpty(instance.Version)) {
                throw new NotImplementedException();
            }
            return instance.Version;
        }
    }
}