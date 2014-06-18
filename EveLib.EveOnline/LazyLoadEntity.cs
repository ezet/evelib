namespace eZet.EveLib.Modules {
    public abstract class LazyLoadEntity : BaseEntity {
        protected bool _isInitialized;
        protected object _lazyLoadLock = new object();

        public bool IsInitialized {
            get { return _isInitialized; }
            protected set { _isInitialized = value; }
        }
    }
}