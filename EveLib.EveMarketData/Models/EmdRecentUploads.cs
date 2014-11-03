// ***********************************************************************
// Assembly         : EveLib.EveMarketData
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="EmdRecentUploads.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using eZet.EveLib.Modules.JsonConverters;
using Newtonsoft.Json;

namespace eZet.EveLib.Modules.Models {
    /// <summary>
    /// Class EmdRecentUploads.
    /// </summary>
    [DataContract]
    [JsonConverter(typeof (EmdRecentUploadsJsonConverter))]
    public class EmdRecentUploads {
        /// <summary>
        /// Gets or sets the uploads.
        /// </summary>
        /// <value>The uploads.</value>
        [DataMember(Name = "rowset")]
        [XmlElement("rowset")]
        public EveMarketDataRowCollection<RecentUploadsEntry> Uploads { get; set; }

        /// <summary>
        /// Class RecentUploadsEntry.
        /// </summary>
        [DataContract]
        [XmlRoot("row")]
        public class RecentUploadsEntry {
            /// <summary>
            /// Gets or sets the type of the upload.
            /// </summary>
            /// <value>The type of the upload.</value>
            [DataMember(Name = "upload_type")]
            [XmlAttribute("upload_type")]
            public UploadType UploadType { get; set; }

            /// <summary>
            /// Gets or sets the region identifier.
            /// </summary>
            /// <value>The region identifier.</value>
            [DataMember(Name = "regionID")]
            [XmlAttribute("regionID")]
            public int RegionId { get; set; }

            /// <summary>
            /// Gets or sets the type identifier.
            /// </summary>
            /// <value>The type identifier.</value>
            [DataMember(Name = "typeID")]
            [XmlAttribute("typeID")]
            public int TypeId { get; set; }

            /// <summary>
            /// Gets or sets the updated.
            /// </summary>
            /// <value>The updated.</value>
            [DataMember(Name = "updated")]
            [XmlAttribute("updated")]
            public DateTime Updated { get; set; }
        }
    }
}