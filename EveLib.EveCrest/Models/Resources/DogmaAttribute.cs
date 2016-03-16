// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : larsd
// Created          : 02-14-2016
//
// Last Modified By : larsd
// Last Modified On : 02-14-2016
// ***********************************************************************
// <copyright file="DogmaAttribute.cs" company="Lars Kristian Dahl">
//     Copyright ©  2015
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Runtime.Serialization;

namespace eZet.EveLib.EveCrestModule.Models {
    /// <summary>
    ///     Class DogmaAttribute. This class cannot be inherited.
    /// </summary>
    public sealed class DogmaAttribute : CrestResource<DogmaAttribute> {
        /// <summary>
        ///     Initializes a new instance of the <see cref="DogmaAttribute" /> class.
        /// </summary>
        public DogmaAttribute() {
            ContentType = "application/vnd.ccp.eve.DogmaAttribute-v1+json";
        }

        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [DataMember(Name = "id")]
        public long Id { get; set; }

        /// <summary>
        ///     Gets or sets the display name.
        /// </summary>
        /// <value>The display name.</value>
        [DataMember(Name = "displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the default value.
        /// </summary>
        /// <value>The default value.</value>
        [DataMember(Name = "defaultValue")]
        public float DefaultValue { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="DogmaAttribute" /> is published.
        /// </summary>
        /// <value><c>true</c> if published; otherwise, <c>false</c>.</value>
        [DataMember(Name = "published")]
        public bool Published { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether [high is good].
        /// </summary>
        /// <value><c>true</c> if [high is good]; otherwise, <c>false</c>.</value>
        [DataMember(Name = "highIsHood")]
        public bool HighIsGood { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="DogmaAttribute" /> is stackable.
        /// </summary>
        /// <value><c>true</c> if stackable; otherwise, <c>false</c>.</value>
        [DataMember(Name = "stackable")]
        public bool Stackable { get; set; }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [DataMember(Name = "description")]
        public string Description { get; set; }
    }
}