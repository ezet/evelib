// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : larsd
// Created          : 10-20-2015
//
// Last Modified By : larsd
// Last Modified On : 10-20-2015
// ***********************************************************************
// <copyright file="GraphicId.cs" company="Lars Kristian Dahl">
//     Copyright ©  2015
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Runtime.Serialization;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    /// <summary>
    ///     Class GraphicId.
    /// </summary>
    [DataContract]
    public sealed class GraphicId : CrestResource<GraphicId> {
        /// <summary>
        ///     Initializes a new instance of the <see cref="GraphicId" /> class.
        /// </summary>
        public GraphicId() {
            ContentType = "application/vnd.ccp.eve.GraphicID-v1+json; charset=utf-8";
        }

        /// <summary>
        ///     Gets or sets the graphic file.
        /// </summary>
        /// <value>The graphic file.</value>
        [DataMember(Name = "graphicFile")]
        public string GraphicFile { get; set; }

        /// <summary>
        ///     Gets or sets the sof dna.
        /// </summary>
        /// <value>The sof dna.</value>
        [DataMember(Name = "SofDNA")]
        public string SofDna { get; set; }

        /// <summary>
        ///     Gets or sets the name of the sof faction.
        /// </summary>
        /// <value>The name of the sof faction.</value>
        [DataMember(Name = "sofFactionName")]
        public string SofFactionName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the sof race.
        /// </summary>
        /// <value>The name of the sof race.</value>
        [DataMember(Name = "sofRaceName")]
        public string SofRaceName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the sof hull.
        /// </summary>
        /// <value>The name of the sof hull.</value>
        [DataMember(Name = "sofHullName")]
        public string SofHullName { get; set; }

        /// <summary>
        ///     Gets or sets the isis icon path.
        /// </summary>
        /// <value>The isis icon path.</value>
        [DataMember(Name = "isisIconPath")]
        public string IsisIconPath { get; set; }
    }
}