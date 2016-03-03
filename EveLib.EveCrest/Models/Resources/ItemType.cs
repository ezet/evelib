// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Lars Kristian
// Created          : 12-16-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 02-14-2016
// ***********************************************************************
// <copyright file="ItemType.cs" company="Lars Kristian Dahl">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Links;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    /// <summary>
    ///     Class ItemType. This class cannot be inherited.
    /// </summary>
    [DataContract]
    public sealed class ItemType : CrestResource<ItemType> {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ItemType" /> class.
        /// </summary>
        public ItemType() {
            ContentType = "application/vnd.ccp.eve.ItemType-v3+json";
        }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [DataMember(Name = "description")]
        public string Description { get; set; }

        /// <summary>
        ///     Gets or sets the volume.
        /// </summary>
        /// <value>The volume.</value>
        [DataMember(Name = "volume")]
        public float Volume { get; set; }


        /// <summary>
        ///     Gets or sets the capacity.
        /// </summary>
        /// <value>The capacity.</value>
        [DataMember(Name = "capacity")]
        public float Capacity { get; set; }

        /// <summary>
        ///     Gets or sets the size of the portion.
        /// </summary>
        /// <value>The size of the portion.</value>
        [DataMember(Name = "portionSize")]
        public int PortionSize { get; set; }

        /// <summary>
        ///     Gets or sets the radius.
        /// </summary>
        /// <value>The radius.</value>
        [DataMember(Name = "radius")]
        public float Radius { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="ItemType" /> is published.
        /// </summary>
        /// <value><c>true</c> if published; otherwise, <c>false</c>.</value>
        [DataMember(Name = "published")]
        public bool Published { get; set; }

        /// <summary>
        ///     Gets or sets the mass.
        /// </summary>
        /// <value>The mass.</value>
        [DataMember(Name = "mass")]
        public float Mass { get; set; }

        /// <summary>
        ///     Gets or sets the icon identifier.
        /// </summary>
        /// <value>The icon identifier.</value>
        [DataMember(Name = "iconID")]
        public int IconId { get; set; }

        /// <summary>
        ///     Gets or sets the graphic identifier.
        /// </summary>
        /// <value>The graphic identifier.</value>
        [DataMember(Name = "graphicID")]
        public Shared.GraphicId GraphicId { get; set; }

        /// <summary>
        ///     Gets or sets the dogma.
        /// </summary>
        /// <value>The dogma.</value>
        [DataMember(Name = "dogma")]
        public DogmaCategory Dogma { get; set; }


        /// <summary>
        ///     Class DogmaCategory.
        /// </summary>
        [DataContract]
        public class DogmaCategory {
            /// <summary>
            ///     Gets or sets the attributes.
            /// </summary>
            /// <value>The attributes.</value>
            [DataMember(Name = "attributes")]
            public IReadOnlyList<DogmaAttribute> Attributes { get; set; }

            /// <summary>
            ///     Gets or sets the effects.
            /// </summary>
            /// <value>The effects.</value>
            [DataMember(Name = "effects")]
            public IReadOnlyList<DogmaEffect> Effects { get; set; }
        }

        /// <summary>
        ///     Class DogmaAttribute.
        /// </summary>
        [DataContract]
        public class DogmaAttribute {
            /// <summary>
            ///     Gets or sets the attribute.
            /// </summary>
            /// <value>The attribute.</value>
            [DataMember(Name = "attribute")]
            public LinkedEntity<DogmaAttribute> Attribute { get; set; }

            /// <summary>
            ///     Gets or sets the value.
            /// </summary>
            /// <value>The value.</value>
            [DataMember(Name = "value")]
            public float Value { get; set; }
        }

        /// <summary>
        ///     Class DogmaEffect.
        /// </summary>
        [DataContract]
        public class DogmaEffect {
            /// <summary>
            ///     Gets or sets the effect.
            /// </summary>
            /// <value>The effect.</value>
            [DataMember(Name = "effect")]
            public LinkedEntity<DogmaEffect> Effect { get; set; }

            /// <summary>
            ///     Gets or sets a value indicating whether this instance is default.
            /// </summary>
            /// <value><c>true</c> if this instance is default; otherwise, <c>false</c>.</value>
            [DataMember(Name = "isDefault")]
            public bool IsDefault { get; set; }
        }
    }
}