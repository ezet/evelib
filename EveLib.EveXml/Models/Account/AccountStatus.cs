// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 11-03-2014
// ***********************************************************************
// <copyright file="AccountStatus.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Xml.Serialization;
using eZet.EveLib.EveXmlModule.Util;

namespace eZet.EveLib.EveXmlModule.Models.Account {
    /// <summary>
    ///     Account Status
    /// </summary>
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class AccountStatus {
        /// <summary>
        ///     Gets PaidUntil
        /// </summary>
        /// <value>The paid until.</value>
        [XmlIgnore]
        public DateTime PaidUntil { get; private set; }

        /// <summary>
        ///     Gets or sets PaidUntil as a string
        /// </summary>
        /// <value>The paid until as string.</value>
        [XmlElement("paidUntil")]
        public string PaidUntilAsString {
            get { return PaidUntil.ToString(XmlHelper.DateFormat); }
            set { PaidUntil = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
        }

        /// <summary>
        ///     Gets CreationDate
        /// </summary>
        /// <value>The creation date.</value>
        [XmlIgnore]
        public DateTime CreationDate { get; private set; }

        /// <summary>
        ///     Gets or sets CreationDate as a string
        /// </summary>
        /// <value>The creation date as string.</value>
        [XmlElement("createDate")]
        public string CreationDateAsString {
            get { return CreationDate.ToString(XmlHelper.DateFormat); }
            set { CreationDate = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
        }

        /// <summary>
        ///     Gets or sets LogonCount
        /// </summary>
        /// <value>The logon count.</value>
        [XmlElement("logonCount")]
        public int LogonCount { get; set; }

        /// <summary>
        ///     Gets or sets LogonMinutes
        /// </summary>
        /// <value>The logon minutes.</value>
        [XmlElement("logonMinutes")]
        public int LogonMinutes { get; set; }

        /// <summary>
        ///     Gets or sets the MultiCharacterTraining row set
        /// </summary>
        /// <value>The multi character training.</value>
        [XmlElement("rowset")]
        public EveXmlRowCollection<MultiCharacterTraining> MultiCharacterTraining { get; set; }
    }


    /// <summary>
    ///     Multi Character Training
    /// </summary>
    [Serializable]
    [XmlRoot("row", IsNullable = false)]
    public class MultiCharacterTraining {
        /// <summary>
        ///     Gets or sets TrainingEnd
        /// </summary>
        /// <value>The training end.</value>
        [XmlIgnore]
        public DateTime TrainingEnd { get; set; }

        /// <summary>
        ///     Gets or sets TrainingEnd as a string
        /// </summary>
        /// <value>The creation date as string.</value>
        [XmlElement("trainingEnd")]
        public string TrainingEndAsString {
            get { return TrainingEnd.ToString(XmlHelper.DateFormat); }
            set { TrainingEnd = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
        }
    }
}