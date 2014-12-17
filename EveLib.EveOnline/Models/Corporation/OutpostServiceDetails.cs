// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="OutpostServiceDetails.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Xml.Serialization;

namespace eZet.EveLib.EveOnlineModule.Models.Corporation {
    /// <summary>
    ///     Class OutpostServiceDetails.
    /// </summary>
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class OutpostServiceDetails {
        /// <summary>
        ///     Gets or sets the services.
        /// </summary>
        /// <value>The services.</value>
        [XmlElement("rowset")]
        public EveOnlineRowCollection<Service> Services { get; set; }

        /// <summary>
        ///     Class Service.
        /// </summary>
        [Serializable]
        [XmlRoot("row")]
        public class Service {
            /// <summary>
            ///     Gets or sets the station identifier.
            /// </summary>
            /// <value>The station identifier.</value>
            [XmlAttribute("stationID")]
            public int StationId { get; set; }

            /// <summary>
            ///     Gets or sets the owner identifier.
            /// </summary>
            /// <value>The owner identifier.</value>
            [XmlAttribute("ownerID")]
            public long OwnerId { get; set; }

            /// <summary>
            ///     Gets or sets the name of the service.
            /// </summary>
            /// <value>The name of the service.</value>
            [XmlAttribute("serviceName")]
            public string ServiceName { get; set; }

            /// <summary>
            ///     Gets or sets the minimum standing.
            /// </summary>
            /// <value>The minimum standing.</value>
            [XmlAttribute("minStanding")]
            public double MinStanding { get; set; }

            /// <summary>
            ///     Gets or sets the surcharge per bad standing.
            /// </summary>
            /// <value>The surcharge per bad standing.</value>
            [XmlAttribute("surchargePerBadStanding")]
            public double SurchargePerBadStanding { get; set; }

            /// <summary>
            ///     Gets or sets the discount per good standing.
            /// </summary>
            /// <value>The discount per good standing.</value>
            [XmlAttribute("discountPerGoodStanding")]
            public double DiscountPerGoodStanding { get; set; }
        }
    }
}