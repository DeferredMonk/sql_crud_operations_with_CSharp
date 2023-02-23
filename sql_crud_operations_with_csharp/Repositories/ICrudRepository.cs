namespace sql_crud_operations_with_csharp.Repositories
{
    public interface ICrudRepository<T, Id>
    {
        /// <summary>
        /// Returns all customers
        /// </summary>
        /// <returns><see cref="Customer"/>List of customers</returns>
        IEnumerable<T> GetAll();
        T GetById(Id id);
        void Add(T entity);
        void Update(T entity);
    }
}
