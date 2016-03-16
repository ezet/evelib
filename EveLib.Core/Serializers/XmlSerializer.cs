// ***********************************************************************
// Assembly         : EveLib.Core
// Author           : larsd
// Created          : 08-09-2015
//
// Last Modified By : larsd
// Last Modified On : 03-03-2016
// ***********************************************************************
// <copyright file="XmlSerializer.cs" company="Lars Kristian Dahl">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Diagnostics;
using System.IO;
using System.Xml;

namespace eZet.EveLib.Core.Serializers {
    /// <summary>
    ///     Class XmlSerializer. This class cannot be inherited.
    /// </summary>
    public sealed class XmlSerializer : ISerializer {
        /// <summary>
        ///     The _trace
        /// </summary>
        private readonly TraceSource _trace = new TraceSource("EveLib");

        /// <summary>
        ///     Deserializes Eve API xml using the .NET XmlSerializer.
        /// </summary>
        /// <typeparam name="T">An xml result type</typeparam>
        /// <param name="data">An XML string</param>
        /// <returns>T.</returns>
        T ISerializer.Deserialize<T>(string data) {
            _trace.TraceEvent(TraceEventType.Verbose, 0, "XmlSerializer.Deserialize:Start");
            var type = typeof (T);
            var serializer = new System.Xml.Serialization.XmlSerializer(type);
            T xmlResponse;
            var stringreader = new StringReader(data);
            using (var reader = XmlReader.Create(stringreader)) {
                xmlResponse = (T) serializer.Deserialize(reader);
            }
            _trace.TraceEvent(TraceEventType.Verbose, 0, "XmlSerializer.Deserialize:Complete");
            return xmlResponse;
        }

        /// <summary>
        ///     Serializes the specified entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public string Serialize<T>(T entity) {
            throw new NotImplementedException();
        }
    }
}