// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Lars Kristian
// Created          : 12-16-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 12-17-2014
// ***********************************************************************
// <copyright file="War.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Links;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    /// <summary>
    ///     Represents a CREST war
    /// </summary>
    [DataContract]
    public sealed class War : CrestResource<War> {
        /// <summary>
        ///     Initializes a new instance of the <see cref="War" /> class.
        /// </summary>
        public War() {
            ContentType = "application/vnd.ccp.eve.War-v1+json";
        }

        /// <summary>
        ///     The war ID
        /// </summary>
        /// <value>The identifier.</value>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        ///     The time the war was declared
        /// </summary>
        /// <value>The time declared.</value>
        [DataMember(Name = "timeDeclared")]
        public DateTime TimeDeclared { get; set; }

        /// <summary>
        ///     The time the war started
        /// </summary>
        /// <value>The time started.</value>
        [DataMember(Name = "timeStarted")]
        public DateTime TimeStarted { get; set; }

        /// <summary>
        ///     The time the war finished
        /// </summary>
        /// <value>The time finished.</value>
        [DataMember(Name = "timeFinished")]
        public DateTime TimeFinished { get; set; }

        /// <summary>
        ///     True if the war is open for allies
        /// </summary>
        /// <value><c>true</c> if [open for allies]; otherwise, <c>false</c>.</value>
        [DataMember(Name = "openForAllies")]
        public bool OpenForAllies { get; set; }


        /// <summary>
        ///     The number of allied entities
        /// </summary>
        /// <value>The ally count.</value>
        [DataMember(Name = "allyCount")]
        public int AllyCount { get; set; }

        /// <summary>
        ///     True if the war is mutual
        /// </summary>
        /// <value><c>true</c> if mutual; otherwise, <c>false</c>.</value>
        [DataMember(Name = "mutual")]
        public bool Mutual { get; set; }

        /// <summary>
        ///     The defending entity
        /// </summary>
        /// <value>The defender.</value>
        [DataMember(Name = "defender")]
        public WarEntity Defender { get; set; }

        /// <summary>
        ///     The aggressing entity
        /// </summary>
        /// <value>The aggressor.</value>
        [DataMember(Name = "aggressor")]
        public WarEntity Aggressor { get; set; }

        /// <summary>
        /// Gets or sets the killmails.
        /// </summary>
        /// <value>The killmails.</value>
        [DataMember(Name = "killmail")]
        public LinkedEntity<KillmailCollection> Killmails { get; set; }

        /// <summary>
        ///     Represents an entity in a war
        /// </summary>
        public class WarEntity : LinkedIconEntity<NotImplemented> {
            /// <summary>
            ///     The number of ships killed
            /// </summary>
            /// <value>The ships killed.</value>
            [DataMember(Name = "shipsKilled")]
            public int ShipsKilled { get; set; }

            /// <summary>
            ///     The amount of isk killed
            /// </summary>
            /// <value>The isk killed.</value>
            [DataMember(Name = "iskKilled")]
            public double IskKilled { get; set; }
        }
    }
}