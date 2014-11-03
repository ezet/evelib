// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 06-04-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="CustomsOffices.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Xml.Serialization;

namespace eZet.EveLib.Modules.Models.Corporation {
    /// <summary>
    ///     Class CustomsOffices.
    /// </summary>
    [Serializable]
    [XmlRoot("result")]
    public class CustomsOffices {
        /// <summary>
        ///     Gets or sets the pocos.
        /// </summary>
        /// <value>The pocos.</value>
        [XmlElement("rowset")]
        public EveOnlineRowCollection<CustomsOffice> Pocos { get; set; }

        /// <summary>
        ///     Class CustomsOffice.
        /// </summary>
        public class CustomsOffice {
            /// <summary>
            ///     Gets or sets the item identifier.
            /// </summary>
            /// <value>The item identifier.</value>
            [XmlAttribute("itemID")]
            public int ItemId { get; set; }

            /// <summary>
            ///     Gets or sets the solar system identifier.
            /// </summary>
            /// <value>The solar system identifier.</value>
            [XmlAttribute("solarSystemID")]
            public int SolarSystemId { get; set; }

            /// <summary>
            ///     Gets or sets the name of the solar system.
            /// </summary>
            /// <value>The name of the solar system.</value>
            [XmlAttribute("solarSystemName")]
            public string SolarSystemName { get; set; }

            /// <summary>
            ///     Gets or sets the reinforce hour.
            /// </summary>
            /// <value>The reinforce hour.</value>
            [XmlAttribute("reinforceHour")]
            public int ReinforceHour { get; set; }

            /// <summary>
            ///     Gets or sets a value indicating whether [allow alliance].
            /// </summary>
            /// <value><c>true</c> if [allow alliance]; otherwise, <c>false</c>.</value>
            [XmlAttribute("allowAlliance")]
            public bool AllowAlliance { get; set; }

            /// <summary>
            ///     Gets or sets a value indicating whether [allow standings].
            /// </summary>
            /// <value><c>true</c> if [allow standings]; otherwise, <c>false</c>.</value>
            [XmlAttribute("allowStandings")]
            public bool AllowStandings { get; set; }

            /// <summary>
            ///     Gets or sets the tax rate alliance.
            /// </summary>
            /// <value>The tax rate alliance.</value>
            [XmlAttribute("taxRateAlliance")]
            public double TaxRateAlliance { get; set; }

            /// <summary>
            ///     Gets or sets the tax rate corp.
            /// </summary>
            /// <value>The tax rate corp.</value>
            [XmlAttribute("taxRateCorp")]
            public double TaxRateCorp { get; set; }

            /// <summary>
            ///     Gets or sets the tax rate standing high.
            /// </summary>
            /// <value>The tax rate standing high.</value>
            [XmlAttribute("taxRateStandingHigh")]
            public double TaxRateStandingHigh { get; set; }

            /// <summary>
            ///     Gets or sets the tax rate standing good.
            /// </summary>
            /// <value>The tax rate standing good.</value>
            [XmlAttribute("taxRateStandingGood")]
            public double TaxRateStandingGood { get; set; }

            /// <summary>
            ///     Gets or sets the tax rate standing neutral.
            /// </summary>
            /// <value>The tax rate standing neutral.</value>
            [XmlAttribute("taxRateStandingNeutral")]
            public double TaxRateStandingNeutral { get; set; }

            /// <summary>
            ///     Gets or sets the tax rate standing bad.
            /// </summary>
            /// <value>The tax rate standing bad.</value>
            [XmlAttribute("taxRateStandingBad")]
            public double TaxRateStandingBad { get; set; }

            /// <summary>
            ///     Gets or sets the tax rate standing horrible.
            /// </summary>
            /// <value>The tax rate standing horrible.</value>
            [XmlAttribute("taxRateStandingHorrible")]
            public double TaxRateStandingHorrible { get; set; }
        }
    }
}