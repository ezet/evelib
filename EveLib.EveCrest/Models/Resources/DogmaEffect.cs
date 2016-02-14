// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : larsd
// Created          : 02-14-2016
//
// Last Modified By : larsd
// Last Modified On : 02-14-2016
// ***********************************************************************
// <copyright file="DogmaEffect.cs" company="Lars Kristian Dahl">
//     Copyright ©  2015
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Links;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    /// <summary>
    /// Class DogmaEffect. This class cannot be inherited.
    /// </summary>
    [DataContract]
    public sealed class DogmaEffect : CrestResource<DogmaEffect> {
        /// <summary>
        /// Initializes a new instance of the <see cref="DogmaEffect"/> class.
        /// </summary>
        public DogmaEffect() {
            ContentType = "application/vnd.ccp.eve.DogmaEffect-v1+json";
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is assistance.
        /// </summary>
        /// <value><c>true</c> if this instance is assistance; otherwise, <c>false</c>.</value>
        [DataMember(Name = "isAssistance")]
        public bool IsAssistance { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [DataMember(Name = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is offensive.
        /// </summary>
        /// <value><c>true</c> if this instance is offensive; otherwise, <c>false</c>.</value>
        [DataMember(Name = "isOffensive")]
        public bool IsOffensive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [disallow automatic repeat].
        /// </summary>
        /// <value><c>true</c> if [disallow automatic repeat]; otherwise, <c>false</c>.</value>
        [DataMember(Name = "disallowAutoRepeat")]
        public bool DisallowAutoRepeat { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is warp safe.
        /// </summary>
        /// <value><c>true</c> if this instance is warp safe; otherwise, <c>false</c>.</value>
        [DataMember(Name = "isWarpSafe")]
        public bool IsWarpSafe { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [electronic chance].
        /// </summary>
        /// <value><c>true</c> if [electronic chance]; otherwise, <c>false</c>.</value>
        [DataMember(Name = "electronicChance")]
        public bool ElectronicChance { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [range change].
        /// </summary>
        /// <value><c>true</c> if [range change]; otherwise, <c>false</c>.</value>
        [DataMember(Name = "rangeChange")]
        public bool RangeChange { get; set; }

        /// <summary>
        /// Gets or sets the effect category.
        /// </summary>
        /// <value>The effect category.</value>
        [DataMember(Name = "effectCategory")]
        public long EffectCategory { get; set; }

        /// <summary>
        /// Gets or sets the post expression.
        /// </summary>
        /// <value>The post expression.</value>
        [DataMember(Name = "postExpression")]
        public long PostExpression { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="DogmaEffect"/> is published.
        /// </summary>
        /// <value><c>true</c> if published; otherwise, <c>false</c>.</value>
        [DataMember(Name = "published")]
        public bool Published { get; set; }

        /// <summary>
        /// Gets or sets the pre expression.
        /// </summary>
        /// <value>The pre expression.</value>
        [DataMember(Name = "preExpression")]
        public long PreExpression { get; set; }

        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        /// <value>The display name.</value>
        [DataMember(Name = "displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the discharge attribute identifier.
        /// </summary>
        /// <value>The discharge attribute identifier.</value>
        [DataMember(Name = "dischargeAttributeID")]
        public LinkedEntity<DogmaAttribute> DischargeAttributeId { get; set; }

        /// <summary>
        /// Gets or sets the duration attribute identifier.
        /// </summary>
        /// <value>The duration attribute identifier.</value>
        [DataMember(Name = "durationAttributeID")]
        public LinkedEntity<DogmaAttribute> DurationAttributeId { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [DataMember(Name = "id")]
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}