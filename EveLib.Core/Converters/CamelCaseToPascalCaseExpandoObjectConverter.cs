// ***********************************************************************
// Assembly         : EveLib.Core
// Author           : larsd
// Created          : 04-28-2016
//
// Last Modified By : larsd
// Last Modified On : 04-29-2016
// ***********************************************************************
// <copyright file="CamelCaseToPascalCaseExpandoObjectConverter.cs" company="Lars Kristian Dahl">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using Newtonsoft.Json;

namespace eZet.EveLib.Core.Converters {
    /// <summary>
    /// Class CamelCaseToPascalCaseExpandoObjectConverter.
    /// </summary>
    public class CamelCaseToPascalCaseExpandoObjectConverter : JsonConverter {
        //CHANGED
        //the ExpandoObjectConverter needs this internal method so we have to copy it
        //from JsonReader.cs
        /// <summary>
        /// Determines whether [is primitive token] [the specified token].
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns><c>true</c> if [is primitive token] [the specified token]; otherwise, <c>false</c>.</returns>
        internal static bool IsPrimitiveToken(JsonToken token) {
            switch (token) {
                case JsonToken.Integer:
                case JsonToken.Float:
                case JsonToken.String:
                case JsonToken.Boolean:
                case JsonToken.Null:
                case JsonToken.Undefined:
                case JsonToken.Date:
                case JsonToken.Bytes:
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="JsonWriter" /> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            // can write is set to false
        }

        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="JsonReader" /> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>The object value.</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            return ReadValue(reader);
        }

        /// <summary>
        /// Reads the value.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns>System.Object.</returns>
        /// <exception cref="System.Exception">
        /// Unexpected end.
        /// or
        /// </exception>
        private object ReadValue(JsonReader reader) {
            while (reader.TokenType == JsonToken.Comment) {
                if (!reader.Read())
                    throw new Exception("Unexpected end.");
            }

            switch (reader.TokenType) {
                case JsonToken.StartObject:
                    return ReadObject(reader);
                case JsonToken.StartArray:
                    return ReadList(reader);
                default:
                    //CHANGED
                    //call to static method declared inside this class
                    if (IsPrimitiveToken(reader.TokenType))
                        return reader.Value;

                    //CHANGED
                    //Use string.format instead of some util function declared inside JSON.NET
                    throw new Exception(string.Format(CultureInfo.InvariantCulture, "Unexpected token when converting ExpandoObject: {0}", reader.TokenType));
            }
        }

        /// <summary>
        /// Reads the list.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns>System.Object.</returns>
        /// <exception cref="System.Exception">Unexpected end.</exception>
        private object ReadList(JsonReader reader) {
            IList<object> list = new List<object>();

            while (reader.Read()) {
                switch (reader.TokenType) {
                    case JsonToken.Comment:
                        break;
                    default:
                        object v = ReadValue(reader);

                        list.Add(v);
                        break;
                    case JsonToken.EndArray:
                        return list;
                }
            }

            throw new Exception("Unexpected end.");
        }

        /// <summary>
        /// Reads the object.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns>System.Object.</returns>
        /// <exception cref="System.Exception">
        /// Unexpected end.
        /// or
        /// Unexpected end.
        /// </exception>
        private object ReadObject(JsonReader reader) {
            IDictionary<string, object> expandoObject = new ExpandoObject();

            while (reader.Read()) {
                switch (reader.TokenType) {
                    case JsonToken.PropertyName:
                        //CHANGED
                        //added call to ToPascalCase extension method       
                        string propertyName = reader.Value.ToString().ToPascalCase();

                        if (!reader.Read())
                            throw new Exception("Unexpected end.");

                        object v = ReadValue(reader);

                        expandoObject[propertyName] = v;
                        break;
                    case JsonToken.Comment:
                        break;
                    case JsonToken.EndObject:
                        return expandoObject;
                }
            }

            throw new Exception("Unexpected end.");
        }

        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns><c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.</returns>
        public override bool CanConvert(Type objectType) {
            return objectType == typeof (DynamicObject) || objectType == typeof(ExpandoObject);
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="JsonConverter" /> can write JSON.
        /// </summary>
        /// <value><c>true</c> if this <see cref="JsonConverter" /> can write JSON; otherwise, <c>false</c>.</value>
        public override bool CanWrite
        {
            get { return false; }
        }
    }

    /// <summary>
    /// Class StringExtensions.
    /// </summary>
    public static class StringExtensions {
        /// <summary>
        /// To the pascal case.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns>System.String.</returns>
        public static string ToPascalCase(this string s) {
            if (string.IsNullOrEmpty(s) || !char.IsLower(s[0]))
                return s;

            string str = char.ToUpper(s[0], CultureInfo.InvariantCulture).ToString((IFormatProvider)CultureInfo.InvariantCulture);

            if (s.Length > 1)
                str = str + s.Substring(1);

            return str;
        }
    }

}
