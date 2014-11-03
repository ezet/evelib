// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 06-13-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-18-2014
// ***********************************************************************
// <copyright file="LazyLoadEntity.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace eZet.EveLib.Modules {
    /// <summary>
    /// Class LazyLoadEntity.
    /// </summary>
    public abstract class LazyLoadEntity : BaseEntity {
        /// <summary>
        /// The _is initialized
        /// </summary>
        protected bool _isInitialized;
        /// <summary>
        /// The _lazy load lock
        /// </summary>
        protected object _lazyLoadLock = new object();

        /// <summary>
        /// Gets or sets a value indicating whether this instance is initialized.
        /// </summary>
        /// <value><c>true</c> if this instance is initialized; otherwise, <c>false</c>.</value>
        public bool IsInitialized {
            get { return _isInitialized; }
            protected set { _isInitialized = value; }
        }
    }
}