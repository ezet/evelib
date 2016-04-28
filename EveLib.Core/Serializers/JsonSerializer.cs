// ***********************************************************************
// Assembly         : EveLib.Core
// Author           : larsd
// Created          : 08-09-2015
//
// Last Modified By : larsd
// Last Modified On : 03-03-2016
// ***********************************************************************
// <copyright file="JsonSerializer.cs" company="Lars Kristian Dahl">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace eZet.EveLib.Core.Serializers {
    /// <summary>
    ///     JSON serializer
    /// </summary>
    public sealed class JsonSerializer : ISerializer {
        /// <summary>
        ///     The _trace
        /// </summary>
        private readonly TraceSource _trace = new TraceSource("EveLib");

        /// <summary>
        ///     The date format
        /// </summary>
        public string DateFormat = "yyyy-MM-dd HH:mm:ss";

        /// <summary>
        ///     The date format2
        /// </summary>
        public string DateFormat2 = "yyyy.MM.dd HH:mm:ss";

        private JsonSerializerSettings Settings { get; }

        public JsonSerializer() {
            Settings = new JsonSerializerSettings();
            Settings.Converters.Add(new IsoDateTimeConverter { DateTimeFormat = DateFormat });
            Settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }

        public JsonSerializer(string dateFormat) {
            DateFormat = dateFormat;
        }

        /// <summary>
        ///     Deserializes data.
        /// </summary>
        /// <typeparam name="T">Type to deserialize to.</typeparam>
        /// <param name="data">String of data to deserialize.</param>
        /// <returns>T.</returns>
        T ISerializer.Deserialize<T>(string data) {
            _trace.TraceEvent(TraceEventType.Verbose, 0, "JsonSerializer.Deserialize:Start");
            var result = JsonConvert.DeserializeObject<T>(data, Settings);
            _trace.TraceEvent(TraceEventType.Verbose, 0, "JsonSerializer.Deserialize:Complete");
            return result;
        }

        /// <summary>
        ///     Serializes the specified entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns>System.String.</returns>
        public string Serialize<T>(T entity) {
            _trace.TraceEvent(TraceEventType.Verbose, 0, "JsonSerializer.Serialize:Start");
            var data = JsonConvert.SerializeObject(entity, new IsoDateTimeConverter {DateTimeFormat = DateFormat},
                new StringEnumConverter());
            _trace.TraceEvent(TraceEventType.Verbose, 0, "JsonSerializer.Serialize:Complete");
            return data;
        }
    }
}