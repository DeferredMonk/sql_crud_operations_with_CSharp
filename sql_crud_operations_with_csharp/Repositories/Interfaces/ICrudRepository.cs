namespace sql_crud_operations_with_csharp.Repositories.Interfaces
{
    /// <summary>
    /// Interface for Crud operations
    /// </summary>
    /// <typeparam name="T">Type of data (model)</typeparam>
    /// <typeparam name="Id">Int Id of given model (table)</typeparam>
    public interface ICrudRepository<T, Id>
    {
        /// <summary>
        /// GetAll gets all rows 
        /// from database
        /// </summary>
        /// <returns>Yields row of data</returns>
        IEnumerable<T> GetAll();
        /// <summary>
        /// GetById gets one row 
        /// for the specified id
        /// </summary>
        /// <param name="id">Id of table</param>
        /// <returns>One row of data</returns>
        T GetById(Id id);
        /// <summary>
        /// Adds entity to Database
        /// </summary>
        /// <param name="entity">Template of table object</param>
        void Add(T entity);
        /// <summary>
        /// Updates entity to database
        /// </summary>
        /// <param name="entity">Template of table object</param>
        void Update(T entity);
    }
}
