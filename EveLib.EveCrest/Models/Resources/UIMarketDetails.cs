// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Adrian Bannister
// Created          : 26-07-2016
//
// Last Modified By : Adrian Bannister
// Last Modified On : 26-07-2016
// ***********************************************************************
// <copyright file="UIMarketDetails.cs" company="Lars Kristian Dahl">
//     Copyright © 2016
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Links;

namespace eZet.EveLib.EveCrestModule.Models.Resources
{
    /// <summary>
    ///     Class UIMarketDetails.
    /// </summary>
    [DataContract]
    public class UIMarketDetails : EditableEntity
    {
        private LinkedEntity<ItemType> _itemType;

        /// <summary>
        ///     Initializes a new instance of the <see cref="UIMarketDetails" /> class.
        /// </summary>
        public UIMarketDetails()
        {
            ItemType = new LinkedEntity<ItemType>();
        }

        /// <summary>
        ///     Gets or sets the item type.
        /// </summary>
        /// <value>The solar system.</value>
        [DataMember(Name = "type")]
        public LinkedEntity<ItemType> ItemType
        {
            get { return _itemType; }
            set
            {
                _itemType = value;
                _itemType.SetSerializeName = false;
            }
        }
    }
}