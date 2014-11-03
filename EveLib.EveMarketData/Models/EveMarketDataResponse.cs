// ***********************************************************************
// Assembly         : EveLib.EveMarketData
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="EveMarketDataResponse.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace eZet.EveLib.Modules.Models {
    /// <summary>
    /// Class EveMarketDataResponse.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [XmlRoot("emd", Namespace = "", IsNullable = false)]
    [DataContract]
    public class EveMarketDataResponse<T> {
        /// <summary>
        /// Gets or sets the current time.
        /// </summary>
        /// <value>The current time.</value>
        [XmlElement("currentTime")]
        [DataMember(Name = "currentTime")]
        public string CurrentTime { get; set; }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        /// <value>The version.</value>
        [XmlAttribute("version")]
        [DataMember(Name = "version")]
        public int Version { get; set; }

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>The result.</value>
        [XmlElement("result")]
        [DataMember(Name = "result")]
        public T Result { get; set; }
    }
}