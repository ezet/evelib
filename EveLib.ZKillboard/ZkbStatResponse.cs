// ***********************************************************************
// Assembly         : EveLib.ZKillboard
// Author           : larsd
// Created          : 02-16-2016
//
// Last Modified By : larsd
// Last Modified On : 04-27-2016
// ***********************************************************************
// <copyright file="ZkbStatResponse.cs" company="Lars Kristian Dahl">
//     Copyright ©  2015
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        // TODO: Implement groups properly
        /// <summary>
        /// Gets or sets the groups.
        /// </summary>
        /// <value>The groups.</value>
        [DataMember(Name = "groups")]
        public Dictionary<string, ZkbGroup> Groups { get; set; }

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
        /// <summary>
        /// Gets or sets the months.
        /// </summary>
        /// <value>The months.</value>
        [DataMember(Name = "months")]
        public Dictionary<string, ZkbMonth> Months { get; set; }

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

        // TODO: Implement rest of TopAlltime. Need to find a way to deserialize correctly.
        /// <summary>
        /// Gets or sets the top all time.
        /// </summary>
        /// <value>The top all time.</value>
        [DataMember(Name = "topAllTime")]
        public Collection<ZkbTopAllTime> TopAllTime { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        [DataMember(Name = "type")]
        public string Type { get; set; }

        // TODO: Test ActivePvp for all entity types
        /// <summary>
        /// Gets or sets the active PVP.
        /// </summary>
        /// <value>The active PVP.</value>
        [DataMember(Name = "activepvp")]
        public ZkbActivePvp ActivePvp { get; set; }

        /// <summary>
        /// Gets or sets the information.
        /// </summary>
        /// <value>The information.</value>
        [DataMember(Name = "info")]
        public ZkbStatInfo Info { get; set; }

        /// <summary>
        /// Class ZkbGroup.
        /// </summary>
        [DataContract]
        public class ZkbGroup {
            /// <summary>
            /// Gets or sets the group identifier.
            /// </summary>
            /// <value>The group identifier.</value>
            [DataMember(Name = "groupID")]
            public int GroupId { get; set; }

            /// <summary>
            /// Gets or sets the ships destroyed.
            /// </summary>
            /// <value>The ships destroyed.</value>
            [DataMember(Name = "shipsDestroyed")]
            public int ShipsDestroyed { get; set; }

            /// <summary>
            /// Gets or sets the points destroyed.
            /// </summary>
            /// <value>The points destroyed.</value>
            [DataMember(Name = "pointsDestroyed")]
            public int PointsDestroyed { get; set; }

            /// <summary>
            /// Gets or sets the isk destroyed.
            /// </summary>
            /// <value>The isk destroyed.</value>
            [DataMember(Name = "iskDestroyed")]
            public long IskDestroyed { get; set; }
        }

        /// <summary>
        /// Class ZkbMonth.
        /// </summary>
        [DataContract]
        public class ZkbMonth
        {
            /// <summary>
            /// Gets or sets the year.
            /// </summary>
            /// <value>The year.</value>
            [DataMember(Name = "year")]
            public int Year { get; set; }

            /// <summary>
            /// Gets or sets the month.
            /// </summary>
            /// <value>The month.</value>
            [DataMember(Name = "month")]
            public int Month { get; set; }

            /// <summary>
            /// Gets or sets the ships lost.
            /// </summary>
            /// <value>The ships lost.</value>
            [DataMember(Name = "shipsLost")]
            public int ShipsLost { get; set; }

            /// <summary>
            /// Gets or sets the points lost.
            /// </summary>
            /// <value>The points lost.</value>
            [DataMember(Name = "pointsLost")]
            public int PointsLost { get; set; }

            /// <summary>
            /// Gets or sets the isk lost.
            /// </summary>
            /// <value>The isk lost.</value>
            [DataMember(Name = "iskLost")]
            public long IskLost { get; set; }

            /// <summary>
            /// Gets or sets the ships destroyed.
            /// </summary>
            /// <value>The ships destroyed.</value>
            [DataMember(Name = "shipsDestroyed")]
            public int ShipsDestroyed { get; set; }

            /// <summary>
            /// Gets or sets the points destroyed.
            /// </summary>
            /// <value>The points destroyed.</value>
            [DataMember(Name = "pointsDestroyed")]
            public int PointsDestroyed { get; set; }

            /// <summary>
            /// Gets or sets the isk destroyed.
            /// </summary>
            /// <value>The isk destroyed.</value>
            [DataMember(Name = "iskDestroyed")]
            public long IskDestroyed { get; set; }

        }

        /// <summary>
        /// Class ZkbTopAllTime.
        /// </summary>
        [DataContract]
        public class ZkbTopAllTime {

            /// <summary>
            /// Gets or sets the type.
            /// </summary>
            /// <value>The type.</value>
            [DataMember(Name = "type")]
            public string Type { get; set; }

            /// <summary>
            /// Gets or sets the data.
            /// </summary>
            /// <value>The data.</value>
            [DataMember(Name = "data")]
            public Collection<ZkbData> Data { get; set; }
        }

        /// <summary>
        /// Class ZkbData.
        /// </summary>
        [DataContract]
        public class ZkbData {

            /// <summary>
            /// Gets or sets the kills.
            /// </summary>
            /// <value>The kills.</value>
            [DataMember(Name = "kills")]
            public int Kills { get; set; }

            /// <summary>
            /// Gets or sets the character identifier.
            /// </summary>
            /// <value>The character identifier.</value>
            [DataMember(Name = "characterID")]
            public long CharacterId { get; set; }

            /// <summary>
            /// Gets or sets the name of the character.
            /// </summary>
            /// <value>The name of the character.</value>
            [DataMember(Name = "characterName")]
            public string CharacterName { get; set; }

            /// <summary>
            /// Gets or sets the corporation identifier.
            /// </summary>
            /// <value>The corporation identifier.</value>
            [DataMember(Name = "corporationID")]
            public long CorporationId { get; set; }

            /// <summary>
            /// Gets or sets the name of the corporation.
            /// </summary>
            /// <value>The name of the corporation.</value>
            [DataMember(Name = "corporationName")]
            public string CorporationName { get; set; }

            /// <summary>
            /// Gets or sets the alliance identifier.
            /// </summary>
            /// <value>The alliance identifier.</value>
            [DataMember(Name = "allianceID")]
            public long AllianceId { get; set; }

            /// <summary>
            /// Gets or sets the name of the alliance.
            /// </summary>
            /// <value>The name of the alliance.</value>
            [DataMember(Name = "allianceName")]
            public string AllianceName { get; set; }

            /// <summary>
            /// Gets or sets the faction identifier.
            /// </summary>
            /// <value>The faction identifier.</value>
            [DataMember(Name = "factionID")]
            public long FactionId { get; set; }

            /// <summary>
            /// Gets or sets the name of the faction.
            /// </summary>
            /// <value>The name of the faction.</value>
            [DataMember(Name = "factionName")]
            public string FactionName { get; set; }

            #region Ship
            /// <summary>
            /// Gets or sets the ship type identifier.
            /// </summary>
            /// <value>The ship type identifier.</value>
            [DataMember(Name = "shipTypeID")]
            public long ShipTypeId { get; set; }

            /// <summary>
            /// Gets or sets the name of the ship.
            /// </summary>
            /// <value>The name of the ship.</value>
            [DataMember(Name = "shipName")]
            public string ShipName { get; set; }

            /// <summary>
            /// Gets or sets the group identifier.
            /// </summary>
            /// <value>The group identifier.</value>
            [DataMember(Name = "groupID")]
            public long GroupId { get; set; }

            /// <summary>
            /// Gets or sets the name of the group.
            /// </summary>
            /// <value>The name of the group.</value>
            [DataMember(Name = "groupName")]
            public string GroupName { get; set; }
            #endregion

            #region System
            /// <summary>
            /// Gets or sets the solar system identifier.
            /// </summary>
            /// <value>The solar system identifier.</value>
            [DataMember(Name = "solarSystemID")]
            public long SolarSystemId { get; set; }

            /// <summary>
            /// Gets or sets the name of the solar system.
            /// </summary>
            /// <value>The name of the solar system.</value>
            [DataMember(Name = "solarSystemName")]
            public string SolarSystemName { get; set; }

            /// <summary>
            /// Gets or sets the sun type identifier.
            /// </summary>
            /// <value>The sun type identifier.</value>
            [DataMember(Name = "sunTypeID")]
            public int SunTypeId { get; set; }

            /// <summary>
            /// Gets or sets the solar system security.
            /// </summary>
            /// <value>The solar system security.</value>
            [DataMember(Name = "solarSystemSecurity")]
            public double SolarSystemSecurity { get; set; }

            /// <summary>
            /// Gets or sets the system color code.
            /// </summary>
            /// <value>The system color code.</value>
            [DataMember(Name = "systemColorCode")]
            public string SystemColorCode { get; set; }

            /// <summary>
            /// Gets or sets the region identifier.
            /// </summary>
            /// <value>The region identifier.</value>
            [DataMember(Name = "regionID")]
            public long RegionId { get; set; }

            /// <summary>
            /// Gets or sets the name of the region.
            /// </summary>
            /// <value>The name of the region.</value>
            [DataMember(Name = "regionName")]
            public string RegionName { get; set; }
            #endregion

        }


        /// <summary>
        /// Class ZkbActivePvp.
        /// </summary>
        [DataContract]
        public class ZkbActivePvp {

            /// <summary>
            /// Gets or sets the characters.
            /// </summary>
            /// <value>The characters.</value>
            [DataMember(Name = "characters")]
            public ZkbActivePvpStat Characters { get; set; }

            /// <summary>
            /// Gets or sets the corporations.
            /// </summary>
            /// <value>The corporations.</value>
            [DataMember(Name = "corporations")]
            public ZkbActivePvpStat Corporations { get; set; }

            /// <summary>
            /// Gets or sets the alliances.
            /// </summary>
            /// <value>The alliances.</value>
            [DataMember(Name = "alliances")]
            public ZkbActivePvpStat Alliances { get; set; }

            /// <summary>
            /// Gets or sets the ships.
            /// </summary>
            /// <value>The ships.</value>
            [DataMember(Name = "ships")]
            public ZkbActivePvpStat Ships { get; set; }

            /// <summary>
            /// Gets or sets the kills.
            /// </summary>
            /// <value>The kills.</value>
            [DataMember(Name = "kills")]
            public ZkbActivePvpStat Kills { get; set; }

            /// <summary>
            /// Gets or sets the systems.
            /// </summary>
            /// <value>The systems.</value>
            [DataMember(Name = "systems")]
            public ZkbActivePvpStat Systems { get; set; }

            /// <summary>
            /// Gets or sets the regions.
            /// </summary>
            /// <value>The regions.</value>
            [DataMember(Name = "regions")]
            public ZkbActivePvpStat Regions { get; set; }
            
        }

        /// <summary>
        /// Class ZkbActivePvpStat.
        /// </summary>
        [DataContract]
        public class ZkbActivePvpStat {

            /// <summary>
            /// Gets or sets the type.
            /// </summary>
            /// <value>The type.</value>
            [DataMember(Name = "type")]
            public string Type { get; set; }

            /// <summary>
            /// Gets or sets the count.
            /// </summary>
            /// <value>The count.</value>
            [DataMember(Name = "count")]
            public int Count { get; set; }

        }


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
            /// Gets or sets the last crest update.
            /// </summary>
            /// <value>The last crest update.</value>
            [DataMember(Name = "lastCrestUpdate")]
            public ZkbApiUpdate LastCrestUpdate { get; set; }

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