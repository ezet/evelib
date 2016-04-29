namespace eZet.EveLib.EveCrestModule.Models.Links {
    /// <summary>
    /// Class ParameterHref.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TParam">The type of the t parameter.</typeparam>
    public class ParameterHref<T, TParam> : Href<T> {
        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterHref{T, TParam}" /> class.
        /// </summary>
        /// <param name="href">The href.</param>
        public ParameterHref(string href) : base(href) {

        }
    }
}