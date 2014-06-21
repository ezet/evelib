using System;
using System.Diagnostics;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace eZet.EveLib.Core.Serializers {
    /// <summary>
    ///     A simple wrapper for .NET XmlSerializer.
    /// </summary>
    public sealed class XmlSerializer : ISerializer {
        private readonly TraceSource _trace = new TraceSource("EveLib");

        /// <summary>
        ///     Deserializes Eve API xml using the .NET XmlSerializer.
        /// </summary>
        /// <typeparam name="T">An xml result type</typeparam>
        /// <param name="data">An XML string</param>
        /// <returns></returns>
        T ISerializer.Deserialize<T>(string data) {
            _trace.TraceEvent(TraceEventType.Verbose, 0, "XmlSerializer.Deserialize:Start");
            Type type = typeof (T);
            var serializer = new System.Xml.Serialization.XmlSerializer(type);
            T xmlResponse;
            var stringreader = new StringReader(data);
            using (XmlReader reader = XmlReader.Create(stringreader)) {
                xmlResponse = (T) serializer.Deserialize(reader);
            }
            _trace.TraceEvent(TraceEventType.Verbose, 0, "XmlSerializer.Deserialize:Complete");
            return xmlResponse;
        }
    }
}