// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : larsd
// Created          : 03-03-2016
//
// Last Modified By : larsd
// Last Modified On : 03-03-2016
// ***********************************************************************
// <copyright file="EditableCollectionResource.cs" company="Lars Kristian Dahl">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    /// <summary>
    ///     Class EditableCollectionResource.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TCollection">The type of the t collection.</typeparam>
    public class EditableCollectionResource<T, TCollection> : CollectionResource<T, TCollection>,
        IEditableCollectionResource<T, TCollection> where T : CollectionResource<T, TCollection>
        where TCollection : class, IEditableEntity, new() {
        /// <summary>
        ///     Injects the specified crest instance.
        /// </summary>
        /// <param name="crestInstance">The crest instance.</param>
        public override void Inject(EveCrest crestInstance) {
            base.Inject(crestInstance);
            foreach (var item in Items) {
                item.EveCrest = EveCrest;
                item.SaveAsNew = false;
            }
        }
    }
}