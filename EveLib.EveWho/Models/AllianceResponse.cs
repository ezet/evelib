// ***********************************************************************
// Assembly         : EveLib.EveWho
// Author           : Lars Kristian
// Created          : 06-19-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="AllianceResponse.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Runtime.Serialization;

namespace eZet.EveLib.EveWhoModule.Models {
    /// <summary>
    ///     Class AllianceResponse.
    /// </summary>
    [DataContract]
    public class AllianceResponse {

        /// <summary>
        /// Gets or sets the information.
        /// </summary>
        /// <value>The information.</value>
        [DataMember(Name = "info")]
        public AllianceInfo Info { get; set; }

        /// <summary>
        /// Class AllianceInfo.
        /// </summary>
        [DataContract]
        public class AllianceInfo {
            /// <summary>
            ///     Gets or sets the alliance identifier.
            /// </summary>
            /// <value>The alliance identifier.</value>
            [DataMember(Name = "alliance_id")]
            public long AllianceId { get; set; }

            /// <summary>
            ///     Gets or sets the faction identifier.
            /// </summary>
            /// <value>The faction identifier.</value>
            [DataMember(Name = "faction_id")]
            public long FactionId { get; set; }

            /// <summary>
            ///     Gets or sets the name.
            /// </summary>
            /// <value>The name.</value>
            [DataMember(Name = "name")]
            public string Name { get; set; }

            /// <summary>
            ///     Gets or sets the ticker.
            /// </summary>
            /// <value>The ticker.</value>
            [DataMember(Name = "ticker")]
            public string Ticker { get; set; }

            /// <summary>
            ///     Gets or sets the member count.
            /// </summary>
            /// <value>The member count.</value>
            [DataMember(Name = "member_count")]
            public int MemberCount { get; set; }

            /// <summary>
            ///     Gets or sets the average security status.
            /// </summary>
            /// <value>The average security status.</value>
            [DataMember(Name = "avg_sec_status")]
            public double AvgSecurityStatus { get; set; }

            /// <summary>
            ///     Gets or sets the executor corporation.
            /// </summary>
            /// <value>The executor corporation.</value>
            [DataMember(Name = "executor_corp")]
            public long ExecutorCorporation { get; set; }
        }
    }
}