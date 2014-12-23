// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="MedalList.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Xml.Serialization;
using eZet.EveLib.EveXmlModule.Util;

namespace eZet.EveLib.EveXmlModule.Models.Corporation {
    /// <summary>
    ///     Class MedalList.
    /// </summary>
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class MedalList {
        /// <summary>
        ///     Gets or sets the medals.
        /// </summary>
        /// <value>The medals.</value>
        [XmlElement("rowset")]
        public EveXmlRowCollection<Medal> Medals { get; set; }

        /// <summary>
        ///     Class Medal.
        /// </summary>
        [Serializable]
        [XmlRoot("row")]
        public class Medal {
            /// <summary>
            ///     Gets or sets the medal identifier.
            /// </summary>
            /// <value>The medal identifier.</value>
            [XmlAttribute("medalID")]
            public long MedalId { get; set; }

            /// <summary>
            ///     Gets or sets the title.
            /// </summary>
            /// <value>The title.</value>
            [XmlAttribute("title")]
            public string Title { get; set; }

            /// <summary>
            ///     Gets or sets the description.
            /// </summary>
            /// <value>The description.</value>
            [XmlAttribute("description")]
            public string Description { get; set; }

            /// <summary>
            ///     Gets or sets the creator identifier.
            /// </summary>
            /// <value>The creator identifier.</value>
            [XmlAttribute("creatorID")]
            public long CreatorId { get; set; }

            /// <summary>
            ///     Gets or sets the created date.
            /// </summary>
            /// <value>The created date.</value>
            [XmlIgnore]
            public DateTime CreatedDate { get; set; }

            /// <summary>
            ///     Gets or sets the created date as string.
            /// </summary>
            /// <value>The created date as string.</value>
            [XmlAttribute("created")]
            public string CreatedDateAsString {
                get { return CreatedDate.ToString(XmlHelper.DateFormat); }
                set { CreatedDate = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
            }
        }
    }
}