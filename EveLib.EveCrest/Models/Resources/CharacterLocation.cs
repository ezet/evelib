// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : larsd
// Created          : 02-13-2016
//
// Last Modified By : larsd
// Last Modified On : 02-13-2016
// ***********************************************************************
// <copyright file="CharacterLocation.cs" company="Lars Kristian Dahl">
//     Copyright ©  2015
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Links;

namespace eZet.EveLib.EveCrestModule.Models.Resources {

    /// <summary>
    /// Class CharacterLocation. This class cannot be inherited.
    /// </summary>
    [DataContract]
    public sealed class CharacterLocation : CrestResource<CharacterLocation> {

        /// <summary>
        /// Initializes a new instance of the <see cref="CharacterLocation"/> class.
        /// </summary>
        public CharacterLocation() {
            ContentType = "application/vnd.ccp.eve.CharacterLocation-v1+json";
        }

        [DataMember(Name = "solarSystem")]
        public LinkedEntity<SolarSystem> SolarSystem { get; set; }
         
    }
}