// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Adrian Bannister
// Created          : 26-07-2016
//
// Last Modified By : Adrian Bannister
// Last Modified On : 26-07-2016
// ***********************************************************************
// <copyright file="UIContract.cs" company="Lars Kristian Dahl">
//     Copyright © 2016
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Runtime.Serialization;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    /// <summary>
    ///     Class UIContract.
    /// </summary>
    [DataContract]
    public class UIContract : EditableEntity {

        /// <summary>
        ///     Initializes a new instance of the <see cref="UIContract" /> class.
        /// </summary>
        public UIContract() {
        }

        /// <summary>
        ///     Gets or sets the contract ID.
        /// </summary>
        /// <value>The solar system.</value>
        [DataMember(Name = "contractID")]
        public long ItemType { get; set; }
    }
}