// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : larsd
// Created          : 03-03-2016
//
// Last Modified By : larsd
// Last Modified On : 03-03-2016
// ***********************************************************************
// <copyright file="AutopilotWaypoint.cs" company="Lars Kristian Dahl">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Links;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    /// <summary>
    ///     Class AutopilotWaypoint.
    /// </summary>
    [DataContract]
    public class AutopilotWaypoint : EditableEntity {
        private LinkedEntity<SolarSystem> _solarSystem;

        /// <summary>
        ///     Initializes a new instance of the <see cref="AutopilotWaypoint" /> class.
        /// </summary>
        public AutopilotWaypoint() {
            SolarSystem = new LinkedEntity<SolarSystem>();
        }

        /// <summary>
        ///     Gets or sets the solar system.
        /// </summary>
        /// <value>The solar system.</value>
        [DataMember(Name = "solarSystem")]
        public LinkedEntity<SolarSystem> SolarSystem {
            get { return _solarSystem; }
            set {
                _solarSystem = value;
                _solarSystem.SetSerializeName = false;
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="AutopilotWaypoint" /> is first.
        /// </summary>
        /// <value><c>true</c> if first; otherwise, <c>false</c>.</value>
        [DataMember(Name = "first")]
        public bool First { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether [clear other waypoints].
        /// </summary>
        /// <value><c>true</c> if [clear other waypoints]; otherwise, <c>false</c>.</value>
        [DataMember(Name = "clearOtherWaypoints")]
        public bool ClearOtherWaypoints { get; set; }
    }
}