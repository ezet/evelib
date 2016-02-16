// ***********************************************************************
// Assembly         : EveLib.ZKillboard
// Author           : larsd
// Created          : 02-16-2016
//
// Last Modified By : larsd
// Last Modified On : 02-16-2016
// ***********************************************************************
// <copyright file="ZkbStatResponse.cs" company="Lars Kristian Dahl">
//     Copyright ©  2015
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Runtime.Serialization;

namespace eZet.EveLib.ZKillboardModule {

    /// <summary>
    /// Class ZkbStatResponse.
    /// </summary>
    [DataContract]
    public class ZkbStatResponse {

        /// <summary>
        /// Gets or sets all time sum.
        /// </summary>
        /// <value>All time sum.</value>
        [DataMember(Name = "allTimeSum")]
        public int AllTimeSum { get; set; }

        // TODO: Implement groups
        //[DataMember(Name = "groups")]

        /// <summary>
        /// Gets or sets a value indicating whether this instance has supers.
        /// </summary>
        /// <value><c>true</c> if this instance has supers; otherwise, <c>false</c>.</value>
        [DataMember(Name = "hasSupers")]
        public bool HasSupers { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [DataMember(Name = "id")]
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the isk destroyed.
        /// </summary>
        /// <value>The isk destroyed.</value>
        [DataMember(Name = "iskDestroyed")]
        public long IskDestroyed { get; set; }

        /// <summary>
        /// Gets or sets the isk lost.
        /// </summary>
        /// <value>The isk lost.</value>
        [DataMember(Name = "iskLost")]
        public long IskLost { get; set; }

        // TODO: Implement months
        //[DataMember(Name = "months")]

        /// <summary>
        /// Gets or sets the points destroyed.
        /// </summary>
        /// <value>The points destroyed.</value>
        [DataMember(Name = "pointsDestroyed")]
        public long PointsDestroyed { get; set; }

        /// <summary>
        /// Gets or sets the points lost.
        /// </summary>
        /// <value>The points lost.</value>
        [DataMember(Name = "pointsLost")]
        public long PointsLost { get; set; }

        /// <summary>
        /// Gets or sets the sequence.
        /// </summary>
        /// <value>The sequence.</value>
        [DataMember(Name = "sequence")]
        public long Sequence { get; set; }

        /// <summary>
        /// Gets or sets the ships destroyed.
        /// </summary>
        /// <value>The ships destroyed.</value>
        [DataMember(Name = "shipsDestroyed")]
        public long ShipsDestroyed { get; set; }

        /// <summary>
        /// Gets or sets the ships lost.
        /// </summary>
        /// <value>The ships lost.</value>
        [DataMember(Name = "shipsLost")]
        public long ShipsLost { get; set; }

        // TODO: Implement TopAlltime
        //[DataMember(Name = "topAllTime")]

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        [DataMember(Name = "type")]
        public string Type { get; set; }

        // TODO: Implement this
        // [DataMember(Name = "activepvp")]

        /// <summary>
        /// Gets or sets the information.
        /// </summary>
        /// <value>The information.</value>
        [DataMember(Name = "info")]
        public ZkbStatInfo Info { get; set; }

        /// <summary>
        /// Class ZkbStatInfo.
        /// </summary>
        [DataContract]
        public class ZkbStatInfo {

            /// <summary>
            /// Gets or sets the alliance identifier.
            /// </summary>
            /// <value>The alliance identifier.</value>
            [DataMember(Name = "allianceID")]
            public long AllianceId { get; set; }

            /// <summary>
            /// Gets or sets the ceo identifier.
            /// </summary>
            /// <value>The ceo identifier.</value>
            [DataMember(Name = "ceoID")]
            public long CeoId { get; set; }

            /// <summary>
            /// Gets or sets the faction identifier.
            /// </summary>
            /// <value>The faction identifier.</value>
            [DataMember(Name = "factionID")]
            public long FactionId { get; set; }

            /// <summary>
            /// Gets or sets the identifier.
            /// </summary>
            /// <value>The identifier.</value>
            [DataMember(Name = "id")]
            public long Id { get; set; }

            /// <summary>
            /// Gets or sets the kill identifier.
            /// </summary>
            /// <value>The kill identifier.</value>
            [DataMember(Name = "killID")]
            public long KillId { get; set; }

            /// <summary>
            /// Gets or sets the last API update.
            /// </summary>
            /// <value>The last API update.</value>
            [DataMember(Name = "lastApiUpdate")]
            public ZkbApiUpdate LastApiUpdate { get; set; }

            /// <summary>
            /// Gets or sets the member count.
            /// </summary>
            /// <value>The member count.</value>
            [DataMember(Name = "memberCount")]
            public int MemberCount { get; set; }

            /// <summary>
            /// Gets or sets the name.
            /// </summary>
            /// <value>The name.</value>
            [DataMember(Name = "name")]
            public string Name { get; set; }

            /// <summary>
            /// Gets or sets the ticker.
            /// </summary>
            /// <value>The ticker.</value>
            [DataMember(Name = "ticker")]
            public string Ticker { get; set; }

            /// <summary>
            /// Gets or sets the type.
            /// </summary>
            /// <value>The type.</value>
            [DataMember(Name = "type")]
            public string Type { get; set; }

            /// <summary>
            /// Class ZkbApiUpdate.
            /// </summary>
            [DataContract]
            public class ZkbApiUpdate {

                /// <summary>
                /// Gets or sets the sec.
                /// </summary>
                /// <value>The sec.</value>
                [DataMember(Name = "sec")]
                public long Sec { get; set; }

                /// <summary>
                /// Gets or sets the u sec.
                /// </summary>
                /// <value>The u sec.</value>
                [DataMember(Name = "usec")]
                public long USec { get; set; }
            }

        }
    }
}