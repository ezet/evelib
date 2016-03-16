namespace eZet.EveLib.Core.Serializers {
    /// <summary>
    ///     Interface for deserializing objects.
    /// </summary>
    public interface ISerializer {
        /// <summary>
        ///     Deserializes data.
        /// </summary>
        /// <typeparam name="T">Type to deserialize to.</typeparam>
        /// <param name="data">String of data to deserialize.</param>
        /// <returns></returns>
        T Deserialize<T>(string data);

        /// <summary>
        ///     Serializes the specified entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns>System.String.</returns>
        string Serialize<T>(T entity);
    }
}