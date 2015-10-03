// ***********************************************************************
// Assembly         : EveLib.EveWho
// Author           : Lars Kristian
// Created          : 06-19-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="CorporationResponse.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Runtime.Serialization;

namespace eZet.EveLib.EveWhoModule.Models {
    /// <summary>
    ///     Class CorporationResponse.
    /// </summary>
    [DataContract]
    public class CorporationResponse {

        /// <summary>
        /// Gets or sets the information.
        /// </summary>
        /// <value>The information.</value>
        [DataMember(Name = "info")]
        public CorporationInfo Info { get; set; }

        /// <summary>
        /// Class CorporationInfo.
        /// </summary>
        [DataContract]
        public class CorporationInfo {

            /// <summary>
            ///     Gets or sets the corporation identifier.
            /// </summary>
            /// <value>The corporation identifier.</value>
            [DataMember(Name = "corporation_id")]
            public long CorporationId { get; set; }

            /// <summary>
            ///     Gets or sets the alliance identifier.
            /// </summary>
            /// <value>The alliance identifier.</value>
            [DataMember(Name = "alliance_id")]
            public long AllianceId { get; set; }

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
            ///     Sets the is NPC corporation string.
            /// </summary>
            /// <value>The is NPC corporation string.</value>
            [DataMember(Name = "is_npc_corp")]
            public string IsNpcCorporationString {
                set { IsNpcCorporation = value == "1"; }
            }

            /// <summary>
            ///     Gets or sets a value indicating whether this instance is NPC corporation.
            /// </summary>
            /// <value><c>true</c> if this instance is NPC corporation; otherwise, <c>false</c>.</value>
            public bool IsNpcCorporation { get; set; }

            /// <summary>
            ///     Gets or sets the average security status.
            /// </summary>
            /// <value>The average security status.</value>
            [DataMember(Name = "avg_sec_status")]
            public double AvgSecurityStatus { get; set; }

            /// <summary>
            ///     Sets the is active string.
            /// </summary>
            /// <value>The is active string.</value>
            [DataMember(Name = "active")]
            public string IsActiveString {
                set { IsActive = value == "1"; }
            }

            /// <summary>
            ///     Gets or sets a value indicating whether this instance is active.
            /// </summary>
            /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
            public bool IsActive { get; set; }

            /// <summary>
            ///     Gets or sets the ceo identifier.
            /// </summary>
            /// <value>The ceo identifier.</value>
            [DataMember(Name = "ceoID")]
            public long CeoId { get; set; }

            /// <summary>
            ///     Gets or sets the tax rate.
            /// </summary>
            /// <value>The tax rate.</value>
            [DataMember(Name = "taxrate")]
            public double TaxRate { get; set; }

            /// <summary>
            ///     Gets or sets the description.
            /// </summary>
            /// <value>The description.</value>
            [DataMember(Name = "description")]
            public string Description { get; set; }
        }
    }

}